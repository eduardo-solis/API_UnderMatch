using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using API_UnderMatch.Models;

namespace API_UnderMatch.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class tblTemporadasController : ApiController
    {
        private BDUnderMatchEntities1 db = new BDUnderMatchEntities1();

        // GET: api/tblTemporadas
        public IQueryable<tblTemporadas> GettblTemporadas()
        {
            return db.tblTemporadas;
        }

        // GET: api/tblTemporadas/5
        [ResponseType(typeof(tblTemporadas))]
        public IHttpActionResult GettblTemporadas(int id)
        {
            tblTemporadas tblTemporadas = db.tblTemporadas.Find(id);
            if (tblTemporadas == null)
            {
                return NotFound();
            }

            return Ok(tblTemporadas);
        }

        // PUT: api/tblTemporadas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblTemporadas(int id, tblTemporadas tblTemporadas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblTemporadas.IdTemporada)
            {
                return BadRequest();
            }

            db.Entry(tblTemporadas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblTemporadasExists(id))
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

        // POST: api/tblTemporadas
        [ResponseType(typeof(tblTemporadas))]
        public IHttpActionResult PosttblTemporadas(tblTemporadas tblTemporadas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblTemporadas.Add(tblTemporadas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblTemporadas.IdTemporada }, tblTemporadas);
        }

        // DELETE: api/tblTemporadas/5
        [ResponseType(typeof(tblTemporadas))]
        public IHttpActionResult DeletetblTemporadas(int id)
        {
            tblTemporadas tblTemporadas = db.tblTemporadas.Find(id);
            if (tblTemporadas == null)
            {
                return NotFound();
            }

            db.tblTemporadas.Remove(tblTemporadas);
            db.SaveChanges();

            return Ok(tblTemporadas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblTemporadasExists(int id)
        {
            return db.tblTemporadas.Count(e => e.IdTemporada == id) > 0;
        }
    }
}