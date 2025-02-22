namespace Context
{
    public class MarketProjectDbContext : DbContext
    {
        public MarketProjectDbContext(DbContextOptions<MarketProjectDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Category> Category{ get; set; }
        public DbSet<Order> Order{ get; set; }
        public DbSet<OrderItem> OrderItem{ get; set; }
        public DbSet<Product> Product{ get; set; }
        public DbSet<Review> Review{ get; set; }
        public DbSet<User> User{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}