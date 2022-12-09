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
        public IQueryable<viewPartidos> GettblPartidos()
        {
            DbSet<viewPartidos> viewPartidos = db.viewPartidos;
            return viewPartidos;
        }

        // GET: api/tblPartidos/5
        [ResponseType(typeof(viewPartidos))]
        public IHttpActionResult GettblPartidos(int idPartido)
        {
            viewPartidos viewPartidos = db.viewPartidos.Where(partido => partido.IdPartido == idPartido).FirstOrDefault();

            if (viewPartidos == null)
            {
                return NotFound();
            }

            return Ok(viewPartidos);
        }

        // GET: api/tblPartidos/5
        [ResponseType(typeof(viewPartidos))]
        public IHttpActionResult GettblPartidosByJugador(int idEquipo)
        {
            DbSet<viewPartidos> viewPartidos = db.viewPartidos;
            //viewPartidos viewPartidos = (viewPartidos)db.viewPartidos.Where(partido => partido.IdEquipo1 == idEquipo || partido.IdEquipo2 == idEquipo);
            var vistaPartidos = from vp in viewPartidos
                                       where vp.IdEquipo1 == idEquipo
                                       || vp.IdEquipo2 == idEquipo
                                       select vp;
            if (viewPartidos == null)
            {
                return NotFound();
            }

            return Ok(viewPartidos.ToList());
        }

        // PUT: api/tblPartidos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblPartidos(
            int idPartido, int idCancha, int idTemporada, int jornada, string dia, string hora, int equipo1,
            int equipo2, int golesEquipo1, int golesEquipo2, int ganador, int perdedor, int idArbitro
            )
        {

            db.tblPartidosModificar(idPartido, idCancha, idTemporada, jornada, dia, hora, equipo1, equipo2, golesEquipo1, golesEquipo2, ganador, perdedor, idArbitro);


            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();

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
            db.tblPartidosAgregar(idCancha,idTemporada,jornada,dia,hora,equipo1,equipo2,golesEquipo1,golesEquipo2,ganador,perdedor,idArbitro);


            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();

            }

            return StatusCode(HttpStatusCode.NoContent);
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

            return Ok();
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