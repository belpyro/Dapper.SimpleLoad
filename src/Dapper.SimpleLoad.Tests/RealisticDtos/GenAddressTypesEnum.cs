using System.ComponentModel;
using System.Runtime.Serialization;
using Dapper.SimpleSave;
using Dapper.SimpleSave.Attributes;

namespace Dapper.SimpleLoad.Tests.RealisticDtos
{
    [DataContract]
	[Table("[gen].ADDRESS_TYPES_ENUM"), ReferenceData]
    public enum GenAddressTypesEnum : int
    {
       [Description("None")][EnumMember]None = 0,
    }
}
