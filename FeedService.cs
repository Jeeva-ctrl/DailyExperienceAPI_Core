
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using DailyExperienceApi.Models;
namespace DailyExperienceApi.Services
{
    public class FeedService
    {
        private readonly IMongoCollection<Feed> _feed;

        public FeedService(IUserDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _feed = database.GetCollection<Feed>(settings.FeedCollectionName);
        }

        public List<Feed> Get() =>
            _feed.Find(feed => true).ToList();

            public Feed Get(string id) =>
            _feed.Find<Feed>(user => user.Id == id).FirstOrDefault();

             public void Update(string id, Feed feed) =>
            _feed.ReplaceOne(feed => feed.Id == id, feed);

        public Feed Create(Feed feed)
        {
            _feed.InsertOne(feed);
            return feed;
        }


    }
}