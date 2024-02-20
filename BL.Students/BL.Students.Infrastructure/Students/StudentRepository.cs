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

    public Task AddAsync(Student student, CancellationToken cancel)
    {
        return _mongoDbContext.GetCollection<Student>(CollectionName)
            .InsertOneAsync(student, null, cancel);
    }

    public async Task<Student?> GetAsync(Guid id, CancellationToken cancel)
    {
        return (await _mongoDbContext.GetCollection<Student>(CollectionName)
            .FindAsync(s => s.Id == new StudentId(id),
            null,
            cancel)).FirstOrDefault(cancel);
    }

    public Task UpdateAsync(Guid id, Student student, CancellationToken cancel)
    {
        return _mongoDbContext.GetCollection<Student>(CollectionName)
            .FindOneAndReplaceAsync(s => s.Id == new StudentId(id)
            , student, null, cancel);
    }

    public Task DeleteAsync(Guid id, CancellationToken cancel)
    {
        return _mongoDbContext.GetCollection<Student>(CollectionName)
            .DeleteManyAsync(s => s.Id == new StudentId(id),
            cancel);
    }
}