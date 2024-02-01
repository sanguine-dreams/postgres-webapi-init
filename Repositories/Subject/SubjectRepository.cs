namespace PostGresAPI.Repositories.Subject;
using PostGresAPI.Data;
using PostGresAPI.DTOS;
using PostGresAPI.Models;



public class SubjectRepository : ISubjectRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public SubjectRepository(ApplicationDbContext context)
    {
        _applicationDbContext = context;
    }
    
    public IEnumerable<Subject> GetAll()
    {
        return _applicationDbContext.Subjects.ToList();
    }

    public Subject GetById(int id)
    {
        return _applicationDbContext.Subjects.Find(id);
        
    }

    public Subject Create(SubjectDTO studentDto, Teacher teacher)
    {
        long generateId = _applicationDbContext.Subjects.LongCount() + 1;
        var subject = new Subject()
        {
            Id = (int)generateId,
            Name = studentDto.Name,
            TeacherId = teacher.Id, 
        };

        _applicationDbContext.Subjects.AddAsync(subject);
        _applicationDbContext.SaveChangesAsync();

        return subject;
    }

    public Subject Update(Subject subject)
    {
        var existingSubject = _applicationDbContext.Subjects.Find(subject.Id);
        existingSubject.Name = subject.Name;

        _applicationDbContext.SaveChangesAsync();
        return existingSubject;
    }

    public void Delete(int id)
    {
        var subjectToDelete = _applicationDbContext.Subjects.Find(id);
        if (subjectToDelete != null)
        {
            _applicationDbContext.Subjects.Remove(subjectToDelete);
            _applicationDbContext.SaveChangesAsync();
        }
    }
}