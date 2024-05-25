using DataWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Identity.Client;

namespace DataWebApi
{
    public class TestCenterDbContext : DbContext
    {
        public TestCenterDbContext(DbContextOptions<TestCenterDbContext> dbContextOptions) : base(dbContextOptions)
        {
            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreator != null)
                {
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();
                    if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            } 
        }

        public DbSet<DataWebApi.Models.TestCenter> TestCenter { get; set; } = default!;
        public DbSet<DataWebApi.Models.Register> Register { get; set; } = default!;
        public DbSet<DataWebApi.Models.BaseProcess> BaseProcess { get; set; } = default!;
        public DbSet<DataWebApi.Models.Devices.BaseDevice> BaseDevice { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Register>()
                .Property(r => r.Value)
                .HasColumnType("nvarchar(max)"); // JSON formatında saklanacak alan
        }
    }
}
