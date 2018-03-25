using API.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.App_Start;

namespace API.Dal
{
    ///<Summary>
    /// userDal class which creates connection to the database 
    /// and embodies CRUD Operations
    ///</Summary>
    public class UserDal
    {
        private MongoDBContext dbContext;

        private IMongoCollection<User> userCollection;

        ///<Summary>
        /// creates a new context and collection of the database
        ///</Summary>
        public UserDal()
        {
            dbContext = new MongoDBContext();
            userCollection = dbContext.database.GetCollection<User>("User");
        }
        ////Get Users
        //public IEnumerable<User> GetUsers()
        //{
        //    List<User> users = userCollection.AsQueryable<User>().ToList();
        //    return users;
        //}

        ////Get user
        //public  IEnumerable<User> GetUser(string id)
        //{
        //    var userId = new ObjectId(id);
        //    var user = userCollection.AsQueryable().SingleOrDefaultAsync(x=>x.Id == userId);
        //    return  user;
        //}

        ////create user
        //public void Create(User user)
        //{
        //    userCollection.InsertOne(user);

        //}

        ////edit user
        //public Task<User> Edit(string id, User user)
        //{
        //    try
        //    {
        //        var filter = Builders<User>.Filter.Eq("_id", ObjectId.Parse(id));
        //        var update = Builders<User>.Update
        //            .Set("UserName", user.UserName)
        //            .Set("FirstName", user.FirstName)
        //            .Set("LastName", user.LastName)
        //            .Set("Email", user.Email)
        //            .Set("Phone", user.Phone)
        //            .Set("Type", user.Type);
        //        var result = userCollection.UpdateOne(filter, update);
        //        return result;

        //    }catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        ////delete user
        //public Task<User> Remove(string id, User user)
        //{

        //}


        ///<Summary>
        /// an operation to get all users
        ///</Summary>
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            try
            {
                return await userCollection.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<Summary>
        /// an operation to get a single user
        ///</Summary>
        public async Task<User> GetUser(string id)
        {
            var filter = Builders<User>.Filter.Eq("Id", id);

            try
            {
                return await userCollection
                    .Find(filter)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<Summary>
        /// an operation to add new user
        ///</Summary>
        public async Task AddUser(User user)
        {
            try
            {
                await userCollection.InsertOneAsync(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<Summary>
        /// an operation to remove a user
        ///</Summary>
        public async Task<bool> RemoveUser(string id)
        {
            try
            {
                DeleteResult actionResult = await userCollection.DeleteOneAsync(
                    Builders<User>.Filter.Eq("Id", id));

                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        ///<Summary>
        /// an operation to update a user
        ///</Summary>
        public async Task<bool> UpdateUser(string id, User user)
        {

            var filter = Builders<User>.Filter.Eq("Id", id);
            var update = Builders<User>.Update
                .Set("UserName", user.UserName)
                    .Set("FirstName", user.FirstName)
                    .Set("LastName", user.LastName)
                    .Set("Email", user.Email)
                    .Set("Phone", user.Phone)
                    .Set("Type", user.Type);
            try
            {
                UpdateResult actionResult = await userCollection.UpdateOneAsync(filter, update);
                return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        //private readonly IUserRepository _userRepository;

        // //used to read the server instance for performing operations on the database
        // IMongoClient _client;
        // //instance of the MongoDB Server
        // //MongoServer _server;
        // //Mongo Database for performing operations
        // IMongoDatabase _db;

        // //Connection string 
        // string connectionString = "mongodb://api-cosmos-db:yxYly4uA3rwURAgHu2b55tRK8v1ZM5H5ezKRwBzH3nwUt5ISixkD8Co6CT5TOLkbQEfWBxD4iCslyzV2RNRzfQ==@api-cosmos-db.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";

        // //constructor ensures connection to the server and database (in MongoDB jargon).
        // //the name of the database is "User"
        // //the name of the collection (table) is "AppUsers"
        // public UserDal(IUserRepository userRepository)
        // {
        //     _client = new MongoClient(connectionString);
        //     //_server = _client.GetServer();
        //     _db = _client.GetDatabase("User");
        //     _userRepository = userRepository;
        // }

        //public IEnumerable<User> GetUsers()
        //{
        //    return _db.GetCollection<User>("AppUsers").FindAll();
        //}


        //public User GetUser(Guid id)
        //{
        //    var res = Query<User>.EQ(p => p.Id, id);
        //    return _db.GetCollection<User>("AppUsers").FindOne(res);
        //}

        //public User Create(User user)
        //{
        //    _db.GetCollection<User>("AppUsers").Save(user);
        //    return user;
        //}

        //public void Update(Guid id, User user)
        //{
        //    user.Id = id;
        //    var res = Query<User>.EQ(pd => pd.Id, id);
        //    var operation = Update<User>.Replace(user);
        //    _db.GetCollection<User>("AppUsers").Update(res, operation);
        //}
        //public void Remove(Guid id)
        //{
        //    var res = Query<User>.EQ(e => e.Id, id);
        //    var operation = _db.GetCollection<User>("AppUsers").Remove(res);
        //}

        //public UserDal(string connection)
        //{
        //    if (string.IsNullOrWhiteSpace(connection))
        //      {
        //        connection = "mongodb://localhost:27017";
        //      }

        //          MongoClient _server = MongoServer.Create(connection);
        //       MongoDatabase _database = _server.GetDatabase("User", SafeMode.True);
        //         MongoCollection _users = _database.GetCollection<User>("AppUsers");
        //}



        //public async Task AddUser(User user)
        //{
        //   return await _userRepository.InsertOneAsync(user);
        //}

        //public Task<IEnumerable<User>> GetAllUsers()
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<User> GetUser(string id)
        //{
        //    var filter = Builders<User>.Filter.Eq("Id", id);

        //    try
        //    {
        //        return await _userRepository.Find(filter).FirstOrDefaultAsync();

        //    }catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public Task<bool> RemoveUser(string id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<bool> UpdateUser(string id, string body)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

