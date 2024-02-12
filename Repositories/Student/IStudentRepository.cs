using PostGresAPI.DTOS;

namespace PostGresAPI.Repositories;
using PostGresAPI.Models;

public interface IStudentRepository
{
    List<StudentGetAllOutput> GetAll();
    Student GetById(Guid id);
    Student Create(StudentDTO studentDto);
    Student Update(Guid id, StudentUpdateInput student);
    void Delete(Guid id);
}
