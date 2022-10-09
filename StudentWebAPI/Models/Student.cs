using System.ComponentModel.DataAnnotations;

namespace StudentWebAPI.Models;

public class Student
{
    public Student(string studentId, string name, string phone, int age)
    {
        StudentId = studentId;
        Name = name;
        Phone = phone;
        Age = age;
    }

    [Required(ErrorMessage = "学号不能为空")]
    public string StudentId { get; set; }
    
    [Required(ErrorMessage = "姓名不能为空")]
    [MaxLength(16, ErrorMessage = "名字最长16个字符")]
    public string Name { get; set; }
    
    [Phone] 
    public string Phone { get; set; }
    
    [Range(6,18, ErrorMessage = "年龄应该在6-18之间")]
    public int Age { get; set; }
    
}