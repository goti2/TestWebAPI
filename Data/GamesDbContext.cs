using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestWebAPI.Data.Entities;

namespace TestWebAPI.Data
{
    public class GamesDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<FolderEntity> Folders { get; set; }
        public DbSet<GameEntity> Games { get; set; }


        public GamesDbContext(DbContextOptions<GamesDbContext> options)
            : base(options)
        {
            
        }
    }
}