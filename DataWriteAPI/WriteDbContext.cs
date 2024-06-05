using DataReadApi.Models;
using DataReadApi.Models.Devices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Identity.Client;

namespace DataReadApi
{
    public class WriteDbContext : DbContext
    {
        public WriteDbContext(DbContextOptions<WriteDbContext> dbContextOptions) : base(dbContextOptions) {
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

        public DbSet<DataReadApi.Models.Register> Register { get; set; } = default!;
        public DbSet<DataReadApi.Models.Devices.BaseDevice> BaseDevice { get; set; } = default!;
        public DbSet<DataReadApi.Models.Devices.RTUDevice> RTUDevice { get; set; } = default!;
        public DbSet<DataReadApi.Models.Devices.PLCDevice> PLCDevice { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Register>()
                .Property(r => r.Value)
                .HasColumnType("longtext"); // JSON formatında saklanacak alan

        }
    }
}
