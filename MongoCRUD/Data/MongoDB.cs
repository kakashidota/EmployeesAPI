using MongoCRUD.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoCRUD.Data
{
    public class MongoDB
    {
        private IMongoDatabase db;
        private string connectionstring = Environment.GetEnvironmentVariable("MONGO_CONNECTION_STRING");
        public MongoDB(string database)
        {
       
            var client = new MongoClient(connectionstring);
            db = client.GetDatabase(database);
        }


        //READ all users
        public Task<List<UserModel>> GetAllUsers(string table)
        {
            var collection = db.GetCollection<UserModel>(table);
            return collection.AsQueryable().ToListAsync();
        }


        //Read user by id
        public UserModel GetUserById(string table, Guid id)
        {
            var collection = db.GetCollection<UserModel>(table);
            return collection.AsQueryable().ToList().Find(x => x.Id == id);
        }

        //Create a user
        public async Task<UserModel> AddUser(string table, UserModel user)
        {
            var collection = db.GetCollection<UserModel>(table);
            collection.InsertOneAsync(user);
            return user;
        }


        //Update a user



        //Delete a auser


    }
}
