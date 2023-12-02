namespace BL.Students.Domain.Students;

public class Student
{
    public Student(StudentId id, string address, SocialSecurityNumber ssn)
    {
        Id = id;
        Address = address;
        SSN = ssn;
    }

    public StudentId Id { get; private set; }
    public string Address { get; private set; } = string.Empty;
    public SocialSecurityNumber SSN { get; private set; }
}