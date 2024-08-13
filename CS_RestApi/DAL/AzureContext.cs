using CS_RestApi.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CS_RestApi.DAL
{
    public class AzureContext : DbContext
    {
        private string _connectionString;
        public AzureContext(DbContextOptions<AzureContext> options) : base(options)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            _connectionString = configuration.GetConnectionString("azureDbConnectionString") ?? string.Empty;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_connectionString == string.Empty) 
            {
                throw new ArgumentException(nameof(_connectionString));
            }
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>().HasKey(e => e.OrderItemId).HasName("PK_OrderItemId");
            modelBuilder.Entity<Order>().HasMany(e => e.OrderItems).WithOne(e => e.Order).HasForeignKey(e => e.OrderNumber).HasConstraintName("FK_OrderItem_Order");
            modelBuilder.Entity<Order>().HasKey(e => e.OrderNumber).HasName("PK_OrderNumber");
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
