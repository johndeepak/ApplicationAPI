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
using ApplicationAPI;

namespace ApplicationAPI.Controllers
{
    public class PraticejoinsController : ApiController
    {
        private praticeEntities db = new praticeEntities();

        // GET: api/Praticejoins
        public IQueryable<Mypractice> Getpraticejoins()
        {
            return db.Mypractices;
        }

        // GET: api/Praticejoins/5
        [ResponseType(typeof(Mypractice))]
        public IHttpActionResult Getpraticejoin(int id)
        {
            Mypractice praticejoin = db.Mypractices.Find(id);
            if (praticejoin == null)
            {
                return NotFound();
            }

            return Ok(praticejoin);
        }

        // PUT: api/Praticejoins/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putpraticejoin(int id, Mypractice praticejoin)
        {
          

            if (id != praticejoin.orderId)
            {
                return BadRequest();
            }

            db.Entry(praticejoin).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!praticejoinExists(id))
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

        // POST: api/Praticejoins
        [ResponseType(typeof(Mypractice))]
        public IHttpActionResult Postpraticejoin(Mypractice praticejoin)
        {
           

            db.Mypractices.Add(praticejoin);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (praticejoinExists(praticejoin.orderId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = praticejoin.orderId }, praticejoin);
        }

        // DELETE: api/Praticejoins/5
        [ResponseType(typeof(Mypractice))]
        public IHttpActionResult Deletepraticejoin(int id)
        {
            Mypractice praticejoin = db.Mypractices.Find(id);
            if (praticejoin == null)
            {
                return NotFound();
            }

            db.Mypractices.Remove(praticejoin);
            db.SaveChanges();

            return Ok(praticejoin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool praticejoinExists(int id)
        {
            return db.Mypractices.Count(e => e.orderId == id) > 0;
        }
    }
}