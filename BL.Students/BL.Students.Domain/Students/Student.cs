namespace BL.Students.Domain.Students;

public class Student
{
    public Student(
        StudentId id, 
        string name,
        SocialSecurityNumber ssn) : this(id, name, null, ssn) 
    { }

    public Student(
        StudentId id,
        string name,
        string? address,
        SocialSecurityNumber ssn)
    {
        Id = id;
        Name = name;
        Address = address;
        SSN = ssn;
    }

    public StudentId Id { get; private set; }
    public string Name { get; private set; }
    public string? Address { get; private set; } = null;
    public SocialSecurityNumber SSN { get; private set; }
}