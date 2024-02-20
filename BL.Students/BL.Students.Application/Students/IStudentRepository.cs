using BL.Students.Domain.Students;

namespace BL.Students.Application.Students;

public interface IStudentRepository
{
    Task AddAsync(Student student, CancellationToken cancel);
    Task<Student?> GetAsync(Guid id, CancellationToken cancel);
    Task DeleteAsync(Guid id, CancellationToken cancel);
}