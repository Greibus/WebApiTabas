using System.Collections.Generic;
using System.Web.Http;
using System.Collections.Generic;
using System.Web.Http;
using TEST.Models;
using TEST.Repositories;

namespace TEST.Controllers
{
    public class CreateMarcaController : ApiController
    {
        // GET: api/CreateMarca
        [HttpGet]
        [Route("GetMarca")]
        public IEnumerable<CreateMarca> Get()
        {
            return CreateMarcaRepository.GetAllMarca();
        }

        [HttpGet]
        [Route("GetMarca/{id}")]
        public IEnumerable<CreateMarca> Get(int id)
        {
            return CreateMarcaRepository.GetMarca(id);
        }


        [HttpPost]
        [Route("CreateMarca")]
        public bool Post(CreateMarca marca)
        {
            if (marca != null)
            {
                return CreateMarcaRepository.addMarca(marca);
            }
            else
            {
                return false;
            }
        }

   

        // DELETE: api/CreateMarca/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public bool Delete(int id)
        {
            return CreateMarcaRepository.deleteMarca(id);
        }
    }
}
