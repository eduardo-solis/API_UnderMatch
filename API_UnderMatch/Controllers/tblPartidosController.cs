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
    public class tblPartidosController : ApiController
    {
        private BDUnderMatchEntities1 db = new BDUnderMatchEntities1();

        // GET: api/tblPartidos
        public IQueryable<tblPartidos> GettblPartidos()
        {
            return db.tblPartidos;
        }

        // GET: api/tblPartidos/5
        [ResponseType(typeof(tblPartidos))]
        public IHttpActionResult GettblPartidos(int idPartido)
        {
            tblPartidos tblPartidos = db.tblPartidos.Find(idPartido);
            if (tblPartidos == null)
            {
                return NotFound();
            }

            return Ok(tblPartidos);
        }

        // PUT: api/tblPartidos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblPartidos(
            int idPartido, int idCancha, int idTemporada, int jornada, string dia, string hora, int equipo1,
            int equipo2, int golesEquipo1, int golesEquipo2, int ganador, int perdedor, int idArbitro
            )
        {

            tblPartidos tblPartidos = new tblPartidos
            {
                IdPartido = idPartido,
                IdCancha = idCancha,
                IdTemporada = idTemporada,
                Jornada = jornada,
                Dia = dia,
                Hora = hora,
                Equipo1 = equipo1,
                Equipo2 = equipo2,
                GolesEquipo1 = golesEquipo1,
                GolesEquipo2 = golesEquipo2,
                Ganador = ganador,
                Perdedor = perdedor,
                IdArbitro = idArbitro,
                Estatus = 1
            };

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(tblPartidos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblPartidosExists(idPartido))
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

        // POST: api/tblPartidos
        [ResponseType(typeof(tblPartidos))]
        public IHttpActionResult PosttblPartidos(
            int idCancha, int idTemporada, int jornada, string dia, string hora, int equipo1,
            int equipo2, int golesEquipo1, int golesEquipo2, int ganador, int perdedor, int idArbitro
            )
        {

            tblPartidos tblPartidos = new tblPartidos
            {
                IdCancha = idCancha,
                IdTemporada = idTemporada,
                Jornada = jornada,
                Dia = dia,
                Hora = hora,
                Equipo1 = equipo1,
                Equipo2 = equipo2,
                GolesEquipo1 = golesEquipo1,
                GolesEquipo2 = golesEquipo2,
                Ganador = ganador,
                Perdedor = perdedor,
                IdArbitro = idArbitro,
                Estatus = 1
            };

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblPartidos.Add(tblPartidos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblPartidos.IdPartido }, tblPartidos);
        }

        // DELETE: api/tblPartidos/5
        [ResponseType(typeof(tblPartidos))]
        public IHttpActionResult DeletetblPartidos(int idPartido, int operacion)
        {
            tblPartidos tblPartidos = db.tblPartidos.Find(idPartido);
            if (tblPartidos == null)
            {
                return NotFound();
            }

            if ( operacion == 0 )
            {
                db.tblPartidoEliminar(idPartido);
            }
            else
            {
                db.tblPartidoActivar(idPartido);
            }

            db.SaveChanges();

            return Ok(tblPartidos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblPartidosExists(int id)
        {
            return db.tblPartidos.Count(e => e.IdPartido == id) > 0;
        }
    }
}