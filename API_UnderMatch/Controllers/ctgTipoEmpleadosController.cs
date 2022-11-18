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
    public class ctgTipoEmpleadosController : ApiController
    {
        private BDUnderMatchEntities1 db = new BDUnderMatchEntities1();

        // GET: api/ctgTipoEmpleados
        public IQueryable<ctgTipoEmpleados> GetctgTipoEmpleados()
        {
            return db.ctgTipoEmpleados;
        }

        // GET: api/ctgTipoEmpleados/5
        [ResponseType(typeof(ctgTipoEmpleados))]
        public IHttpActionResult GetctgTipoEmpleados(int idTipoEmpleado)
        {
            ctgTipoEmpleados ctgTipoEmpleados = db.ctgTipoEmpleados.Find(idTipoEmpleado);
            if (ctgTipoEmpleados == null)
            {
                return NotFound();
            }

            return Ok(ctgTipoEmpleados);
        }

        // PUT: api/ctgTipoEmpleados/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutctgTipoEmpleados(int idTipoEmpleado, string nombre)
        {

            ctgTipoEmpleados ctgTipoEmpleados = new ctgTipoEmpleados
            {
                IdTipoEmpleado = idTipoEmpleado,
                Nombre = nombre,
                Estatus = 1
            };

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(ctgTipoEmpleados).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ctgTipoEmpleadosExists(idTipoEmpleado))
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

        // POST: api/ctgTipoEmpleados
        [ResponseType(typeof(ctgTipoEmpleados))]
        public IHttpActionResult PostctgTipoEmpleados(string nombre)
        {

            ctgTipoEmpleados ctgTipoEmpleados = new ctgTipoEmpleados
            {
                Nombre = nombre,
                Estatus = 1
            };

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ctgTipoEmpleados.Add(ctgTipoEmpleados);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ctgTipoEmpleados.IdTipoEmpleado }, ctgTipoEmpleados);
        }

        // DELETE: api/ctgTipoEmpleados/5
        [ResponseType(typeof(ctgTipoEmpleados))]
        public IHttpActionResult DeletectgTipoEmpleados(int idTipoEmpleado, int operacion)
        {
            ctgTipoEmpleados ctgTipoEmpleados = db.ctgTipoEmpleados.Find(idTipoEmpleado);
            if (ctgTipoEmpleados == null)
            {
                return NotFound();
            }

            if ( operacion == 0 )
            {
                db.ctgTipoEmpleadoEliminar(idTipoEmpleado);
            }
            else
            {
                db.ctgTipoEmpleadoActivar(idTipoEmpleado);
            }

            db.SaveChanges();

            return Ok(ctgTipoEmpleados);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ctgTipoEmpleadosExists(int id)
        {
            return db.ctgTipoEmpleados.Count(e => e.IdTipoEmpleado == id) > 0;
        }
    }
}