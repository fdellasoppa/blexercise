using BL.Students.Application.Exceptions;
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
        var social = SocialSecurityNumber.Create(ssn);
        if (social is null)
            throw new ApplicationException("Ivalid social security number");

        var student = new Student(
            new StudentId(new Guid()),
            name,
            address,
            social);

        return _studentRepository.AddAsync(student, cancel);
    }

    public Task<Student?> GetAsync(string id, CancellationToken cancel)
    {
        if (string.IsNullOrEmpty(id))
            throw new ArgumentNullException(nameof(id));

        bool valid = Guid.TryParse(id, out Guid guid);
        if (!valid)
            throw new InvalidIdException();

        return _studentRepository.GetAsync(guid, cancel);
    }

    public async Task<Task> UpdateAsync(string id, string name, string address, string ssn, CancellationToken cancel)
    {
        if (string.IsNullOrEmpty(id))
            throw new ArgumentNullException(nameof(id));

        bool valid = Guid.TryParse(id, out Guid guid);
        if (!valid)
            throw new InvalidIdException();

        var student = await _studentRepository.GetAsync(guid, cancel);

        if (student is null)
            throw new ApplicationException("Student not found!");

        var social = SocialSecurityNumber.Create(ssn);
        if (social is null)
            throw new ApplicationException("Ivalid social security number");

        return _studentRepository.UpdateAsync(new Guid(id),
            new Student(student.Id, name, address, social),
            cancel);
    }

    public Task DeleteAsync(string id, CancellationToken cancel)
    {
        if (string.IsNullOrEmpty(id))
            throw new ArgumentNullException(nameof(id));

        bool valid = Guid.TryParse(id, out Guid guid);
        if (!valid)
            throw new InvalidIdException();

        return _studentRepository.DeleteAsync(guid, cancel);
    }
}
