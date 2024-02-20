namespace BL.Students.Application.Students;

public interface IStudentService
{
    Task CreateAsync(string name, string address, string ssn, CancellationToken cancel);
}
