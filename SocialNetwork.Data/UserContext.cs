﻿using Microsoft.EntityFrameworkCore;
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
    }
}