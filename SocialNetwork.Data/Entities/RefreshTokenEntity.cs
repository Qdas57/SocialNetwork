using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Data.Entities
{
    public class RefreshTokenEntity
    {
        /// <summary>
        /// Идентификатор обновления токена.
        /// </summary>
        [Key]
        [Column("RefreshTokenId")]
        public long RefreshTokenId { get; set; }

        /// <summary>
        /// Токен.
        /// </summary>
        [Column("RefreshToken")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        [Column("UserId")]
        public Guid UserId { get; set; }
    }
}
