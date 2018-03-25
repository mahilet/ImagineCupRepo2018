using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using System.Configuration;

namespace API.App_Start
{
    ///Summary
    ///This is a mongodb context
    ///Summary
    public class MongoDBContext
    {
        ///Summary
        ///This is an object of IMongoDB 
        ///Summary
        public IMongoDatabase database;

        ///Summary
        ///This constructs the context with new client and database
        ///Summary
        public MongoDBContext()
        {
            var mongoClient = new MongoClient(ConfigurationManager.AppSettings["MongoDbHost"]);
            database = mongoClient.GetDatabase(ConfigurationManager.AppSettings["MongoDbName"]);
        }
    }
}