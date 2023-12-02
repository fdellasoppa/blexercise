using BL.Students.Application.Students;
using BL.Students.Domain.Students;
using BL.Students.Infrastructure.Data;
using MongoDB.Driver;

namespace BL.Students.Infrastructure.Students;

public class StudentRepository : IStudentRepository
{
    private const string CollectionName = nameof(Student);

    private readonly IMongoDbContext _mongoDbContext;

    public StudentRepository(IMongoDbContext mongoDbContext)
    {
        _mongoDbContext = mongoDbContext;
    }

    public void Add(Student student)
    {
        _mongoDbContext.GetCollection<Student>(CollectionName).InsertOne(student);
    }

    public Student? Get(Guid id)
    {
        return _mongoDbContext.GetCollection<Student>(CollectionName)
            .AsQueryable()
            .FirstOrDefault(s => s.Id == new StudentId(id));
    }

    public bool Delete(Guid id)
    {
        var result = _mongoDbContext.GetCollection<Student>(CollectionName)
            .DeleteMany(s => s.Id == new StudentId(id));
        return result.DeletedCount > 0;
    }
}