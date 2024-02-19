namespace PostGresAPI.Repositories.Subject;
using PostGresAPI.Models;
using PostGresAPI.DTOS;

public interface ISubjectRepository
{
    GetReturn<GetAllSubjectDTO> GetAll(int? skip = null, int? take = null);
    IEnumerable<GetAllSubjectDTO> SearchSubjectTeacher(string? SubjectName, string? TeacherName);
    IEnumerable<CreateSubjectDTO> GetById(Guid id);
    Subject Create(SubjectDTO studentDto);
    IEnumerable<GetAllSubjectDTO> Update(Subject student);
    void Delete(Guid id);
}