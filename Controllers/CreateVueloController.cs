using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TEST.Models;
using TEST.Repositories;

namespace TEST.Controllers
{
    public class CreateVueloController : ApiController
    {
        // GET: api/CreateVuelo
        [HttpGet]
        [Route("GetVuelo")]
        public IEnumerable<CreateVuelo> Get()
        {
            return CreateVueloRepository.GetAllVuelo();
        }
        // GET: api/CreateVuelo/5
        [HttpGet]
        [Route("GetVuelo/{id}")]
        public IEnumerable<CreateVuelo> Get(int id)
        {
            return CreateVueloRepository.GetVuelo(id);
        }

        // POST: api/CreateVuelo
        [HttpPost]
        [Route("CreateVuelo")]
        public bool Post(CreateVuelo vuelo)
        {
            if (vuelo != null)
            {
                return CreateVueloRepository.addVueloDB(vuelo);
            }
            else
            {
                return false;
            }


        }

        [HttpDelete]
        [Route("DeleteVuelo/{id}")]
        public bool Delete(int id)
        {
            return CreateVueloRepository.deleteVuelo(id);
        }

    }
}
