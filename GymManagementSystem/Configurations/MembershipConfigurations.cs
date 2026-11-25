using GymManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagementSystem.Configurations
{
    public class MembershipConfigurations : IEntityTypeConfiguration<Membership>
    {
        public void Configure(EntityTypeBuilder<Membership> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.HasOne(Ms => Ms.Paln)
                .WithMany(P => P.PlanSubscriptions)
                .HasForeignKey(Ms => Ms.PlanId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(Ms => Ms.Member)
               .WithMany(P => P.MemberSubscriptions)
               .HasForeignKey(Ms => Ms.MemberId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Ignore(x =>x.Status);
        }
    }
}
