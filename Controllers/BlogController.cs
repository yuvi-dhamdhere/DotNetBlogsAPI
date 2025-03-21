﻿using CustomBlogsAPI.DAL.Repository;
using CustomBlogsAPI.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomBlogsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IRepository<myBlogsEntity> _myblogs;

        public IRepository<myCategoryEntity> _myCat { get; }

        public BlogController(IRepository<myBlogsEntity> myblogs, IRepository<myCategoryEntity> myCat)
        {
            _myblogs = myblogs;
            _myCat = myCat;
        }

        // GET: api/<BlogController>
        //[HttpGet]
        //public async Task<ActionResult> GetBlogsList()
        //{
        //    var blogList = await _myblogs.GetAll();
        //    return Ok(blogList);
        //}

        // GET: api/<BlogController>
        [HttpGet(Name = "GetBlogswithCat")]
        public async Task<ActionResult> GetBlogswithCat()
        {
            var blogList =
            (from b in await _myblogs.GetAll()
             join c in await _myCat.GetAll()
             on b.categoryId equals c.categoryId
             select new
             {
                 blogId = b.blogId,
                 blogTitle = b.blogTitle,
                 blogDescription = b.blogDescription,
                 blogContent = b.blogContent,
                 image = b.image,
                 categoryId = c.categoryId,
                 category = c.categoryName
             });
            return Ok(blogList);
        }

        // GET api/<BlogController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetBlogbyId([FromRoute] int id)
        {
            //var blog = await _myblogs.GetById(id);
            var blog =
                (from b in await _myblogs.GetAll()
                 join c in await _myCat.GetAll()
                 on b.categoryId equals c.categoryId
                 where b.blogId == id
                 select new
                 {
                     blogId = b.blogId,
                     blogTitle = b.blogTitle,
                     blogDescription = b.blogDescription,
                     blogContent = b.blogContent,
                     image = b.image,
                     categoryId = c.categoryId,
                     category = c.categoryName
                 });
            return Ok(blog);
        }

        // POST api/<BlogController>
        [HttpPost]
        public async Task<ActionResult> AddBlogs([FromBody] myBlogsEntity model)
        {
            await _myblogs.AddAsync(model);
            await _myblogs.SaveChangesAsync();
            return Ok(model);
        }

        // PUT api/<BlogController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBlogs([FromRoute] int id, [FromBody] myBlogsEntity model)
        {
            var blog = await _myblogs.GetById(id);
            blog.blogDescription = model.blogDescription;
            blog.blogTitle = model.blogTitle;
            blog.blogContent = model.blogContent;
            blog.image = model.image;
            blog.IsFeatured = model.IsFeatured;
            blog.categoryId = model.categoryId;
            _myblogs.Update(blog);
            await _myblogs.SaveChangesAsync();
            return Ok(model);
        }

        // DELETE api/<BlogController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBlogs([FromRoute] int id)
        {
            await _myblogs.DeleteAsync(id);
            await _myblogs.SaveChangesAsync();
            return Ok();
        }
    }
}
