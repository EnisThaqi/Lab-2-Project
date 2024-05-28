using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Lab2.ModelsMongo
{
    public class Notifications
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? NotificationsID { get; set; }

        [BsonElement("Message")]
        public string? Message { get; set; } = null!;

        [BsonElement("CreatedAT")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("NotificationsTypeID")]
        public string? NotificationsTypeID { get; set; }

        [BsonElement("UserID")]
        public int UserID { get; set; }
    }
}
