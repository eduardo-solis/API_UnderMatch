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
    public class ctgCategoriasController : ApiController
    {
        private BDUnderMatchEntities1 db = new BDUnderMatchEntities1();

        // GET: api/ctgCategorias
        public IQueryable<ctgCategorias> GetctgCategorias()
        {
            return db.ctgCategorias;
        }

        // GET: api/ctgCategorias/5
        [ResponseType(typeof(ctgCategorias))]
        public IHttpActionResult GetctgCategorias(int id)
        {
            ctgCategorias ctgCategorias = db.ctgCategorias.Find(id);
            if (ctgCategorias == null)
            {
                return NotFound();
            }

            return Ok(ctgCategorias);
        }

        // PUT: api/ctgCategorias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutctgCategorias(int id, ctgCategorias ctgCategorias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ctgCategorias.IdCategoria)
            {
                return BadRequest();
            }

            db.Entry(ctgCategorias).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ctgCategoriasExists(id))
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

        // POST: api/ctgCategorias
        [ResponseType(typeof(ctgCategorias))]
        public IHttpActionResult PostctgCategorias(ctgCategorias ctgCategorias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ctgCategorias.Add(ctgCategorias);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ctgCategorias.IdCategoria }, ctgCategorias);
        }

        // DELETE: api/ctgCategorias/5
        [ResponseType(typeof(ctgCategorias))]
        public IHttpActionResult DeletectgCategorias(int id)
        {
            ctgCategorias ctgCategorias = db.ctgCategorias.Find(id);
            if (ctgCategorias == null)
            {
                return NotFound();
            }

            db.ctgCategorias.Remove(ctgCategorias);
            db.SaveChanges();

            return Ok(ctgCategorias);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ctgCategoriasExists(int id)
        {
            return db.ctgCategorias.Count(e => e.IdCategoria == id) > 0;
        }
    }
}