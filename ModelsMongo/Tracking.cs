using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Lab2.ModelsMongo
{
    public class Tracking
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? TrackingID { get; set; }

        [BsonElement("Status")]
        public string? Status { get; set; } = null!;

        [BsonElement("Location")]
        public string? Location { get; set; } = null!;

        [BsonElement("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }

        [BsonElement("TrackNumber")]
        public string? TrackNumber { get; set; } = null!;

        [BsonElement("OrderID")]
        public string? OrderID { get; set; } 
    }
}
