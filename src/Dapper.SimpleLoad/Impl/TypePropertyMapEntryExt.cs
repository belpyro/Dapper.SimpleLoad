using System;
using System.Collections.Generic;
using System.Linq;
using Dapper.SimpleSave.Attributes;
using Dapper.SimpleSave.Configuration;
using Dapper.SimpleSave.Metadata;

namespace Dapper.SimpleLoad.Impl
{
    public class TypePropertyMapEntryExt
    {
        public TypePropertyMapEntryExt(
            Type type,
            string alias,
            int index,
            ISet<Type> typesWeCareAbout)
        {
            Type = type;
            Metadata = SimpleSaveConfiguration.GetEntityConfig(type);
            Alias = alias;
            Index = index;
            foreach (var property in Metadata.Properties.Values.Where(p => !p.IsIgnored))
            {
                var key = property.Prop.PropertyType;
                if (property.IsEnumerable)
                {
                    var genericArguments = property.Prop.PropertyType.GenericTypeArguments;
                    if (genericArguments == null
                        || genericArguments.Length != 1
                        || !typesWeCareAbout.Contains(genericArguments[0])
                        || !property.HasRelationship)
                    {
                        continue;
                    }

                    key = genericArguments[0];
                }
                else if (!typesWeCareAbout.Contains(key))
                {
                    if (property.HasAttribute<ForeignKeyReferenceAttribute>())
                    {
                        //  Value type back references are the only property types we support. If there's any kind of object
                        //  in there we ignore it for the purpose of back referencing. Basically, if something's marked with
                        //  one of SimpleSave's cardinality attributes we assume it's a forward reference; if it's not marked
                        //  with such a reference and it's not a value type then it's also not a supported foreign key column
                        //  type, so we can't do anything with it anyway.
                        if (!property.IsValueType && property.IsReferenceType)
                        {
                            continue;
                        }

                        var foreignKey = property.GetAttribute<ForeignKeyReferenceAttribute>();
                        key = foreignKey.ReferencedDto;
                        if (!typesWeCareAbout.Contains(key))
                        {
                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (!property.HasRelationship && !property.IsEnum)
                {
                    continue;
                }
            }
        }

        public Type Type { get; }

        public IConfiguration Metadata { get; }

        public string Alias { get; }

        public int Index { get; }
    }
}