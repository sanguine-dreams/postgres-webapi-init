using System.Collections.Immutable;

namespace PostGresAPI.Repositories;

using PostGresAPI.Data;
using PostGresAPI.DTOS;
using PostGresAPI.Models;
using PostGresAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

public class StudentRepository : IStudentRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public StudentRepository(ApplicationDbContext context)
    {
        _applicationDbContext = context;
    }

    public IEnumerable<Student> GetAll()
    {
        return _applicationDbContext.Students.ToList();

    }

    public Student GetById(int id)
    {
        return _applicationDbContext.Students.Find(id);
    }

    public Student Create(StudentDTO studentDto)
    {
        long generatedId = _applicationDbContext.Students.LongCount() + 1;

        var student = new Student()
        {
            Id = (int)generatedId,
            Name = studentDto.Name,
           
        };

        _applicationDbContext.Students.Add(student);
        _applicationDbContext.SaveChanges();

        return student;
    }

    public Student Update(Student student)
    {
        var existingStudent = _applicationDbContext.Students.Find(student.Id);
        
         
        if (existingStudent != null)
        {
            existingStudent.Name = student.Name;
            existingStudent.SubjectId = student.SubjectId;
            
        
            _applicationDbContext.SaveChanges();
        }
        
        _applicationDbContext.SaveChanges();
        return existingStudent;
    }

    public void Delete(int id)
    {
        var studentToDelete = _applicationDbContext.Students.Find(id);
        if (studentToDelete != null)
        {
            _applicationDbContext.Students.Remove(studentToDelete);
            _applicationDbContext.SaveChanges();
        }
    }
}
