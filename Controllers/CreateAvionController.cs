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
    public class CreateAvionController : ApiController
    {
        // GET: api/CreateAvion
        // GET: api/CrearBagcart
        [HttpGet]
        [Route("GetAvion")]
        public IEnumerable<CreateAvion> Get()
        {
            return CreateAvionRepository.GetAllAvion(); ;
        }


        // GET: api/GetAvion/5
        [HttpGet]
        [Route("GetAvion/{id}")]
        public IEnumerable<CreateAvion> Get(int id)
        {
            return CreateAvionRepository.GetAvion(id);
        }

        [HttpPost]
        [Route("CreateAvion")]
        public bool Post(CreateAvion avion)
        {
            if (avion != null)
            {
                return CreateAvionRepository.addAvionDB(avion);
            }
            else
            {
                return false;
            }


        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("DeleteAvion/{id}")]
        public bool Delete(int id)
        {
            return CreateAvionRepository.deleteAvion(id);
        }

    }
}
