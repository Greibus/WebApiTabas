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
    public class CreatePasajeroRepositoryController : ApiController
    {
        // GET: api/CreatePasajeroRepository
        [HttpGet]
        [Route("GetPasajero")]
        public IEnumerable<CreatePasajero> Get()
        {

            return CreatePasajeroRepository.getAllPasajeroFromDB();
        }

        [HttpGet]
        [Route("GetPasajero/{pasaporte}")]
        public CreatePasajero Get(string pasaporte)
        {
            return CreatePasajeroRepository.getPasajeroFromDB(pasaporte);
        }

        [HttpPost]
        [Route("CreatePasajero")]
        public bool Post(CreatePasajero pasajero)
        {
            if (pasajero != null)
            {
                return CreatePasajeroRepository.addPasajeroToDB(pasajero);
            }
            else
            {
                return false;
            }


        }

        [HttpDelete]
        [Route("DeletePasajero/{pasaporte}")]
        public bool Delete(string pasaporte)
        {
            return CreatePasajeroRepository.deletePasajeroFromDB(pasaporte);
        }
    }
}
