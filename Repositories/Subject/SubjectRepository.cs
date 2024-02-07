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

    public Subject Create(SubjectDTO subjectDTO)
    {
        long generateId = _applicationDbContext.Subjects.LongCount() + 1;
        var teacher =  _applicationDbContext.Teachers.Find(subjectDTO.teacherId);
Console.WriteLine(teacher);
        if (teacher == null)
        {
            throw new Exception("Teacher not found");
        }

        var subject = new Subject()
        {
            Id = (int)generateId,
            Name = subjectDTO.Name,
            Teacher = teacher,
        };

        

     _applicationDbContext.Subjects.Add(subject);
         _applicationDbContext.SaveChanges();

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