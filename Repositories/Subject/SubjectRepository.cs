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
    
    public GetReturn<GetAllSubjectDTO> GetAll(int? skip = null, int? take = null)
    {
        var query = _applicationDbContext.Subjects.AsQueryable();
        if (skip == null || take == null)
        {
            query = query.Skip(1).Take(10);
        }

        if (skip.HasValue)
        {
            query = query.Skip(skip.Value);
        }

        if (take.HasValue)
        {
            query = query.Take(take.Value);
        }
        
      var subjectsAll = query.Select(x => new GetAllSubjectDTO()
            {
                    Name = x.Name,
                    TaughtBy = x.Teacher.Name,
            }).ToList();

            var returned =
                new GetReturn<GetAllSubjectDTO>()
            {
                Items = subjectsAll,
                TotalCount = query.Count()
            };
        
        return returned;
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

    public Subject Create(SubjectDTO subjectDTO)
    {
      

        var subject = new Subject()
        {
            
            Name = subjectDTO.Name,
            
        };

    _applicationDbContext.Subjects.Add(subject);
         _applicationDbContext.SaveChanges();

        return subject;
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