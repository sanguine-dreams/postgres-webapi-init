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
    
    public IEnumerable<GetAllSubjectDTO> GetAll()
    {
        var queryableDto = _applicationDbContext.Subjects
            .Select(x => new GetAllSubjectDTO()
            {
                    Name = x.Name,
                    TaughtBy = x.Teacher.Name,
            });
        
        return queryableDto.ToList();
    }

    public  IEnumerable<GetAllSubjectDTO> SearchSubjectTeacher(string SubjectName, string TeacherName)
    {
        var allsubjects = GetAll();
        var subjects = _applicationDbContext.Subjects
            .Where(subject => subject.Name.Contains(SubjectName) && subject.Teacher.Name.Contains(TeacherName))
            .Select(x => new GetAllSubjectDTO()
            {
                Name = x.Name,
                TaughtBy = x.Teacher.Name
            });
        
        return subjects.ToList();
    }

    public IEnumerable<CreateSubjectDTO> GetById(Guid id)
    {
        var subjects = _applicationDbContext.Subjects.Select(x => new CreateSubjectDTO()
        {
            Id = x.Id,
            Name = x.Name,
            TaughtBy = x.Teacher.Name
        }).Where(x => id == x.Id);
        
        
        return subjects.ToList();
        
    }

    public CreateSubjectDTO Create(SubjectDTO subjectDTO)
    {
        var teacher = _applicationDbContext.Teachers.Find(subjectDTO.TeacherId);
        Console.WriteLine(teacher);
        if (teacher == null)
        {
            throw new Exception("Teacher not found");
        }

        var subject = new Subject()
        {
            
            Name = subjectDTO.Name,
            TeacherId = teacher.Id,
            Teacher = teacher,
        };

        var returnedSubject = new CreateSubjectDTO()
        {
            Id = subject.Id,
            Name = subject.Name,
            TaughtBy = teacher.Name
        };

    _applicationDbContext.Subjects.Add(subject);
         _applicationDbContext.SaveChanges();

        return returnedSubject;
    }


    public IEnumerable<GetAllSubjectDTO> Update(Subject subject)
    {
        var teacher = _applicationDbContext.Teachers.Find(subject.TeacherId);
        if (teacher == null)
        {
            throw new Exception("Teacher not found");
        }

        var existingSubject = _applicationDbContext.Subjects
            .Where(s => s.Id== subject.Id)
            .Select(x => new GetAllSubjectDTO()
            {
                Name = subject.Name,
                TaughtBy = subject.Name,
            });

        _applicationDbContext.SaveChangesAsync();
        return existingSubject.ToList();
    }

    public void Delete(Guid id)
    {
        var subjectToDelete = _applicationDbContext.Subjects.Find(id);
        if (subjectToDelete != null)
        {
            _applicationDbContext.Subjects.Remove(subjectToDelete);
            _applicationDbContext.SaveChangesAsync();
        }
    }
}