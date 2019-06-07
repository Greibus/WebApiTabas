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
    public class CreateRolesController : ApiController
    {
        [HttpGet]
        [Route("GetRoles")]
        public IEnumerable<CreateRoles> Get()
        {

            return CreateRolesRepository.getAllRolesFromDB();
        }

        [HttpGet]
        [Route("GetRoles/{numero}")]
        public CreateRoles Get(int numero)
        {
            return CreateRolesRepository.getRolesFromDB(numero);
        }

        [HttpPost]
        [Route("CreateRoles")]
        public bool Post(CreateRoles roles)
        {
            if (roles != null)
            {
                return CreateRolesRepository.addRolesDB(roles);
            }
            else
            {
                return false;
            }


        }

        [HttpDelete]
        [Route("DeleteRoles/{numero}")]
        public bool Delete(int numero)
        {
            return CreateRolesRepository.deleteRolesFromDB(numero);
        }
    }
}
