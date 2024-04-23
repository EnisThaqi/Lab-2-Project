using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

public class NotificationsType
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? NotificationsTypeID { get; set; }

    [BsonElement("TypeName")]
    public string? TypeName { get; set; } = null!;
}
