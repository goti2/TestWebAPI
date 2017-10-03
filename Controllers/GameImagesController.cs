using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TestWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class GameImagesController : Controller
    {
        // GET api/gameimages
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/gameimages/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/gameimages
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/gameimages/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/gameimages/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
