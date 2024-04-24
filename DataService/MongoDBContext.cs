using Lab2.ModelsMongo;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Lab2.DataService;

public class MongoDBContext
{
    private readonly IMongoCollection<NotificationsType> _NotificationsTypeCollection;
    private readonly IMongoCollection<Notifications> _NotificationsCollection;

    public MongoDBContext(IOptions<MongoDBSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database1 = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _NotificationsTypeCollection = database1.GetCollection<NotificationsType>(mongoDBSettings.Value.CollectionName);
        _NotificationsCollection = database1.GetCollection<Notifications>("Notifications");

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
}
