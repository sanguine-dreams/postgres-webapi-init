using PostGresAPI.DTOS;

namespace PostGresAPI.Repositories;
using PostGresAPI.Models;

public interface IStudentRepository
{
    IEnumerable<Student> GetAll();
    Student GetById(int id);
    Student Create(StudentDTO studentDto);
    Student Update(Student student);
    void Delete(int id);
}
