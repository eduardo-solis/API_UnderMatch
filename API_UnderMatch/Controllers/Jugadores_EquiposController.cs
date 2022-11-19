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
    public class Jugadores_EquiposController : ApiController
    {
        private BDUnderMatchEntities1 db = new BDUnderMatchEntities1();

        // GET: api/Jugadores_Equipos
        public IQueryable<Jugadores_Equipos> GetJugadores_Equipos()
        {
            return db.Jugadores_Equipos;
        }

        // GET: api/Jugadores_Equipos/5
        [ResponseType(typeof(Jugadores_Equipos))]
        public IHttpActionResult GetJugadores_Equipos(int idRelacion)
        {
            Jugadores_Equipos jugadores_Equipos = db.Jugadores_Equipos.Find(idRelacion);
            if (jugadores_Equipos == null)
            {
                return NotFound();
            }

            return Ok(jugadores_Equipos);
        }

        // PUT: api/Jugadores_Equipos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJugadores_Equipos(int idRelacion, int idJugador, int idEquipo)
        {

            Jugadores_Equipos jugadores_Equipos = new Jugadores_Equipos
            {
                IdRelacionJugadorEquipo = idRelacion,
                IdJugador = idJugador,
                IdEquipo = idEquipo
            };

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (idRelacion != jugadores_Equipos.IdRelacionJugadorEquipo)
            {
                return BadRequest();
            }

            db.Entry(jugadores_Equipos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Jugadores_EquiposExists(idRelacion))
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

        // POST: api/Jugadores_Equipos
        [ResponseType(typeof(Jugadores_Equipos))]
        public IHttpActionResult PostJugadores_Equipos(int idJugador, int idEquipo)
        {
            Jugadores_Equipos jugadores_Equipos = new Jugadores_Equipos
            {
                IdJugador = idJugador,
                IdEquipo = idEquipo
            };

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Jugadores_Equipos.Add(jugadores_Equipos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = jugadores_Equipos.IdRelacionJugadorEquipo }, jugadores_Equipos);
        }

        // DELETE: api/Jugadores_Equipos/5
        [ResponseType(typeof(Jugadores_Equipos))]
        public IHttpActionResult DeleteJugadores_Equipos(int idRelacion)
        {
            Jugadores_Equipos jugadores_Equipos = db.Jugadores_Equipos.Find(idRelacion);
            if (jugadores_Equipos == null)
            {
                return NotFound();
            }

            db.Jugadores_Equipos.Remove(jugadores_Equipos);
            db.SaveChanges();

            return Ok(jugadores_Equipos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Jugadores_EquiposExists(int id)
        {
            return db.Jugadores_Equipos.Count(e => e.IdRelacionJugadorEquipo == id) > 0;
        }
    }
}