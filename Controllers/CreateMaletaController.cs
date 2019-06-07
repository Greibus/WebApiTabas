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
    public class CreateMaletaController : ApiController
    {
        // GET: api/CrearBagcart
        [HttpGet]
        [Route("GetMaleta")]
        public IEnumerable<CreateMaleta> Get()
        {
            return CreateMaletaRepository.GetAllMaleta();
        }

        // GET: api/CrearBagcart/5
        [HttpGet]
        [Route("GetMaleta/{id}")]
        public IEnumerable<CreateMaleta> Get(int id)
        {
            return CreateMaletaRepository.GetMaleta(id);
        }

        [HttpPost]
        [Route("CreateMaleta")]
        public bool Post(CreateMaleta maleta)
        {
            if (maleta != null)
            {
                return CreateMaletaRepository.addMaletaDB(maleta);
            }
            else
            {
                return false;
            }


        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("DeleteMaleta/{id}")]
        public bool Delete(int id)
        {
            return CreateMaletaRepository.deleteMaleta(id);
        }
    }
}

