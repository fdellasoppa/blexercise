namespace BL.Students.Domain.Students;

public class Student
{

    public StudentId Id { get; private set; }
    public string Address { get; private set; } = string.Empty;
    public SocialSecurityNumber SSN { get; private set; }
}