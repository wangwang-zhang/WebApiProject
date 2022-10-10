using Newtonsoft.Json;
using StudentWebAPI.Models;

namespace StudentWebAPI.Dao;

public class StudentDaoImpl : IStudentDao
{
    private readonly ILogger _logger;
    
    private readonly List<Student> _students = new List<Student>
    {
        new Student("1", "Tom", "13567845677",10),
        new Student("2", "Amy", "13867045471",28),
        new Student("3", "Cindy", "13854716704",12),
        new Student("4", "David", "13812345678",18),
        new Student("5", "Lucas", "13587653211",15),
        new Student("6", "Henry", "13876666666",16),
    };

    public StudentDaoImpl(ILogger logger)
    {
        _logger = logger;
    }

    public List<Student> GetAll()
    {
        return _students;
    }

    public List<Student> AddStudent(Student student)
    {
        _students.Add(student);
        var studentJsonString = JsonConvert.SerializeObject(student);
        _logger.LogInformation("Have already added a new student: " + studentJsonString);
        return _students;
    }

    public List<Student> DeleteStudent(string id)
    {
        Student student = _students.Find(student => student.StudentId == id);
        _students.Remove(student);
        var studentJsonString = JsonConvert.SerializeObject(student);
        _logger.LogInformation("Have already deleted a new student: " + studentJsonString);
        return _students;
    }
}