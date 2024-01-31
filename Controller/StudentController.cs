using Microsoft.AspNetCore.Mvc;
using PostGresAPI.DTOS;
using PostGresAPI.Models;
using PostGresAPI.Repositories;

namespace PostGresAPI.Controllers;

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
    public IActionResult GetAll()
    {
        return Ok(_studentRepository.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        if (_studentRepository.GetById(id) == null)
            return NotFound();
        
        return Ok(_studentRepository.GetById(id));
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
    public IActionResult Update(int id, [FromBody] StudentDTO studentDto)
    {
        if (GetById(id) == null)
            return BadRequest("Invalid student data.");
        
        var student = new Student()
        {
            Id = id,
            Name = studentDto.Name,
        };

        var updatedStudent = _studentRepository.Update(student);

        if (updatedStudent == null)
            return NotFound(); 
        
        return Ok(updatedStudent);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
    _studentRepository.Delete(id);

        return NoContent();
    }
}