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
    public class tblCanchasController : ApiController
    {
        private BDUnderMatchEntities1 db = new BDUnderMatchEntities1();

        // GET: api/tblCanchas
        public IQueryable<viewCanchas> GettblCanchas()
        {
            return db.viewCanchas;
        }

        // GET: api/tblCanchas/5
        [ResponseType(typeof(viewCanchas))]
        public IHttpActionResult GettblCanchas(int idCancha)
        {
            viewCanchas viewCanchas = db.viewCanchas.Where(cancha => cancha.IdCancha == idCancha).FirstOrDefault();
            if (viewCanchas == null)
            {
                return NotFound();
            }

            return Ok(viewCanchas);
        }

        // PUT: api/tblCanchas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblCanchas(int idCancha, int idPlantel, string nombre, int idTipoCancha)
        {

            tblCanchas tblCanchas = new tblCanchas
            {
                IdCancha = idCancha,
                IdPlantel = idPlantel,
                Nombre = nombre,
                IdTipoCancha = idTipoCancha,
                Estatus = 1
            };


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(tblCanchas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblCanchasExists(idCancha))
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

        // POST: api/tblCanchas
        [ResponseType(typeof(tblCanchas))]
        public IHttpActionResult PosttblCanchas(int idPlantel, string nombre, int idTipoCancha)
        {

            tblCanchas tblCanchas = new tblCanchas
            {
                IdPlantel = idPlantel,
                Nombre = nombre,
                IdTipoCancha = idTipoCancha,
                Estatus = 1
            };

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblCanchas.Add(tblCanchas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblCanchas.IdCancha }, tblCanchas);
        }

        // DELETE: api/tblCanchas/5
        [ResponseType(typeof(tblCanchas))]
        public IHttpActionResult DeletetblCanchas(int idCancha, int operacion)
        {
            tblCanchas tblCanchas = db.tblCanchas.Find(idCancha);
            if (tblCanchas == null)
            {
                return NotFound();
            }

            if ( operacion == 0 )// Eliminar
            {
                db.tblCanchaEliminar(idCancha);
            }
            else
            {
                db.tblCanchaActivar(idCancha);
            }

            db.SaveChanges();

            return StatusCode(HttpStatusCode.OK); ;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblCanchasExists(int id)
        {
            return db.tblCanchas.Count(e => e.IdCancha == id) > 0;
        }
    }
}