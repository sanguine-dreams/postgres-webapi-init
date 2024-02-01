namespace PostGresAPI.Repositories.Subject;
using PostGresAPI.Models;
using PostGresAPI.DTOS;

public interface ISubjectRepository
{
    IEnumerable<Subject> GetAll();
    Subject GetById(int id);
    Subject Create(SubjectDTO studentDto);
    Subject Update(Subject student);
    void Delete(int id);
}