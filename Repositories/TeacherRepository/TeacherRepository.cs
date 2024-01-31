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

    public IEnumerable<Teacher> GetAll()
    {
        return _applicationDbContext.Teachers.ToList();

    }

    public Teacher GetById(int id)
    {
        return _applicationDbContext.Teachers.Find(id);
    }

    public Teacher Create(TeacherDTO teacherDto)
    {
        long generatedId = _applicationDbContext.Teachers.LongCount() + 1;

        var teacher = new Teacher()
        {
            Id = (int)generatedId,
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

    public void Delete(int id)
    {
        var teacherToDelete = _applicationDbContext.Teachers.Find(id);
        if (teacherToDelete != null)
        {
            _applicationDbContext.Teachers.Remove(teacherToDelete);
            _applicationDbContext.SaveChanges();
        }
    }
}