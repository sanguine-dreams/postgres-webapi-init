using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PostGresAPI.Models;

public class StudentMap: IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Subjects)
            .WithMany(x => x.Students)
            .UsingEntity<StudentSubject>();
        
    }
}