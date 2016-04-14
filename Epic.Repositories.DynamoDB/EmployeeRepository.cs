using System;
using System.Collections.Generic;
using System.Linq;
using Amazon.DynamoDBv2.DataModel;
using Epic.Domain.Model;

namespace Epic.Repositories.DynamoDB
{
    public class EmployeeRepository
    {
        private readonly IDynamoDBContext _db;

        public EmployeeRepository(IDynamoDBContext db)
        {
            _db = db;
        }

        public Employee Insert(Employee employee)
        {
            employee.Id = Guid.NewGuid().ToString();

            _db.Save(employee);

            return employee;
        }

        public Employee Get(string id)
        {
            var employee = _db.Load<Employee>(id);

            return employee;
        }

        public IEnumerable<Employee> GetAll()
        {
            var employees = _db.Query<Employee>("Employee").ToList();

            return employees;
        } 
    }
}