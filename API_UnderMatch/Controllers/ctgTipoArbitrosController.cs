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
    public class ctgTipoArbitrosController : ApiController
    {
        private BDUnderMatchEntities1 db = new BDUnderMatchEntities1();

        // GET: api/ctgTipoArbitros
        public IQueryable<ctgTipoArbitros> GetctgTipoArbitros()
        {
            return db.ctgTipoArbitros;
        }

        // GET: api/ctgTipoArbitros/5
        [ResponseType(typeof(ctgTipoArbitros))]
        public IHttpActionResult GetctgTipoArbitros(int id)
        {
            ctgTipoArbitros ctgTipoArbitros = db.ctgTipoArbitros.Find(id);
            if (ctgTipoArbitros == null)
            {
                return NotFound();
            }

            return Ok(ctgTipoArbitros);
        }

        // PUT: api/ctgTipoArbitros/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutctgTipoArbitros(int IdTipoArbitro, string Nombre)
        {

            ctgTipoArbitros ctgTipoArbitros = new ctgTipoArbitros
            {
                IdTipoArbitro = IdTipoArbitro,
                Nombre = Nombre,
                Estatus = 1
            };

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(ctgTipoArbitros).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ctgTipoArbitrosExists(IdTipoArbitro))
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

        // POST: api/ctgTipoArbitros
        [ResponseType(typeof(ctgTipoArbitros))]
        public IHttpActionResult PostctgTipoArbitros(string Nombre)
        {

            ctgTipoArbitros ctgTipoArbitros = new ctgTipoArbitros
            {
                Nombre = Nombre,
                Estatus = 1
            };

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ctgTipoArbitros.Add(ctgTipoArbitros);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ctgTipoArbitros.IdTipoArbitro }, ctgTipoArbitros);
        }

        // DELETE: api/ctgTipoArbitros/5
        [ResponseType(typeof(ctgTipoArbitros))]
        public IHttpActionResult DeletectgTipoArbitros(int IdTipoArbitro, int Operacion)
        {
            ctgTipoArbitros ctgTipoArbitros = db.ctgTipoArbitros.Find(IdTipoArbitro);
            if (ctgTipoArbitros == null)
            {
                return NotFound();
            }

            if ( Operacion == 0 ) // Eliminar
            {
                db.ctgTipoArbitroEliminar(IdTipoArbitro);
            }
            else
            {
                db.ctgTipoArbitroActivar(IdTipoArbitro);
            }

            db.SaveChanges();

            return Ok(ctgTipoArbitros);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ctgTipoArbitrosExists(int id)
        {
            return db.ctgTipoArbitros.Count(e => e.IdTipoArbitro == id) > 0;
        }
    }
}