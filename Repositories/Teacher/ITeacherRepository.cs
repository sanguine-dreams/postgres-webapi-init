namespace PostGresAPI.Repositories;
using PostGresAPI.Models;
using PostGresAPI.DTOS;

public interface ITeacherRepository
{
    IEnumerable<ReturnTeacherDTO> GetAll();
    IEnumerable<ReturnTeacherDTO> GetById(int id);
    Teacher Create(TeacherDTO teacherDto);
    Teacher Update(Teacher teacher);
    void Delete(int id);
}