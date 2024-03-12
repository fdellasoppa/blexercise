using BL.Students.Application.Abstractions;
using BL.Students.Application.Exceptions;
using BL.Students.Domain.Students;

namespace BL.Students.Application.Students;

public class StudentService(IStudentRepository studentRepository) : IStudentService
{
    public async Task<Result<StudentId>> CreateAsync(string name, string address, string ssn, CancellationToken cancel)
    {
        var social = SocialSecurityNumber.Create(ssn);
        if (social is null)
            return Result<StudentId>.Failure(StudentErrors.InvalidSSN);
            //throw new ApplicationException("Ivalid social security number");

        var student = new Student(
            new StudentId(Guid.NewGuid()),
            name,
            address,
            social);

        await studentRepository.AddAsync(student, cancel);

        return Result<StudentId>.Success(student.Id);
    }

    public Task<Student?> GetAsync(string id, CancellationToken cancel)
    {
        if (string.IsNullOrEmpty(id))
            throw new ArgumentNullException(nameof(id));

        bool valid = Guid.TryParse(id, out Guid guid);
        if (!valid)
            throw new InvalidIdException();

        return studentRepository.GetAsync(guid, cancel);
    }

    public async Task<Task> UpdateAsync(string id, string name, string address, string ssn, CancellationToken cancel)
    {
        if (string.IsNullOrEmpty(id))
            throw new ArgumentNullException(nameof(id));

        bool valid = Guid.TryParse(id, out Guid guid);
        if (!valid)
            throw new InvalidIdException();

        var student = await studentRepository.GetAsync(guid, cancel);

        if (student is null)
            throw new ApplicationException("Student not found!");

        var social = SocialSecurityNumber.Create(ssn);
        if (social is null)
            throw new ApplicationException("Ivalid social security number");

        return studentRepository.UpdateAsync(new Guid(id),
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

        return studentRepository.DeleteAsync(guid, cancel);
    }

    public async Task<Result<List<Student>>> GetAllAsync(CancellationToken cancel)
    {
        var res = await studentRepository.GetAllAsync(cancel);
        return Result<List<Student>>.Success(res);
    }
}
