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

    public GetReturn<StudentGetAllOutput> GetAll(int? skip, int? take)
    {
        var query = _applicationDbContext.Students.AsQueryable();

        if (skip == null || take == null)
        {
            query = query.Skip(1).Take(10);
        }

    if (skip.HasValue)
        {
            query = query.Skip(skip.Value);
        }

        if (take.HasValue)
        {
            query = query.Take(take.Value);
        }
        var studentsDto = query.Select(x => new StudentGetAllOutput()
        {
            Name = x.Name,
            SubjectsTaken = x.Subjects.Select(y => y.Name).ToList()
        }).ToList();

        var returned = 
            new GetReturn<StudentGetAllOutput>()
            {
                Items = studentsDto,
                TotalCount = studentsDto.Count

            };

        return returned;
    }

    public Student GetById(Guid id)
    {
        return _applicationDbContext.Students.Find(id);
    }

    public Student Create(StudentDTO studentDto)
    {

        var student = new Student()
        {
            Name = studentDto.Name,
           
        };

        _applicationDbContext.Students.Add(student);
        _applicationDbContext.SaveChanges();

        return student;
    }

    public Student Update(Guid Id , StudentUpdateInput student)
    {
        var existingStudent = _applicationDbContext.Students.Find(Id);
 
            existingStudent.Name = student.Name;
            existingStudent.Subjects = _applicationDbContext.Subjects.Where(x => student.SubjectIds.Any(i => i==x.Id)).ToList();
            _applicationDbContext.SaveChanges();
        
        return existingStudent;
    }

    public void Delete(Guid id)
    {
        var studentToDelete = _applicationDbContext.Students.Find(id);
        if (studentToDelete != null)
        {
            
            _applicationDbContext.Students.Remove(studentToDelete);
            _applicationDbContext.SaveChanges();
        }
    }
}
