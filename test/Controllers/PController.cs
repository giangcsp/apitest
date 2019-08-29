
using Microsoft.AspNetCore.Mvc;
using WebApplication1.property;
using WebApplication1.Repos.repo;
namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PController : ControllerBase
    {
        private PRepo pRepo;
        //Constructor
        public PController()
        {
            this.pRepo = new PRepo(new Pcontext());
        }

        // GET api/p/get
        [Route("~/api/p/get")]
        [HttpGet]
        public JsonResult Get()
        {
            return pRepo.getAllP();

        }

        // GET api/p/get/id
        [Route("~api/p/get/{id}")]
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return pRepo.getIDP(id);
        }

        // POST api/p/post
        [Route("~/api/p/post")]
        [HttpPost]
        public void Post([FromBody] Person p)
        {
            pRepo.PostP(p.ID, p.PNAME, p.addid);
        }

        // PUT api/p/put/id
        [Route("~/api/p/put/{id}")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Person p)
        {
            pRepo.PutP(p.ID, p.PNAME, p.addid);
        }

        // DELETE api/p/delete/id
        [Route("~/api/p/delete/{id}")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            pRepo.DeleteP(id);
        }
    }
}
