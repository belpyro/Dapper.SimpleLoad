using Dapper.SimpleSave.Attributes;

namespace Dapper.SimpleSave.Test.Dto
{
    [Table("User")]
    public class UserDto
    {
        [PrimaryKey]
        public int? Id { get; set; }

        public int MyCustomKey { get; set; }

        [Column("Logins")]
        public string Login { get; set; }

        [OneToOne]
        [ForeignKeyReference(typeof(AddressDto))]
        [Column("AddressId")]
        public AddressDto Address { get; set; }
    }
}