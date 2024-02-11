using PostGresAPI.DTOS;
using PostGresAPI.Models;

namespace PostGresAPI.Controllers;

using PostGresAPI.Repositories.Subject;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SubjectController : Controller
{
    private readonly ISubjectRepository _subjectRepository;

    public SubjectController(ISubjectRepository subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_subjectRepository.GetAll());
    }

    [HttpGet("{SubjectName}, {TeacherName}")]

    public IActionResult searchTeacherSubject(string SubjectName, string TeacherName)
    {
        
        return Ok(_subjectRepository.SearchSubjectTeacher(SubjectName, TeacherName));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var subjectId = _subjectRepository.GetById((id));
        if (subjectId == null)
            return NotFound();
        return Ok(subjectId);
    }

    [HttpPost]
    public IActionResult Create([FromBody] SubjectDTO subjectDto)
    {
        if (string.IsNullOrEmpty(subjectDto.Name?.Trim()))
            return BadRequest(error: "Invalid subject data.");
        var createdSubject =  _subjectRepository.Create(subjectDto);

        return CreatedAtAction(nameof(GetById), new { id = createdSubject.Id }, createdSubject); 
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] SubjectDTO subjectDto)
    {
        if (GetById(id) == null)
            return BadRequest(error: "Invalid Subject data.");
        var subject = new Subject()
        {
            Id = id,
            Name = subjectDto.Name

        };
        var updatedSubject = _subjectRepository.Update(subject);
        if (updatedSubject == null)
            return NotFound();
        return Ok(updatedSubject);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _subjectRepository.Delete(id);
        return NoContent();
    }
}