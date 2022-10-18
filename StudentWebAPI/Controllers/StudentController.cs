using Microsoft.AspNetCore.Mvc;
using StudentWebAPI.Models;
using StudentWebAPI.Services;

namespace StudentWebAPI.Controllers;

[ApiController]
[Route("/Students")]
public class StudentController : ControllerBase
{
    private readonly StudentService _studentService;

    public StudentController(StudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] string id)
    {
        var students = _studentService.GetStudentById(id);
        if (students == null)
            return NotFound();
        return Ok(students);
    }

    [HttpGet("ageRange")]
    public List<Student> GetStudentsByAgeRange([FromBody] AgeRangeModel ageRangeModel)
    {
        return _studentService.GetStudentBetween(ageRangeModel.MinAge, ageRangeModel.MaxAge);
    }

    [HttpGet("prefix/{prefix}")]
    public IActionResult GetStudentsByPhonePrefix([FromRoute] string prefix)
    {
        List<Student> students = _studentService.GetStudentByPhone(prefix);
        if (students.Count == 0)
        {
            return NotFound();
        }

        return Ok(students);
    }

    [HttpPost]
    public string AddStudent([FromBody] Student student)
    {
        return _studentService.AddStudent(student);
    }

    [HttpGet]
    public List<Student> GetAll()
    {
        return _studentService.GetAllStudents();
    }

    [HttpDelete("{id}")]
    public List<Student> DeleteStudent(string id)
    {
        return _studentService.DeleteStudent(id);
    }

    [HttpPut]
    public List<Student> UpdateStudent([FromBody] Student student)
    {
        return _studentService.UpdateStudent(student.StudentId, student.Phone, student.Age);
    }
}