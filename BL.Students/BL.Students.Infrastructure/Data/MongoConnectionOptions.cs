namespace BL.Students.Infrastructure.Data;

public class MongoConnectionOptions
{
    public string ConnectionString { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
}