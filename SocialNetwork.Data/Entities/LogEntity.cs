using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Data.Entities
{
    [Table("Logs", Schema = "dbo")]
    public class LogEntity
    {
        [Key]
        public long LogId { get; set; }

        [Column("LogLevel", TypeName = "nvarchar(20)")]
        public string LogLevel { get; set; }

        public DateTime Date { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }
    }
}
