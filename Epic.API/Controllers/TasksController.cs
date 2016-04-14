using System.Collections.Generic;
using System.Linq;
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

        // GET api/tasks/Employee?employeeId=123
        [HttpGet]
        [Route("api/Tasks/Employee/{employeeId}")]
        public IEnumerable<ITimedWork> GetByUserId(string employeeId)
        {
            var work = _repository.GetAll().Where(x => x.AssignedToId == employeeId && x.Type == "Task").ToList();

            return work;
        }
    }
}
