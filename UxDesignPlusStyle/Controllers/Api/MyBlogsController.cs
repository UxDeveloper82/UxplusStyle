using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using UxDesignPlusStyle.Models;

namespace UxDesignPlusStyle.Controllers.Api
{
    public class MyBlogsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/MyBlogs
        public IQueryable<MyBlog> GetMyBlogs()
        {
            return db.MyBlogs;
        }

        // GET: api/MyBlogs/5
        [ResponseType(typeof(MyBlog))]
        public IHttpActionResult GetMyBlog(int id)
        {
            MyBlog myBlog = db.MyBlogs.Find(id);
            if (myBlog == null)
            {
                return NotFound();
            }

            return Ok(myBlog);
        }

        // PUT: api/MyBlogs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMyBlog(int id, MyBlog myBlog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != myBlog.Id)
            {
                return BadRequest();
            }

            db.Entry(myBlog).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyBlogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/MyBlogs
        [ResponseType(typeof(MyBlog))]
        public IHttpActionResult PostMyBlog(MyBlog myBlog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MyBlogs.Add(myBlog);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = myBlog.Id }, myBlog);
        }

        // DELETE: api/MyBlogs/5
        [ResponseType(typeof(MyBlog))]
        public IHttpActionResult DeleteMyBlog(int id)
        {
            MyBlog myBlog = db.MyBlogs.Find(id);
            if (myBlog == null)
            {
                return NotFound();
            }

            db.MyBlogs.Remove(myBlog);
            db.SaveChanges();

            return Ok(myBlog);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MyBlogExists(int id)
        {
            return db.MyBlogs.Count(e => e.Id == id) > 0;
        }
    }
}