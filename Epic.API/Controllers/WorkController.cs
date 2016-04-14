using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Epic.Domain.Model;
using Epic.Domain.Repositories;

namespace Epic.API.Controllers
{
    public class WorkController : ApiController
    {
        private readonly IWorkRepository<GenericWork> _repository;

        public WorkController(IWorkRepository<GenericWork> repository)
        {
            _repository = repository;
        }

        public IEnumerable<ITimedWork> Get()
        {
            var work = _repository.GetAll().ToList();

            return work;
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }

        // GET api/work?employeeId=123
        [HttpGet]
        [Route("api/Work/Employee/{employeeId}")]
        public IEnumerable<ITimedWork> GetByUserId(string employeeId)
        {
            var work = _repository.GetAll().Where(x => x.AssignedToId == employeeId).ToList();

            return work;
        } 
    }
}
