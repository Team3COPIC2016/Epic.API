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
    public class StoriesController : ApiController
    {
        private readonly IWorkRepository<Story> _repository;

        public StoriesController(IWorkRepository<Story> repository)
        {
            _repository = repository;
        }

        public Story Post([FromBody]Story story, string user)
        {
            var insertedStory = _repository.Insert(story, user);

            return insertedStory;
        }

        public Story Put([FromBody]Story story, string user)
        {
            var updatedStory = _repository.Update(story, user);

            return updatedStory;
        }
    }
}
