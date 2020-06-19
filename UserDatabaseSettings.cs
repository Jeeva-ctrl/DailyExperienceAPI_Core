namespace DailyExperienceApi.Models
{
    public class UserDatabaseSettings : IUserDatabaseSettings
    {
        public string UserCollectionName { get; set; }

         public string FeedCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IUserDatabaseSettings
    {
        string UserCollectionName { get; set; }

         public string FeedCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}