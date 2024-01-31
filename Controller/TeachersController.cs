using Microsoft.AspNetCore.Mvc;
using PostGresAPI.DTOS;
using PostGresAPI.Models;
using PostGresAPI.Repositories;

namespace PostGresAPI.Controllers;

[ApiController]
[Route("api/[controller]")]

public class TeachersController : Controller
{
    private readonly ITeacherRepository _teacherRepository;

    public TeachersController(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var teachers = _teacherRepository.GetAll();
        return Ok(teachers);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
     
        if (_teacherRepository.GetById(id) ==null )
            return NotFound();

        return Ok(_teacherRepository.GetById(id));
    }
    [HttpPost]
    public IActionResult Create([FromBody] TeacherDTO teacherDto)
    {
        if (teacherDto == null)
            return BadRequest("Invalid teacher data.");
        
        var createdTeacher = _teacherRepository.Create(teacherDto);

        return CreatedAtAction(nameof(GetById), new {id = createdTeacher.Id}, createdTeacher);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] TeacherDTO teacherDto)
    {
        if (GetById(id) == null)
            return BadRequest("Invalid student data.");
        
        var teacher = new Teacher()
        {
            Id = id,
            Name = teacherDto.Name,
        };

        var updatedTeacher = _teacherRepository.Update(teacher);

        if (updatedTeacher == null)
            return NotFound(); 
        return Ok(updatedTeacher);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
    _teacherRepository.Delete(id);
        return NoContent();
    }
}