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
        public IHttpActionResult GetctgCategorias(int idCategoria)
        {
            ctgCategorias ctgCategorias = db.ctgCategorias.Find(idCategoria);
            if (ctgCategorias == null)
            {
                return NotFound();
            }

            return Ok(ctgCategorias);
        }

        // PUT: api/ctgCategorias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutctgCategorias(int idCategoria, string categoria)
        {
            ctgCategorias ctgCategorias = new ctgCategorias
            {
                IdCategoria = idCategoria,
                Categoria = categoria,
                Estatus = 1
            };

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            db.Entry(ctgCategorias).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ctgCategoriasExists(idCategoria))
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
        public IHttpActionResult PostctgCategorias(string categoria)
        {

            ctgCategorias ctgCategorias = new ctgCategorias
            {
                Categoria = categoria,
                Estatus = 1
            };

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
        public IHttpActionResult DeletectgCategorias(int idCategoria, int operacion)
        {
            ctgCategorias ctgCategorias = db.ctgCategorias.Find(idCategoria);
            if (ctgCategorias == null)
            {
                return NotFound();
            }

            if ( operacion == 0 ) //Eliminar
            {
                db.ctgCategoriasEliminar(idCategoria);
            }
            else
            {
                db.ctgCategoriasActivar(idCategoria);
            }

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