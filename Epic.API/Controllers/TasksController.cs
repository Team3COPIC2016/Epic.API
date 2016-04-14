using System.Web.Http;
using Epic.Domain.Model;
using Epic.Domain.Repositories;

namespace Epic.API.Controllers
{
    public class TasksController : ApiController
    {
        private readonly IWorkRepository<Task> _repository;

        public TasksController(IWorkRepository<Task> repository)
        {
            _repository = repository;
        }

        public Task Post([FromBody]Task task, string user)
        {
            var insertedTask = _repository.Insert(task, user);

            return insertedTask;
        }

        public Task Put([FromBody]Task task, string user)
        {
            var updatedTask = _repository.Update(task, user);

            return updatedTask;
        }
    }
}
