using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        // GET: api/Posts
        [HttpGet]
        public List<Posts> Get()
        {
            IReadAllPosts readObject = new ReadPost();
            return readObject.GetPosts();
        }

        // GET: api/Posts/5
        [HttpGet("{id}", Name = "Get")]
        public Posts Get(int id)
        {
            IGetPost readObject = new ReadPost();
            return readObject.GetPost(id);
        }

        // POST: api/Posts
        [HttpPost]
        public void Post([FromBody] Posts value)
        {
            ISavePosts insertObject = new SavePosts();
            insertObject.SavePost(value);
        }

        // PUT: api/Posts/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Console.WriteLine(id);
        }
    }
}
