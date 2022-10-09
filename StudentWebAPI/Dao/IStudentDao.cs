using StudentWebAPI.Models;
namespace StudentWebAPI.Dao;

public interface IStudentDao
{
    public List<Student> GetAll();
}