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
    
    [HttpGet("between")]
    public List<Student> GetStudentsByAgeRange([FromBody] AgeRangeModel ageRangeModel)
    {
        return _studentService.GetStudentBetween(ageRangeModel.MinAge, ageRangeModel.MaxAge);
    }
    
    [HttpGet("prefix/{prefix}")]
    public List<Student> GetStudentsByPhonePrefix([FromRoute] string prefix)
    {
        return _studentService.GetStudentByPhone(prefix);
    }
    
}