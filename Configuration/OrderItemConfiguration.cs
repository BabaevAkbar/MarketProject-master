namespace Configuration
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasOne(a => a.Order)
                    .WithMany(b => b.OrderItem)
                    .HasForeignKey(c => c.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);
                    
            builder.HasOne(a => a.Order)
                    .WithMany(b => b.OrderItem)
                    .HasForeignKey(c => c.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}