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
    public class tblPartidosController : ApiController
    {
        private BDUnderMatchEntities1 db = new BDUnderMatchEntities1();

        // GET: api/tblPartidos
        public IQueryable<tblPartidos> GettblPartidos()
        {
            return db.tblPartidos;
        }

        // GET: api/tblPartidos/5
        [ResponseType(typeof(tblPartidos))]
        public IHttpActionResult GettblPartidos(int id)
        {
            tblPartidos tblPartidos = db.tblPartidos.Find(id);
            if (tblPartidos == null)
            {
                return NotFound();
            }

            return Ok(tblPartidos);
        }

        // PUT: api/tblPartidos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblPartidos(int id, tblPartidos tblPartidos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblPartidos.IdPartido)
            {
                return BadRequest();
            }

            db.Entry(tblPartidos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblPartidosExists(id))
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

        // POST: api/tblPartidos
        [ResponseType(typeof(tblPartidos))]
        public IHttpActionResult PosttblPartidos(tblPartidos tblPartidos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblPartidos.Add(tblPartidos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblPartidos.IdPartido }, tblPartidos);
        }

        // DELETE: api/tblPartidos/5
        [ResponseType(typeof(tblPartidos))]
        public IHttpActionResult DeletetblPartidos(int id)
        {
            tblPartidos tblPartidos = db.tblPartidos.Find(id);
            if (tblPartidos == null)
            {
                return NotFound();
            }

            db.tblPartidos.Remove(tblPartidos);
            db.SaveChanges();

            return Ok(tblPartidos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblPartidosExists(int id)
        {
            return db.tblPartidos.Count(e => e.IdPartido == id) > 0;
        }
    }
}