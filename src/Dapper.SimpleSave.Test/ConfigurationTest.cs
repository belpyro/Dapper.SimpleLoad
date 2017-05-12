using Dapper.SimpleSave.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dapper.SimpleSave.Test
{
    [TestClass]
    public class ConfigurationTest
    {
        [TestMethod]
        public void TestCreationConfig()
        {
            var result = new ConfigurationExtensions<AddressDto>().ToTable("[gen].[ADDRESS_MST]")
                .WithKey(a => a.AddressGuid)
                .WithOneToOne<CountyDto>(a => a.County, $"{nameof(CountyDto.Id)}")
                .Column(x => x.County, "MyCounty")
                .WithIgnore(x => x.AddressTypeKey, x => x.HouseName, x => x.PostCodeDetails)
                .WithReadOnly(x => x.TownName)
                .WithSoftDelete(x => x.FlatAptSuite);
        }
    }
}
