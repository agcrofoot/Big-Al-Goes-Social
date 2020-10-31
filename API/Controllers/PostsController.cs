using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Models.Interfaces;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        // GET: api/Posts
        [EnableCors("Another Policy")]
        [HttpGet]
        public List<BigAlsPosts> Get()
        {
            IGetAllPosts readObject = new ReadPostData();
            return readObject.GetAllPosts();
        }

        // GET: api/Posts/5
        [EnableCors("Another Policy")]
        [HttpGet("{id}", Name = "Get")]
        public BigAlsPosts Get(int id)
        {
            IGetPost readObject = new ReadPostData();
            return readObject.GetPost(id);
        }

        // POST: api/Posts
        [EnableCors("Another Policy")]
        [HttpPost]
        public void Post([FromBody] BigAlsPosts value)
        {   
            IInsertPost insertObject = new SavePost();
            insertObject.InsertPost(value);
        }

        // PUT: api/Posts/5
        [EnableCors("Another Policy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] BigAlsPosts value)
        {
            IEditPost editObject = new SavePost();
            editObject.EditPost(id, value);
        }

        // DELETE: api/ApiWithActions/5
        [EnableCors("Another Policy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IDeletePost deleteObject = new SavePost();
            deleteObject.DeletePost(id);
        }
    }
}
