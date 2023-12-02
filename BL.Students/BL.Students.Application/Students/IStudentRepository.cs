using BL.Students.Domain.Students;

namespace BL.Students.Application.Students;

public interface IStudentRepository
{
    void Add(Student student);
    Student? Get(Guid id);
    bool Delete(Guid id);
}