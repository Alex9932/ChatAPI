using System.Diagnostics.CodeAnalysis;
using ChatAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatAPI.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Server> Servers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Token> Tokens { get; set; }

        public AppDBContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(e => e.HasIndex(u => u.Login).IsUnique());
        }
    }
}
