using StudentWebAPI.Dao;
using StudentWebAPI.Services;

namespace StudentWebAPI.Test;
using Xunit;

public class Test
{
    [Fact]
    public void Should_Return_Student_By_Id()
    {
        StudentDao studentDao = new StudentDao();
        StudentService studentService = new StudentService(studentDao);
        var student = studentService.GetStudentById("1");
        Assert.Equal("Tom",student?.Name);
    }
}