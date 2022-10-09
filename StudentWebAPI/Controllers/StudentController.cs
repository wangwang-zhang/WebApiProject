using Microsoft.AspNetCore.Mvc;
using StudentWebAPI.Models;
using StudentWebAPI.Services;

namespace StudentWebAPI.Controllers;

[ApiController]
[Route("[Controller]")]
public class StudentController : ControllerBase
{
    private readonly StudentService _studentService;
    
    public StudentController(StudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet("{id}")]
    public Student? Get([FromRoute] string id)
    {
        return _studentService.GetStudentById(id);
    }
    
}