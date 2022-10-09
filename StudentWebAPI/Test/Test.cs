
using Moq;
using StudentWebAPI.Dao;
using StudentWebAPI.Models;
using StudentWebAPI.Services;

namespace StudentWebAPI.Test;
using Xunit;

public class Test
{
    [Fact]
    public void Should_Return_Student_By_Id()
    {
        IStudentDao studentDao = new StudentDaoImpl();
        StudentService studentService = new StudentService(studentDao);
        var student = studentService.GetStudentById("1");
        Assert.Equal("Tom",student?.Name);
    }
    
    private readonly List<Student> _students = new List<Student>
    {
        new Student("1", "Tom", "13567845677",10),
        new Student("2", "Amy", "13867045471",28),
    };
    [Fact]
    public void Should_Return_Student_By_Id_Mock()
    {
        var studentDaoMock = new Mock<IStudentDao>();
        studentDaoMock.Setup(studentDao => studentDao.GetAll()).Returns(_students);
        
        StudentService studentService = new StudentService(studentDaoMock.Object);
        var student = studentService.GetStudentById("1");
        
        Assert.Equal("Tom",student?.Name);
    }
}