
using StudentWebAPI.Dao;
using StudentWebAPI.Models;

namespace StudentWebAPI.Services;

public class StudentService
{
    private readonly StudentDao _studentDao;


    public StudentService(StudentDao studentDao)
    {
        _studentDao = studentDao;
    }

    public Student? GetStudentById(string id)
    {
        return _studentDao.GetAll().Find(student => student.StudentId == id);
    }
    
}