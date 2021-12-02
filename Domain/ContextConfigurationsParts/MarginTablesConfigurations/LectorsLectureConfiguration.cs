using ClassJournals.Domain.Entities.JoiningEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassJournals.Domain.ContextConfigurationsParts.MarginTablesConfigurations
{
    public class LectorsLectureConfiguration : IEntityTypeConfiguration<LectorsLecture>
    {
        public void Configure(EntityTypeBuilder<LectorsLecture> builder)
        {
            builder.HasKey(Ll => new { Ll.LectorId, Ll.LectureId });

            builder.HasOne(Ll => Ll.Lectors)
                .WithMany(l => l.LectorsLecture);

            builder.HasOne(Ll => Ll.Lectures)
                .WithMany(L => L.LectorsLecture);
        }
    }
}
