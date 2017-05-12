using Dapper.SimpleSave;
using Dapper.SimpleSave.Attributes;

namespace Dapper.SimpleLoad.Tests.RealisticDtos
{
    [Table("[gen].[POSTCODE_IDXVIEW]")]
    public class PostcodeDto
    {
        [PrimaryKey]
        [ForeignKeyReference(typeof(PostCodeDetailsDto))]
        public int? PostCodeKey { get; set; }
        public string PostCode { get; set; }
    }
}
