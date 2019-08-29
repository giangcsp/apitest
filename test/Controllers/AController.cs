using WebApplication1.Repos.repo;
using WebApplication1.property;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AController : Controller
    {
        private ARepo aRepo = null;
        //Constructor
        public AController()
        {
            this.aRepo = new ARepo(new Pcontext());
        }

        // GET api/get
        [Route("~/api/get")]
        [HttpGet]
        public JsonResult GetPeople()
        {
            JsonResult returnval = aRepo.getAll();
            return returnval;

        }


        // GET api/get/id
        [Route("~/api/get/{id}.{format?}")]
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            JsonResult returnval = aRepo.getID(id);
            return returnval;
        }

        // POST api/post
        [Route("~/api/post")]
        [HttpPost]
        public void Post([FromBody] Address p)
        {
            aRepo.Post(p.ID, p.ADDR);
        }

        // PUT api/put
        [Route("~/api/put/{id}")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Address p)
        {
            aRepo.Put(id, p.ADDR);
        }

        // DELETE api/delete/id
        [Route("~/api/delete/{id}")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            aRepo.Delete(id);
        }
    }
}