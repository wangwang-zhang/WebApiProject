using StudentWebAPI.Models;

namespace StudentWebAPI.Dao;

public interface IStudentDao
{
    public List<Student> GetAll();
    public string AddStudent(Student student);
    public List<Student> DeleteStudent(string id);
    public List<Student> UpdateStudent(string id, string phone, int age);
}