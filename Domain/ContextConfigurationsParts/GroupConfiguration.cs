using ClassJournals.Domain.Entities.CoursesAndGroups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassJournals.Domain.ContextConfigurationsParts
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.Property(g => g.GroupId).IsRequired();

            builder.Property(g => g.Name).HasMaxLength(10)
                .IsRequired();

        }
    }
}