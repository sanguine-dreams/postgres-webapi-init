using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PostGresAPI.Models;

public class SubjectMap: IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasOne(t => t.Teacher)
            .WithOne(t => t.Subject)
            .HasForeignKey<Teacher>(x => x.SubjectId)
            ;
    }
}