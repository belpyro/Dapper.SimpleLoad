using Dapper.SimpleSave.Configuration;
using Dapper.SimpleSave.Test.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dapper.SimpleSave.Test
{
    [TestClass]
    public class ConfigurationTest
    {
        [TestMethod]
        public void TestGetDefaultConfig()
        {
            var result = SimpleSaveConfiguration.GetEntityConfig<UserDto>();
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Configuration.DtoType, typeof(UserDto));
            Assert.AreEqual(nameof(UserDto), result.Configuration.TableName);
        }

        [TestMethod]
        public void TestDefaultConfigWithDefaultKey()
        {
            var result = SimpleSaveConfiguration.GetEntityConfig<UserDto>().AsDefault();
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Configuration.Key.Prop.Name, nameof(UserDto.Id));
        }

        [TestMethod]
        public void TestDefaultConfigWithCustomKey()
        {
            var result = SimpleSaveConfiguration.GetEntityConfig<UserDto>().WithKey(x => x.MyCustomKey).AsDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Configuration.Key.Prop.Name, nameof(UserDto.MyCustomKey));
        }

        [TestMethod]
        public void TestDefaultConfigWithColumnName()
        {
            var result = SimpleSaveConfiguration.GetEntityConfig<UserDto>()
                .WithKey(x => x.MyCustomKey).Column(x => x.MyCustomKey, "Id");

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Configuration.Key.ColumnName, "Id");
        }

        [TestMethod]
        public void TestDefaultConfigWithColumnNameAttr()
        {
            var result = new AttributesEntityConfiguration<UserDto>().AsDefault();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestDefaultConfigWithTypeParameter()
        {
            var result = SimpleSaveConfiguration.GetEntityConfig(typeof(UserDto));

            Assert.IsNotNull(result);
        }
    }
}
