using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Data.Entities
{
    [Table("Users", Schema = "dbo")]
    public class UserEntity
    {
        [Key]
        public Guid UserId { get; set; }

        [Column("FirstName", TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string? Phone { get; set; }

        public string? Avatar { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime RegisterDate { get; set; }
    }
}
