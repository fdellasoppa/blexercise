using BL.Students.Domain.Students;

namespace BL.Students.Application.Students;

public interface IStudentRepository
{
    Task AddAsync(Student student, CancellationToken cancel);
    Task<Student?> GetAsync(StudentId id, CancellationToken cancel);
    Task<List<Student>> GetAllAsync(CancellationToken cancel);
    Task UpdateAsync(StudentId id, Student student, CancellationToken cancel);
    Task DeleteAsync(StudentId id, CancellationToken cancel);
}