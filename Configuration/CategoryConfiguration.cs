namespace Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(a => a.Name)
                    .IsRequired()
                    .HasMaxLength(150);
        }
    }
}