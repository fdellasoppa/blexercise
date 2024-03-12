using BL.Students.Application.Students;
using BL.Students.Domain.Students;
using BL.Students.Infrastructure.Data;
using MongoDB.Driver;

namespace BL.Students.Infrastructure.Students;

public class StudentRepository(IMongoDbContext mongoDbContext) : IStudentRepository
{
    private const string CollectionName = nameof(Student);

    public Task AddAsync(Student student, CancellationToken cancel)
    {
        return mongoDbContext.GetCollection<Student>(CollectionName)
                .InsertOneAsync(student, null, cancel);
    }

    public Task<Student?> GetAsync(StudentId id, CancellationToken cancel)
    {
        return mongoDbContext.GetCollection<Student?>(CollectionName)
            .Find(Builders<Student?>.Filter.Where(s => s!.Id == id))
            .FirstOrDefaultAsync(cancel);
    }

    public Task UpdateAsync(StudentId id, Student student, CancellationToken cancel)
    {
        return mongoDbContext.GetCollection<Student>(CollectionName)
            .FindOneAndReplaceAsync(s => s.Id == id
            , student, null, cancel);
    }

    public Task DeleteAsync(StudentId id, CancellationToken cancel)
    {
        return mongoDbContext.GetCollection<Student>(CollectionName)
            .DeleteManyAsync(s => s.Id == id,
            cancel);
    }

    public Task<List<Student>> GetAllAsync(CancellationToken cancel)
    {
        return mongoDbContext.GetCollection<Student>(CollectionName)
            .Find(Builders<Student>.Filter.Empty).ToListAsync(cancel);
    }
}