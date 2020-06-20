using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace DailyExperienceApi.Models
{
    public class Feed
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("userId")]
        

        public string UserId { get; set; }

         [BsonElement("username")]
        public string UserName { get; set; }
        [BsonElement("message")]
        public string Message { get; set; }
        [BsonElement("comments")]

        public Comments[] Comments { get; set; }
        [BsonElement("like")]

        public int Like { get; set; }
        [BsonElement("dislike")]

        public int DisLike { get; set; }
        [BsonElement("published")]

        public DateTime Published { get; set; }
        [BsonElement("lastEdited")]
        public DateTime LastEdited { get; set; }
    }

    public class Comments
    {

        [BsonElement("message")]
        public string Message { get; set; }
        [BsonElement("userId")]
        public string UserId { get; set; }
    }

}