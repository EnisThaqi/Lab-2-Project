using Lab2.ModelsMongo;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab2.DataService;

public class MongoDBContext
{
    private readonly IMongoCollection<NotificationsType> _NotificationsTypeCollection;
    private readonly IMongoCollection<Notifications> _NotificationsCollection;
    private readonly IMongoCollection<UserNotifications> _UserNotificationsCollection;
    private readonly IMongoCollection<Ticket> _TicketCollection;
    private readonly IMongoCollection<TicketComments> _TicketCommentsCollection;
    private readonly IMongoCollection<TicketAttachments> _TicketAttachmentsCollection;
    private readonly IMongoCollection<UserFeedback> _UserFeedbackCollection;
    private readonly IMongoCollection<ShippingReport> _ShippingReportCollection;
    private readonly IMongoCollection<Tracking> _TrackingCollection;
    public MongoDBContext(IOptions<MongoDBSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database1 = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _NotificationsTypeCollection = database1.GetCollection<NotificationsType>(mongoDBSettings.Value.CollectionName);
        _NotificationsCollection = database1.GetCollection<Notifications>("Notifications");
        _UserNotificationsCollection = database1.GetCollection<UserNotifications>("UserNotifications");
        _TicketCollection = database1.GetCollection<Ticket>(mongoDBSettings.Value.CollectionName);
        _TicketCommentsCollection = database1.GetCollection<TicketComments>("TicketComments");
        _TicketAttachmentsCollection = database1.GetCollection<TicketAttachments>("TicketAttachments");
        _UserFeedbackCollection = database1.GetCollection<UserFeedback>("UserFeedback");
        _ShippingReportCollection = database1.GetCollection<ShippingReport>("ShippingReport");
        _TrackingCollection = database1.GetCollection<Tracking>("Tracking");

    }
    public async Task CreateAsync(NotificationsType notificationsType)
    {
        await _NotificationsTypeCollection.InsertOneAsync(notificationsType);
        return;
    }

    public async Task<List<NotificationsType>> GetAsync()
    {
        return await _NotificationsTypeCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task AddToNotificationsTypeAsync(string NotificationsTypeID, string? TypeName)
    {
        FilterDefinition<NotificationsType> filter = Builders<NotificationsType>.Filter.Eq("NotificationsTypeID", NotificationsTypeID);
        UpdateDefinition<NotificationsType> update = Builders<NotificationsType>.Update.Set("TypeName", TypeName);
        await _NotificationsTypeCollection.UpdateOneAsync(filter, update);
        return;
    }

    public async Task DeleteAsync(string NotificaitionsTypeID)
    {
        FilterDefinition<NotificationsType> filter = Builders<NotificationsType>.Filter.Eq("NotificationsTypeId", NotificaitionsTypeID);
        await _NotificationsTypeCollection.DeleteOneAsync(filter);
        return;
    }

    //Notifications
    public async Task CreateNotificationsAsync(Notifications notifications)
    {
        await _NotificationsCollection.InsertOneAsync(notifications);
        return;
    }

    public async Task<List<Notifications>> GetNotificationsAsync()
    {
        return await _NotificationsCollection.Find(new BsonDocument()).ToListAsync();
    }
    public async Task<Notifications> GetNotificationsByIDAsync(string notificationsID)
    {
        return await _NotificationsCollection.Find(x => x.NotificationsID == notificationsID).FirstOrDefaultAsync();
    }

    public async Task UpdateNotificationsAsync(string notificationsID, UpdateDefinition<Notifications> update)
    {
        await _NotificationsCollection.UpdateOneAsync(
            Builders<Notifications>.Filter.Eq("NotificationsID", notificationsID), update);
    }

    public async Task DeleteNotificationsAsync(string notificationsID)
    {
        await _NotificationsCollection.DeleteOneAsync(Builders<Notifications>.Filter.Eq("NotificationID", notificationsID));
        return;
    }

    //UserNotifications
    public async Task CreateUserNotificationsAsync(UserNotifications usernotifications)
    {
        await _UserNotificationsCollection.InsertOneAsync(usernotifications);
        return;
    }

    public async Task<List<UserNotifications>> GetUserNotificationsAsync()
    {
        return await _UserNotificationsCollection.Find(new BsonDocument()).ToListAsync();
    }
    public async Task<UserNotifications> GetUserNotificationsByIDAsync(string usernotificationsID)
    {
        return await _UserNotificationsCollection.Find(x => x.UserNotificationsID == usernotificationsID).FirstOrDefaultAsync();
    }

    public async Task UpdateUserNotificationsAsync(string usernotificationsID, UpdateDefinition<UserNotifications> update)
    {
        await _UserNotificationsCollection.UpdateOneAsync(
            Builders<UserNotifications>.Filter.Eq("UserNotificationsID", usernotificationsID), update);
    }

    public async Task DeleteUserNotificationsAsync(string usernotificationsID)
    {
        await _UserNotificationsCollection.DeleteOneAsync(Builders<UserNotifications>.Filter.Eq("UserNotificationID", usernotificationsID));
        return;
    }

    //Ticket

    public async Task CreateTicketAsync(Ticket ticket)
    {
        await _TicketCollection.InsertOneAsync(ticket);
        return;
    }

    public async Task<List<Ticket>> GetTicketAsync()
    {
        return await _TicketCollection.Find(new BsonDocument()).ToListAsync();
    }
    public async Task<Ticket> GetTicketByIDAsync(string ticketID)
    {
        return await _TicketCollection.Find(x => x.TicketID == ticketID).FirstOrDefaultAsync();
    }
    public async Task UpdateTicketAsync(string ticketID, UpdateDefinition<Ticket> update)
    {
        await _TicketCollection.UpdateOneAsync(
            Builders<Ticket>.Filter.Eq("TicketID", ticketID), update);
    }
    public async Task DeleteTicketAsync(string ticketID)
    {
        await _TicketCollection.DeleteOneAsync(Builders<Ticket>.Filter.Eq("TicketID", ticketID));
        return;
    }

    //TicketComments

    public async Task CreateTicketCommentsAsync(TicketComments ticketcomments)
    {
        await _TicketCommentsCollection.InsertOneAsync(ticketcomments);
        return;
    }
    public async Task<List<TicketComments>> GetTicketCommentsAsync()
    {
        return await _TicketCommentsCollection.Find(new BsonDocument()).ToListAsync();
    }
    public async Task<TicketComments> GetTicketCommentsByIDAsync(string ticketcommentsID)
    {
        return await _TicketCommentsCollection.Find(x => x.TicketCommentsID == ticketcommentsID).FirstOrDefaultAsync();
    }
    public async Task UpdateTicketCommentsAsync(string ticketcommentsID, UpdateDefinition<TicketComments> update)
    {
        await _TicketCommentsCollection.UpdateOneAsync(
            Builders<TicketComments>.Filter.Eq("TicketCommentsID", ticketcommentsID), update);
    }
    public async Task DeleteTicketCommentsAsync(string ticketcommentsID)
    {
        await _TicketCommentsCollection.DeleteOneAsync(Builders<TicketComments>.Filter.Eq("TicketCommentsID", ticketcommentsID));
        return;
    }

    //TicketAttachments
    public async Task CreateTicketAttachmentsAsync(TicketAttachments ticketattachments)
    {
        await _TicketAttachmentsCollection.InsertOneAsync(ticketattachments);
        return;
    }
    public async Task<List<TicketAttachments>> GetTicketAttachmentsAsync()
    {
        return await _TicketAttachmentsCollection.Find(new BsonDocument()).ToListAsync();
    }
    public async Task<TicketAttachments> GetTicketAttachmentsByIDAsync(string ticketattachmentsID)
    {
        return await _TicketAttachmentsCollection.Find(x => x.TicketAttachmentsID == ticketattachmentsID).FirstOrDefaultAsync();
    }
    public async Task AddToTicketAttachmentsAsync(string TicketAttachmentsID, byte[] File, string? Description,DateTime CreatedAt)
    {
        FilterDefinition<TicketAttachments> filter = Builders<TicketAttachments>.Filter.Eq("TicketAttachmentsID", TicketAttachmentsID);
        UpdateDefinition<TicketAttachments> update = Builders<TicketAttachments>.Update
            .Set("File", File)
            .Set("Description", Description)
            .Set("CreatedAt", CreatedAt);



        await _TicketAttachmentsCollection.UpdateOneAsync(filter, update);
        return;
    }
    public async Task DeleteTicketAttachmentsAsync(string ticketattachmentsID)
    {
        await _TicketAttachmentsCollection.DeleteOneAsync(Builders<TicketAttachments>.Filter.Eq("TicketAttachmentsID", ticketattachmentsID));
        return;
    }

    // UserFeedback
    public async Task CreateUserFeedbackAsync(UserFeedback userFeedback)
    {
        await _UserFeedbackCollection.InsertOneAsync(userFeedback);
    }

    public async Task<List<UserFeedback>> GetUserFeedbackAsync()
    {
        return await _UserFeedbackCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<UserFeedback> GetUserFeedbackByIDAsync(string feedbackID)
    {
        return await _UserFeedbackCollection.Find(x => x.FeedbackID == feedbackID).FirstOrDefaultAsync();
    }

    public async Task UpdateUserFeedbackAsync(string feedbackID, UpdateDefinition<UserFeedback> update)
    {
        await _UserFeedbackCollection.UpdateOneAsync(
            Builders<UserFeedback>.Filter.Eq("FeedbackID", feedbackID), update);
    }

    public async Task DeleteUserFeedbackAsync(string feedbackID)
    {
        await _UserFeedbackCollection.DeleteOneAsync(
            Builders<UserFeedback>.Filter.Eq("FeedbackID", feedbackID));
    }

    // ShippingReport
    public async Task CreateShippingReportAsync(ShippingReport shippingReport)
    {
        await _ShippingReportCollection.InsertOneAsync(shippingReport);
    }

    public async Task<List<ShippingReport>> GetShippingReportAsync()
    {
        return await _ShippingReportCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<ShippingReport> GetShippingReportByIDAsync(string reportID)
    {
        return await _ShippingReportCollection.Find(x => x.ReportID == reportID).FirstOrDefaultAsync();
    }

    public async Task UpdateShippingReportAsync(string reportID, UpdateDefinition<ShippingReport> update)
    {
        await _ShippingReportCollection.UpdateOneAsync(
            Builders<ShippingReport>.Filter.Eq("ReportID", reportID), update);
    }

    public async Task DeleteShippingReportAsync(string reportID)
    {
        await _ShippingReportCollection.DeleteOneAsync(
            Builders<ShippingReport>.Filter.Eq("ReportID", reportID));
    }

    // Tracking
    public async Task CreateTrackingAsync(Tracking tracking)
    {
        await _TrackingCollection.InsertOneAsync(tracking);
    }

    public async Task<List<Tracking>> GetTrackingAsync()
    {
        return await _TrackingCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<Tracking> GetTrackingByIDAsync(string trackingID)
    {
        return await _TrackingCollection.Find(x => x.TrackingID == trackingID).FirstOrDefaultAsync();
    }

    public async Task UpdateTrackingAsync(string trackingID, UpdateDefinition<Tracking> update)
    {
        await _TrackingCollection.UpdateOneAsync(
            Builders<Tracking>.Filter.Eq("TrackingID", trackingID), update);
    }

    public async Task DeleteTrackingAsync(string trackingID)
    {
        await _TrackingCollection.DeleteOneAsync(
            Builders<Tracking>.Filter.Eq("TrackingID", trackingID));
    }
}