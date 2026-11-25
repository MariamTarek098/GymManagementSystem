using GymManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagementSystem.Configurations
{
    public class GymUserConfigurations<T> : IEntityTypeConfiguration<T> where T:GymUser
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.Name)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder.Property(x => x.Phone)
                .HasColumnType("varchar")
                .HasMaxLength(11);

            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.Phone).IsUnique();

            builder.ComplexProperty(x => x.Address);


            builder.ToTable(T =>
            {
                T.HasCheckConstraint("Email_FormatCheck", "Email like '_%@_%._%'");
                T.HasCheckConstraint("Phone_FormatCheck", "Len(Phone)=11 And (Phone like '010%' or Phone like '011%' or Phone Like '012%' or Phone Like '015%')");


            });


        }

    }
}
