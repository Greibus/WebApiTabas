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
    public class CreateEmpleadoController : ApiController
    {
        // GET: api/CreateEmpleado
        [HttpGet]
        [Route("GetEmpleado")]
        public IEnumerable<CreateEmpleado> Get()
        {

            return CreateEmpleadoRepository.getAllEmpeladoFromDB();
        }

        [HttpGet]
        [Route("GetEmpleado/{user}")]
        public CreateEmpleado Get(string user)
        {
            return CreateEmpleadoRepository.getEmpleadoFromDB(user);
        }

        [HttpPost]
        [Route("CreateEmpleado")]
        public bool Post(CreateEmpleado empleado)
        {
            if (empleado != null)
            {
                return CreateEmpleadoRepository.addClienteToDB(empleado);
            }
            else
            {
                return false;
            }


        }


        [HttpDelete]
        [Route("DeleteEmpleado/{user}")]
        public bool Delete(string user)
        {
            return CreateEmpleadoRepository.deleteEmpleadoFromDB(user);
        }
    }
}

