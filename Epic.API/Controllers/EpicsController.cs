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
    public class EpicsController : ApiController
    {
        private readonly IWorkRepository<Domain.Model.Epic> _repository;

        public EpicsController(IWorkRepository<Domain.Model.Epic> repository)
        {
            _repository = repository;
        }

        public Domain.Model.Epic Post([FromBody]Domain.Model.Epic epic, string user)
        {
            var insertedEpic = _repository.Insert(epic, user);

            return insertedEpic;
        }

        public Domain.Model.Epic Put([FromBody]Domain.Model.Epic epic, string user)
        {
            var updatedEpic = _repository.Update(epic, user);

            return updatedEpic;
        }
    }
}
