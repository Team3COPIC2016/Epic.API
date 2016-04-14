using System;
using System.Collections.Generic;
using Epic.Domain.Extensions;
using Epic.Domain.Model;
using Epic.Domain.Repositories;
using MongoDB.Driver;

namespace Epic.Repositories.MongoDB
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IMongoDatabase _db;
        private readonly IMongoCollection<Employee> _collection;

        public EmployeeRepository(IMongoDatabase db)
        {
            _db = db;
            _collection = _db.GetCollection<Employee>("Employee");
        }

        public Employee Insert(Employee employee, string user)
        {
            employee.Id = Guid.NewGuid().ToString();
            employee.SetCreatedBy(user);
            
            _collection.InsertOne(employee);

            return employee;
        }

        public IEnumerable<Employee> GetAll()
        {
            var employees = _collection.Find(FilterDefinition<Employee>.Empty).ToList();

            return employees;
        }

        public Employee Get(string id)
        {
            var employee = _collection.Find(x => x.Id == id).SingleOrDefault();

            return employee;
        }

        public IEnumerable<Employee> Get(string lastName, string firstName)
        {
            var employees = string.IsNullOrWhiteSpace(firstName) ? 
                _collection.Find(x => x.LastName.ToUpper().Contains(lastName)).ToList()
                : _collection.Find(x => x.LastName.ToUpper().Contains(lastName) || x.FirstName.ToUpper().Contains(firstName)).ToList(); ;

            return employees;
        }

        public Employee GetByEmployeeId(string employeeId)
        {
            var employee = _collection.Find(x => x.EmployeeId == employeeId).SingleOrDefault();

            return employee;
        }

        public Employee Update(Employee employee, string user)
        {
            employee.SetUpdatedBy(user);

            _collection.ReplaceOne(x => x.Id == employee.Id, employee);

            return employee;
        }

        public void Delete(string id)
        {
            _collection.DeleteOne(x => x.Id == id);
        }
    }
}
