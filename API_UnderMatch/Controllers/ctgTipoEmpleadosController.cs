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
        public IHttpActionResult GetctgTipoEmpleados(int id)
        {
            ctgTipoEmpleados ctgTipoEmpleados = db.ctgTipoEmpleados.Find(id);
            if (ctgTipoEmpleados == null)
            {
                return NotFound();
            }

            return Ok(ctgTipoEmpleados);
        }

        // PUT: api/ctgTipoEmpleados/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutctgTipoEmpleados(int id, ctgTipoEmpleados ctgTipoEmpleados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ctgTipoEmpleados.IdTipoEmpleado)
            {
                return BadRequest();
            }

            db.Entry(ctgTipoEmpleados).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ctgTipoEmpleadosExists(id))
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
        public IHttpActionResult PostctgTipoEmpleados(ctgTipoEmpleados ctgTipoEmpleados)
        {
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
        public IHttpActionResult DeletectgTipoEmpleados(int id)
        {
            ctgTipoEmpleados ctgTipoEmpleados = db.ctgTipoEmpleados.Find(id);
            if (ctgTipoEmpleados == null)
            {
                return NotFound();
            }

            db.ctgTipoEmpleados.Remove(ctgTipoEmpleados);
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