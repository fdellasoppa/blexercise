using BL.Students.Domain.Students;

namespace BL.Students.Application.Students;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public void Create(string name, string address, string ssn)
    {
        var student = new Student(
            new StudentId(new Guid()),
            name,
            address,
            SocialSecurityNumber.Create(ssn));

        _studentRepository.Add(student);
    }
}
