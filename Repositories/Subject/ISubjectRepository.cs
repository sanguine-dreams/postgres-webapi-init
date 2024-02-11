namespace PostGresAPI.Repositories.Subject;
using PostGresAPI.Models;
using PostGresAPI.DTOS;

public interface ISubjectRepository
{
    IEnumerable<GetAllSubjectDTO> GetAll();
    IEnumerable<GetAllSubjectDTO> SearchSubjectTeacher(string? SubjectName, string? TeacherName);
    IEnumerable<CreateSubjectDTO> GetById(int id);
    CreateSubjectDTO Create(SubjectDTO studentDto);
    IEnumerable<GetAllSubjectDTO> Update(Subject student);
    void Delete(int id);
}