using Microsoft.EntityFrameworkCore;
using SocialNetwork.Data.Entities;

namespace SocialNetwork.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<RefreshTokenEntity> RefreshTokens { get; set; }

        public DbSet<LogEntity> Logs { get; set; }
    }
}
