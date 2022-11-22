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
    public class ctgTipoCanchasController : ApiController
    {
        private BDUnderMatchEntities1 db = new BDUnderMatchEntities1();

        // GET: api/ctgTipoCanchas
        public IQueryable<ctgTipoCanchas> GetctgTipoCanchas()
        {
            return db.ctgTipoCanchas;
        }

        // GET: api/ctgTipoCanchas/5
        [ResponseType(typeof(ctgTipoCanchas))]
        public IHttpActionResult GetctgTipoCanchas(int idTipoCancha)
        {
            ctgTipoCanchas ctgTipoCanchas = db.ctgTipoCanchas.Find(idTipoCancha);
            if (ctgTipoCanchas == null)
            {
                return NotFound();
            }

            return Ok(ctgTipoCanchas);
        }

        // PUT: api/ctgTipoCanchas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutctgTipoCanchas(int idTipoCancha, string nombre)
        {
            ctgTipoCanchas ctgTipoCanchas = new ctgTipoCanchas
            {
                IdTipoCancha = idTipoCancha,
                Nombre = nombre,
                Estatus = 1
            };


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(ctgTipoCanchas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ctgTipoCanchasExists(idTipoCancha))
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

        // POST: api/ctgTipoCanchas
        [ResponseType(typeof(ctgTipoCanchas))]
        public IHttpActionResult PostctgTipoCanchas(string nombre)
        {
            ctgTipoCanchas ctgTipoCanchas = new ctgTipoCanchas
            {
                Nombre = nombre,
                Estatus = 1
            };

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ctgTipoCanchas.Add(ctgTipoCanchas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ctgTipoCanchas.IdTipoCancha }, ctgTipoCanchas);
        }

        // DELETE: api/ctgTipoCanchas/5
        [ResponseType(typeof(ctgTipoCanchas))]
        public IHttpActionResult DeletectgTipoCanchas(int idTipoCancha, int operacion)
        {
            ctgTipoCanchas ctgTipoCanchas = db.ctgTipoCanchas.Find(idTipoCancha);
            if (ctgTipoCanchas == null)
            {
                return NotFound();
            }

            ctgTipoCanchas.Estatus = operacion;
            db.Entry(ctgTipoCanchas).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(ctgTipoCanchas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ctgTipoCanchasExists(int id)
        {
            return db.ctgTipoCanchas.Count(e => e.IdTipoCancha == id) > 0;
        }
    }
}