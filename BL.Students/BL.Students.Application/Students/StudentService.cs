using BL.Students.Domain.Students;

namespace BL.Students.Application.Students;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public Task CreateAsync(string name, string address, string ssn, CancellationToken cancel)
    {
        var student = new Student(
            new StudentId(new Guid()),
            name,
            address,
            SocialSecurityNumber.Create(ssn));

        return _studentRepository.AddAsync(student, cancel);
    }
}
