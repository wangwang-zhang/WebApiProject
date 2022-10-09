using StudentWebAPI.Models;
namespace StudentWebAPI.Dao;

public class StudentDao
{
    private readonly List<Student> _students = new List<Student>
    {
        new Student("1", "Tom", "13567845677",10),
        new Student("2", "Amy", "13867045471",28),
    };

    public List<Student> GetAll()
    {
        return _students;
    }
}