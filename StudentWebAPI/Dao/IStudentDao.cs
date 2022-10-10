using StudentWebAPI.Models;
namespace StudentWebAPI.Dao;

public interface IStudentDao
{
    public List<Student> GetAll();
    public List<Student> AddStudent(Student student);
    public List<Student> DeleteStudent(string id);
}