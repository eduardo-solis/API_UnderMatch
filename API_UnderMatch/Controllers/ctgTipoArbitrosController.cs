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
        public IHttpActionResult GetctgTipoArbitros(int idTipoArbitro)
        {
            ctgTipoArbitros ctgTipoArbitros = db.ctgTipoArbitros.Find(idTipoArbitro);
            if (ctgTipoArbitros == null)
            {
                return NotFound();
            }

            return Ok(ctgTipoArbitros);
        }

        // PUT: api/ctgTipoArbitros/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutctgTipoArbitros(int idTipoArbitro, string nombre)
        {

            ctgTipoArbitros ctgTipoArbitros = new ctgTipoArbitros
            {
                IdTipoArbitro = idTipoArbitro,
                Nombre = nombre,
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
                if (!ctgTipoArbitrosExists(idTipoArbitro))
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
        public IHttpActionResult PostctgTipoArbitros(string nombre)
        {

            ctgTipoArbitros ctgTipoArbitros = new ctgTipoArbitros
            {
                Nombre = nombre,
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
        public IHttpActionResult DeletectgTipoArbitros(int idTipoArbitro, int operacion)
        {
            ctgTipoArbitros ctgTipoArbitros = db.ctgTipoArbitros.Find(idTipoArbitro);
            if (ctgTipoArbitros == null)
            {
                return NotFound();
            }

            if ( operacion == 0 ) // Eliminar
            {
                db.ctgTipoArbitroEliminar(idTipoArbitro);
            }
            else
            {
                db.ctgTipoArbitroActivar(idTipoArbitro);
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