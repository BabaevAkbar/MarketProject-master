namespace Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.FirstName)
                    .IsRequired()
                    .HasMaxLength(100); 
            builder.HasMany(u => u.Orders)    
                    .WithOne(b => b.User)
                    .HasForeignKey(b => b.UserId);

        }
    }
}