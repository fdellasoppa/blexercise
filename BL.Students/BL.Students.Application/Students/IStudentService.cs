using BL.Students.Domain.Students;

namespace BL.Students.Application.Students;

public interface IStudentService
{
    void Create(string name, string address, string ssn);
}
