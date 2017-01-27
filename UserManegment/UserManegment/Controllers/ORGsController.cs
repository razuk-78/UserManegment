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
using UserManegment.Models;

namespace UserManegment.Controllers
{
    public class ORGsController : ApiController
    {
        private UserDB db = new UserDB();

        // GET: api/ORGs
        public IQueryable<ORG> GetORG()
        {
            return db.ORG;
        }

        // GET: api/ORGs/5
        [ResponseType(typeof(ORG))]
        public IHttpActionResult GetORG(int id)
        {
            ORG oRG = db.ORG.Find(id);
            if (oRG == null)
            {
                return NotFound();
            }

            return Ok(oRG);
        }

        // PUT: api/ORGs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutORG(int id, ORG oRG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != oRG.Id)
            {
                return BadRequest();
            }

            db.Entry(oRG).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ORGExists(id))
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

        // POST: api/ORGs
        [ResponseType(typeof(ORG))]
        public IHttpActionResult PostORG(ORG oRG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ORG.Add(oRG);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = oRG.Id }, oRG);
        }

        // DELETE: api/ORGs/5
        [ResponseType(typeof(ORG))]
        public IHttpActionResult DeleteORG(int id)
        {
            ORG oRG = db.ORG.Find(id);
            if (oRG == null)
            {
                return NotFound();
            }

            db.ORG.Remove(oRG);
            db.SaveChanges();

            return Ok(oRG);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ORGExists(int id)
        {
            return db.ORG.Count(e => e.Id == id) > 0;
        }
    }
}