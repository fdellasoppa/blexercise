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

    public Task<Student?> GetAsync(string id, CancellationToken cancel)
    {
        return _studentRepository.GetAsync(new Guid(id), cancel);
    }

    public async Task<Task> UpdateAsync(string id, string name, string address, string ssn, CancellationToken cancel)
    {
        var student = await _studentRepository.GetAsync(new Guid(id), cancel);

        if (student is null)
            throw new ApplicationException("Student not found!");

        return _studentRepository.UpdateAsync(new Guid(id),
            new Student(student.Id, name, address, SocialSecurityNumber.Create(ssn)),
            cancel);
    }

    public Task DeleteAsync(string id, CancellationToken cancel)
    {
        return _studentRepository.DeleteAsync(new Guid(id), cancel);
    }
}
