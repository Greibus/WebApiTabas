using System.Collections.Generic;
using System.Web.Http;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    
    public class CrearBagcartController : ApiController
    {
        // GET: api/CrearBagcart
        [HttpGet]
        [Route("GetBagcart")]
        public IEnumerable<CreateBagcart> Get()
        {
            return CreateBagcartRepository.GetAllBagcart();
        }

        // GET: api/CrearBagcart/5
        [HttpGet]
        [Route("GetBagcart/{id}")]
        public IEnumerable<CreateBagcart> Get(int id)
        {
            return CreateBagcartRepository.GetBagcart(id);
        }

        // POST: api/CrearBagcart
        [HttpPost]
        [Route("CreateBagcart")]
        public bool Post( CreateBagcart bagcart)
        {
            if (bagcart != null)
            {
                return CreateBagcartRepository.addBagcartToDB(bagcart);
            }
            else
            {
                return false;
            }

            
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("DeleteBagcart/{id}")]
        public bool Delete(int id)
        {
            return CreateBagcartRepository.deleteBagcart(id);
        }
    }
}
