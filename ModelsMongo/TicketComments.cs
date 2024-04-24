using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;


namespace Lab2.ModelsMongo
{
    public class TicketComments
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? TicketCommentsID { get; set; }

        [BsonElement("Comment")]
        public string? Comment { get; set; }

        [BsonElement("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("TicketID")]
        public string TicketID { get; set; }

        [BsonElement("UserID")]
        public int UserID { get; set; }

    }

     
}
