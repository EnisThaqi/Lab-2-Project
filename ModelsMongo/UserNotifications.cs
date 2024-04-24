using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Lab2.ModelsMongo
{
    public class UserNotifications
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? UserNotificationsID { get; set; }

        [BsonElement("Viewed")]
        public bool Viewed { get; set; }

        [BsonElement("Dismissed")]
        public bool Dismissed { get; set; }

        [BsonElement("NotificationsID")]
        public string? NotificationsID { get; set; }

        [BsonElement("UserID")]
        public int UserID { get; set; }
    }
}
