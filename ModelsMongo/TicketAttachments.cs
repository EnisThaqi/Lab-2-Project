using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;


namespace Lab2.ModelsMongo
{
    public class TicketAttachments
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? TicketAttachmentsID { get; set; }

        [BsonElement("File")]
        public byte[] File { get; set; } = null;

        [BsonElement("Description")]
        public string? Description { get; set; }


        [BsonElement("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("TicketID")]
        public string TicketID { get; set; }

        

    }


}
