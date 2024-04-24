using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Lab2.ModelsMongo
{
    public class Ticket
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? TicketID { get; set; }


        [BsonElement("Subject")]
        public string? Subject { get; set; }

        [BsonElement("Description")]
        public string? Description { get; set; }

        [BsonElement("Status")]
        public string? Status{ get; set; }

        [BsonElement("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("UserID")]
        public int UserID { get; set; }



    }
}
