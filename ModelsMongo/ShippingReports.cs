using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Lab2.ModelsMongo
{
    public class ShippingReport
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ReportID { get; set; }

        [BsonElement("DeliveryTime")]
        public TimeSpan DeliveryTime { get; set; }

        [BsonElement("DeliveryDate")]
        public DateTime DeliveryDate { get; set; }

        [BsonElement("Status")]
        public string? Status { get; set; } 

        [BsonElement("UserID")]
        public int UserID { get; set; }
    }
}
