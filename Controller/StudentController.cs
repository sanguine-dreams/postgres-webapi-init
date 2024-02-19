namespace PostGresAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using PostGresAPI.DTOS;
using PostGresAPI.Models;
using PostGresAPI.Repositories;



[ApiController]
[Route("api/[controller]")]

public class StudentsController : Controller
{
    private readonly IStudentRepository _studentRepository;

    public StudentsController(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }


    [HttpGet]
    public IActionResult GetAll(int? skip = null, int? take = null)
    {
        return Ok(_studentRepository.GetAll(skip, take));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var studentId = _studentRepository.GetById(id);
        if (studentId == null)
            return NotFound();
        
        return Ok(studentId);
    }
    
    [HttpPost]
    public IActionResult Create([FromBody] StudentDTO studentDto)
    {
        if (string.IsNullOrEmpty( studentDto.Name?.Trim()))
            return BadRequest("Invalid student data.");

        var createdStudent = _studentRepository.Create(studentDto);

        return CreatedAtAction(nameof(GetById), new { id = createdStudent.Id }  ,createdStudent );
    
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, [FromBody] StudentUpdateInput studentDto)
    {
        if (GetById(id) == null)
            return BadRequest("Invalid student data.");
        
        var updatedStudent = _studentRepository.Update(id, studentDto);

        if (updatedStudent == null)
            return NotFound(); 
        
        return Ok(updatedStudent);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
    _studentRepository.Delete(id);

        return NoContent();
    }
}