using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using UxDesignPlusStyle.Models;

namespace UxDesignPlusStyle.Controllers.Api
{
    public class MyPortfoliosController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

       

        // GET: api/MyPortfolios
        public IQueryable<MyPortfolio> GetMyPortfolio()
        {
            return db.MyPortfolio;
        }

        // GET: api/MyPortfolios/5
        [ResponseType(typeof(MyPortfolio))]
        public IHttpActionResult GetMyPortfolio(int id)
        {
            MyPortfolio myPortfolio = db.MyPortfolio.Find(id);
            if (myPortfolio == null)
            {
                return NotFound();
            }

            return Ok(myPortfolio);
        }

        // PUT: api/MyPortfolios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMyPortfolio(int id, MyPortfolio myPortfolio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != myPortfolio.Id)
            {
                return BadRequest();
            }

            db.Entry(myPortfolio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyPortfolioExists(id))
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

        // POST: api/MyPortfolios
        [ResponseType(typeof(MyPortfolio))]
        public IHttpActionResult PostMyPortfolio(MyPortfolio myPortfolio)
        {
            if (myPortfolio.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(myPortfolio.ImageUpload.FileName);
                string extension = Path.GetExtension(myPortfolio.ImageUpload.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                myPortfolio.imageUrl = "~/Content/images/" + fileName;
               
            }


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MyPortfolio.Add(myPortfolio);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = myPortfolio.Id }, myPortfolio);
        }

        // DELETE: api/MyPortfolios/5
        [ResponseType(typeof(MyPortfolio))]
        public IHttpActionResult DeleteMyPortfolio(int id)
        {
            MyPortfolio myPortfolio = db.MyPortfolio.Find(id);
            if (myPortfolio == null)
            {
                return NotFound();
            }

            db.MyPortfolio.Remove(myPortfolio);
            db.SaveChanges();

            return Ok(myPortfolio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MyPortfolioExists(int id)
        {
            return db.MyPortfolio.Count(e => e.Id == id) > 0;
        }
    }
}