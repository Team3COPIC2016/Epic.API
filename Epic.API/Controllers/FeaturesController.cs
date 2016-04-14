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
    public class FeaturesController : ApiController
    {
        private readonly IWorkRepository<Feature> _repository;

        public FeaturesController(IWorkRepository<Feature> repository)
        {
            _repository = repository;
        }

        public Feature Post([FromBody]Feature feature, string user)
        {
            var insertedFeature = _repository.Insert(feature, user);

            return insertedFeature;
        }

        public Feature Put([FromBody]Feature feature, string user)
        {
            var updatedFeature = _repository.Update(feature, user);

            return updatedFeature;
        }
    }
}
