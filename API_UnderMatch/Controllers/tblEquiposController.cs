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
    public class tblEquiposController : ApiController
    {
        private BDUnderMatchEntities1 db = new BDUnderMatchEntities1();

        // GET: api/tblEquipos
        public IQueryable<tblEquipos> GettblEquipos()
        {
            return db.tblEquipos;
        }

        // GET: api/tblEquipos/5
        [ResponseType(typeof(tblEquipos))]
        public IHttpActionResult GettblEquipos(int id)
        {
            tblEquipos tblEquipos = db.tblEquipos.Find(id);
            if (tblEquipos == null)
            {
                return NotFound();
            }

            return Ok(tblEquipos);
        }

        // PUT: api/tblEquipos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblEquipos(int id, tblEquipos tblEquipos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblEquipos.IdEquipo)
            {
                return BadRequest();
            }

            db.Entry(tblEquipos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblEquiposExists(id))
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

        // POST: api/tblEquipos
        [ResponseType(typeof(tblEquipos))]
        public IHttpActionResult PosttblEquipos(tblEquipos tblEquipos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblEquipos.Add(tblEquipos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblEquipos.IdEquipo }, tblEquipos);
        }

        // DELETE: api/tblEquipos/5
        [ResponseType(typeof(tblEquipos))]
        public IHttpActionResult DeletetblEquipos(int id)
        {
            tblEquipos tblEquipos = db.tblEquipos.Find(id);
            if (tblEquipos == null)
            {
                return NotFound();
            }

            db.tblEquipos.Remove(tblEquipos);
            db.SaveChanges();

            return Ok(tblEquipos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblEquiposExists(int id)
        {
            return db.tblEquipos.Count(e => e.IdEquipo == id) > 0;
        }
    }
}