using MongoDB.Bson.Serialization.Attributes;

namespace BL.Students.Domain.Students;

// TODO: I don't like the Mongo reference here,
// need to find away to configure mapping at the infrastructure layer
[BsonIgnoreExtraElements]
public record StudentId(Guid Guid)
{
    public static implicit operator Guid(StudentId d) => d.Guid;
    public static implicit operator StudentId(Guid d) => new(d);
};
