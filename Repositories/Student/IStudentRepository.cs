using PostGresAPI.DTOS;

namespace PostGresAPI.Repositories;
using PostGresAPI.Models;

public interface IStudentRepository
{
    List<StudentGetAllOutput> GetAll();
    Student GetById(int id);
    Student Create(StudentDTO studentDto);
    Student Update(int id, StudentUpdateInput student);
    void Delete(int id);
}
