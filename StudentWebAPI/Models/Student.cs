using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;

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

    [Required(ErrorMessage = "Student id cannot be empty!")]
    public string StudentId { get; set; }
    
    [Required(ErrorMessage = "Name cannot be empty")]
    [MaxLength(16, ErrorMessage = "Name length cannot beyond 16 chars")]
    public string Name { get; set; }
    
    [Phone(ErrorMessage = "it's not phone number")]
    [RegularExpression("^((13[0-9])|(15[^4,\\D])|(18[0,0-9]))\\d{8}$", ErrorMessage = "Can't identify phone number")]
    public string Phone { get; set; }
    
    [Range(6,18, ErrorMessage = "Age should be between 6 and 18")]
    public int Age { get; set; }
    
}