
using StudentWebAPI.Dao;
using StudentWebAPI.Models;

namespace StudentWebAPI.Services;

public class StudentService
{
    private readonly IStudentDao _studentDao;


    public StudentService(IStudentDao studentDao)
    {
        _studentDao = studentDao;
    }

    public Student? GetStudentById(string id)
    {
        return _studentDao.GetAll().Find(student => student.StudentId == id);
    }

    public List<Student> GetStudentBetween(int beginAge, int endAge)
    {
        return _studentDao.GetAll().FindAll(student => student.Age >= beginAge && student.Age <= endAge);
    }

    public List<Student> GetStudentByPhone(string prefix)
    {
        return _studentDao.GetAll().FindAll(student => student.Phone.StartsWith(prefix));
    }

    public List<Student> AddStudent(Student student)
    {
        return _studentDao.AddStudent(student);
    }
    
    public List<Student> GetAllStudents()
    {
        return _studentDao.GetAll();
    }

    public List<Student> DeleteStudent(String id)
    {
        return _studentDao.DeleteStudent(id);
    }
}