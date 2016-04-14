using System;
using System.Collections.Generic;
using Epic.Domain.Extensions;
using Epic.Domain.Model;
using Epic.Domain.Repositories;
using MongoDB.Driver;

namespace Epic.Repositories.MongoDB
{
    public class WorkRepository<T> : IWorkRepository<T> where T : IWork
    {
        private readonly IMongoDatabase _db;
        private readonly IMongoCollection<T> _collection;

        public WorkRepository(IMongoDatabase db)
        {
            _db = db;
            _collection = _db.GetCollection<T>("Work");
        }

        public T Insert(T work, string user)
        {
            work.Id = Guid.NewGuid().ToString();
            work.SetCreatedBy(user);
            
            _collection.InsertOne(work);

            return work;
        }

        public IEnumerable<T> GetAll()
        {
            var employees = _collection.Find(FilterDefinition<T>.Empty).ToList();

            return employees;
        }

        public T Get(string id)
        {
            var employee = _collection.Find(x => x.Id == id).SingleOrDefault();

            return employee;
        }

        public T Update(T work, string user)
        {
            work.SetUpdatedBy(user);

            _collection.ReplaceOne(x => x.Id == work.Id, work);

            return work;
        }

        public void Delete(string id)
        {
            _collection.DeleteOne(x => x.Id == id);
        }
    }
}
