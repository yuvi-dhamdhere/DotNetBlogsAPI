using CustomBlogsAPI.DAL.Repository;
using CustomBlogsAPI.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomBlogsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<myCategoryEntity> _catRepo;

        public CategoryController(IRepository<myCategoryEntity> catRepo)
        {
            _catRepo = catRepo;
        }

        // GET: api/<CategoryController>  // http://localhost:5081/api/Category
        [HttpGet]
        public async Task<ActionResult> GetAllCategory()
        {
            var catRepo = await _catRepo.GetAll();
            return Ok(catRepo);
        }

        // GET api/<CategoryController>/5
        //[HttpGet("{id}")]
        //public Task<ActionResult> GetCatbyId(int id)
        //{
        //    return Ok(id);// await _catRepo.GetById(id);
        //}

        //// POST api/<CategoryController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<CategoryController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CategoryController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
