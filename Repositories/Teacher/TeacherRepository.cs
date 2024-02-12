namespace PostGresAPI.Repositories;

using PostGresAPI.Data;
using PostGresAPI.DTOS;
using PostGresAPI.Models;
using PostGresAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

public class TeacherRepository : ITeacherRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public TeacherRepository(ApplicationDbContext context)
    {
        _applicationDbContext = context;
    }

    public IEnumerable<ReturnTeacherDTO> GetAll()
    {
        var teachers = _applicationDbContext.Teachers.Select(
            x => new ReturnTeacherDTO()
            {
                Name = x.Name,
                Subject = x.Subject.Name
            });
        return teachers.ToList();

    }
 
    public IEnumerable<ReturnTeacherDTO> GetById(Guid id)
    {
        var teachers = _applicationDbContext.Teachers.Where(t => t.Id == id)
            .Select(x => new ReturnTeacherDTO()
            {
                Name = x.Name,
                Subject = x.Subject.Name
            });
        return teachers.ToList();
    }

    public Teacher Create(TeacherDTO teacherDto)
    {

        var teacher = new Teacher()
        {
            Name = teacherDto.Name,
        };

        _applicationDbContext.Teachers.Add(teacher);
        _applicationDbContext.SaveChanges();

        return teacher;
    }

    public Teacher Update(Teacher teacher)
    {
        var existingTeacher = _applicationDbContext.Teachers.Find(teacher.Id);

        
        existingTeacher.Name = teacher.Name;
        
        
        _applicationDbContext.SaveChanges();
        return existingTeacher;
    }

    public void Delete(Guid id)
    {
        var teacherToDelete = _applicationDbContext.Teachers.Find(id);
        if (teacherToDelete != null)
        {
            _applicationDbContext.Teachers.Remove(teacherToDelete);
            _applicationDbContext.SaveChanges();
        }
    }
}