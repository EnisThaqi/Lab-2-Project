using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Lab2.ModelsMongo
{
    public class UserFeedback
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? FeedbackID { get; set; }

        [BsonElement("Feedback")]
        public string? FeedbackText { get; set; } = null!;

        [BsonElement("FeedbackDate")]
        public DateTime FeedbackDate { get; set; }

        [BsonElement("UserID")]
        public int UserID { get; set; } 
    }
}
