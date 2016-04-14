using System.Linq;
using Epic.Domain.Model;
using Epic.Repositories.MongoDB;
using FluentAssertions;
using MongoDB.Driver;
using NUnit.Framework;

namespace Epic.Tests.Integration
{
    [TestFixture]
    public class EmployeeRepositoryTests
    {
        [Test]
        public void Can_insert_employee()
        {
            const string connectionString = "mongodb://admin:APCo73yjfs@ds023510.mlab.com:23510/epic-cop2016";
            var client = new MongoClient(connectionString);   
            var db = client.GetDatabase("epic-cop2016");
            var repository = new EmployeeRepository(db);
            var employee = new Employee
            {
                FirstName = "Jon",
                LastName = "Scolamiero",
                Email = "team3.copic2016@gmail.com"
            };

            repository.Insert(employee, "TEST");

            var employees = repository.GetAll().ToList();

            employees.Should().Contain(x => x.LastName == "Scolamiero");

            repository.Delete(employees.First().Id);
        }
    }
}
