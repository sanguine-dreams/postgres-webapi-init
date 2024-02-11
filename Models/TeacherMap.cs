using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PostGresAPI.Models;

public class TeacherMap: IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Name)
            .HasMaxLength(200);
        
        builder.HasOne(t => t.Subject)
            .WithOne(t => t.Teacher)
            .HasForeignKey<Subject>(x => x.TeacherId);
    }
}