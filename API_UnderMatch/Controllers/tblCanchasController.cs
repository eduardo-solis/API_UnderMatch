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
using API_UnderMatch.Models;

namespace API_UnderMatch.Controllers
{
    public class tblCanchasController : ApiController
    {
        private BDUnderMatchEntities1 db = new BDUnderMatchEntities1();

        // GET: api/tblCanchas
        public IQueryable<tblCanchas> GettblCanchas()
        {
            return db.tblCanchas;
        }

        // GET: api/tblCanchas/5
        [ResponseType(typeof(tblCanchas))]
        public IHttpActionResult GettblCanchas(int id)
        {
            tblCanchas tblCanchas = db.tblCanchas.Find(id);
            if (tblCanchas == null)
            {
                return NotFound();
            }

            return Ok(tblCanchas);
        }

        // PUT: api/tblCanchas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblCanchas(int id, tblCanchas tblCanchas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblCanchas.IdCancha)
            {
                return BadRequest();
            }

            db.Entry(tblCanchas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblCanchasExists(id))
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

        // POST: api/tblCanchas
        [ResponseType(typeof(tblCanchas))]
        public IHttpActionResult PosttblCanchas(tblCanchas tblCanchas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblCanchas.Add(tblCanchas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblCanchas.IdCancha }, tblCanchas);
        }

        // DELETE: api/tblCanchas/5
        [ResponseType(typeof(tblCanchas))]
        public IHttpActionResult DeletetblCanchas(int id)
        {
            tblCanchas tblCanchas = db.tblCanchas.Find(id);
            if (tblCanchas == null)
            {
                return NotFound();
            }

            db.tblCanchas.Remove(tblCanchas);
            db.SaveChanges();

            return Ok(tblCanchas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblCanchasExists(int id)
        {
            return db.tblCanchas.Count(e => e.IdCancha == id) > 0;
        }
    }
}