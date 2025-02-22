namespace Configuration
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {

        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasOne(b => b.User)
                    .WithMany(b => b.Reviews)
                    .HasForeignKey(b => b.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
                    
            builder.HasOne(b => b.Product)
                    .WithMany(b => b.Reviews)
                    .HasForeignKey(b => b.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(r => r.Product)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(r => r.ProductId)
                    .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}