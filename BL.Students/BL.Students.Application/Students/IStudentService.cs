using BL.Students.Domain.Students;

namespace BL.Students.Application.Students;

public interface IStudentService
{
    Task<Student?> GetAsync(string id, CancellationToken cancel);
    Task CreateAsync(string name, string address, string ssn, CancellationToken cancel);
    Task<Task> UpdateAsync(string id, string name, string address, string ssn, CancellationToken cancel);
    Task DeleteAsync(string id, CancellationToken cancel);
}
