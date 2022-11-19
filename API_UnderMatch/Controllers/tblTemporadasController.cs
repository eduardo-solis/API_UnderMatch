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
        public IHttpActionResult GettblTemporadas(int idTemporada)
        {
            tblTemporadas tblTemporadas = db.tblTemporadas.Find(idTemporada);
            if (tblTemporadas == null)
            {
                return NotFound();
            }

            return Ok(tblTemporadas);
        }

        // PUT: api/tblTemporadas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblTemporadas(int idTemporada, string nombre, string fechaInicio, string fechaFin)
        {

            tblTemporadas tblTemporadas = new tblTemporadas
            {
                IdTemporada = idTemporada,
                Nombre = nombre,
                FechaInicio = fechaInicio,
                FechaFin = fechaFin,
                Estatus = 1
            };

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(tblTemporadas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblTemporadasExists(idTemporada))
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
        public IHttpActionResult PosttblTemporadas(string nombre, string fechaInicio, string fechaFin)
        {

            tblTemporadas tblTemporadas = new tblTemporadas
            {
                Nombre = nombre,
                FechaInicio = fechaInicio,
                FechaFin = fechaFin,
                Estatus = 1
            };

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
        public IHttpActionResult DeletetblTemporadas(int idTemporada, int operacion)
        {
            tblTemporadas tblTemporadas = db.tblTemporadas.Find(idTemporada);
            if (tblTemporadas == null)
            {
                return NotFound();
            }

            if ( operacion == 0 )
            {
                db.tblTemporadaEliminar(idTemporada);
            }
            else
            {
                db.tblTemporadaActivar(idTemporada);
            }

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