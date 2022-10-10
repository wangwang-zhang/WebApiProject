
using Moq;
using StudentWebAPI.Dao;
using StudentWebAPI.Models;
using StudentWebAPI.Services;

namespace StudentWebAPI.Test;
using Xunit;

public class Test
{

    private readonly List<Student> _students = new List<Student>
    {
        new Student("1", "Tom", "13567845677",10),
        new Student("2", "Amy", "13867045471",28),
        new Student("3", "Cindy", "13567352398", 30),
        new Student("4", "David", "13967152312", 15),
        new Student("5", "David", "18765492546", 16)
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

    [Fact]
    public void should_Return_Student_List_between_10_And_16()
    {
        var studentDaoMock = new Mock<IStudentDao>();
        studentDaoMock.Setup(studentDao => studentDao.GetAll()).Returns(_students);
        
        StudentService studentService = new StudentService(studentDaoMock.Object);
        List<Student> student = studentService.GetStudentBetween(10,16);
        
        Assert.Equal(3,student.Count);
    }
    
    [Fact]
    public void should_Return_Student_List_Whose_Phone_Begin_With_135()
    {
        var studentDaoMock = new Mock<IStudentDao>();
        studentDaoMock.Setup(studentDao => studentDao.GetAll()).Returns(_students);
        
        StudentService studentService = new StudentService(studentDaoMock.Object);
        List<Student> student = studentService.GetStudentByPhone("135");
        
        Assert.Equal(2,student.Count);
    }
    
    [Fact]
    public void should_Return_New_Student_List_When_Added_New_Student()
    {
        Student student = new Student("6", "Phil", "13467529087", 19);
        _students.Add(student);
        
        var studentDaoMock = new Mock<IStudentDao>();
        studentDaoMock.Setup(studentDao => studentDao.AddStudent(It.IsAny<Student>())).Returns(_students);

        StudentService studentService = new StudentService(studentDaoMock.Object);
       
        List<Student> students = studentService.AddStudent(student);
        
        Assert.Equal(6,students.Count);
    }

    [Fact]
    public void Should_Return_All_Students()
    {
        var studentDaoMock = new Mock<IStudentDao>();
        studentDaoMock.Setup(studentDao => studentDao.GetAll()).Returns(_students);
        StudentService studentService = new StudentService(studentDaoMock.Object);
        List<Student> students = studentService.GetAllStudents();
        Assert.Equal(5, students.Count);
    }
    
}