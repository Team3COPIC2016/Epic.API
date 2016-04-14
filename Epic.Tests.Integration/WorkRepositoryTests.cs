using System.Linq;
using Epic.Domain.Model;
using Epic.Repositories.MongoDB;
using FluentAssertions;
using MongoDB.Driver;
using NUnit.Framework;

namespace Epic.Tests.Integration
{
    [TestFixture]
    public class WorkRepositoryTests
    {
        [Test]
        public void Can_insert_epic()
        {
            const string connectionString = "mongodb://admin:APCo73yjfs@ds023510.mlab.com:23510/epic-cop2016";
            var client = new MongoClient(connectionString);   
            var db = client.GetDatabase("epic-cop2016");
            var repository = new WorkRepository<Domain.Model.Epic>(db);
            var epic = new Domain.Model.Epic
            {
                Title = "Test Epic",
                Status = "To Do",
                BusinessValue = 100
            };

            repository.Insert(epic, "TEST");

            var epics = repository.GetAll();

            epics.Should().Contain(x => x.Title == "Test Epic");
        }

        [Test]
        public void Can_get_all()
        {
            const string connectionString = "mongodb://admin:APCo73yjfs@ds023510.mlab.com:23510/epic-cop2016";
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase("epic-cop2016");
            var repository = new WorkRepository<Domain.Model.Epic>(db);
            var taskRepository = new WorkRepository<Task>(db);
            var genericRepository = new WorkRepository<GenericWork>(db);
            var epic = new Domain.Model.Epic
            {
                Title = "Test Epic2",
                Status = "To Do",
                BusinessValue = 100
            };
            var task = new Task
            {
                Title = "Test Task2",
                Status = "To Do",
                BusinessValue = 100
            };

            repository.Insert(epic, "TEST");
            taskRepository.Insert(task, "TEST");

            var allWork = genericRepository.GetAll().ToList();

            allWork.Should().Contain(x => x.Title == "Test Epic2");
            allWork.Should().Contain(x => x.Title == "Test Task2");

            allWork.ForEach(x => genericRepository.Delete(x.Id));
        }
    }
}
