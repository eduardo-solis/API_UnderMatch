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
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class tblJugadoresController : ApiController
    {
        private BDUnderMatchEntities1 db = new BDUnderMatchEntities1();

        // GET: api/tblJugadores
        public IQueryable<viewJugadores> GettblJugadores()
        {
            DbSet<viewJugadores> viewJugadores = db.viewJugadores;

            return viewJugadores;
        }

        // GET: api/tblJugadores/5
        [ResponseType(typeof(viewJugadores))]
        public IHttpActionResult GettblJugadores(int idJugador)
        {
            viewJugadores viewJugadores =  db.viewJugadores.Where(jugador => jugador.IdJugador == idJugador).FirstOrDefault();

            if (viewJugadores == null)
            {
                return NotFound();
            }

            return Ok(viewJugadores);
        }

        // PUT: api/tblJugadores/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblJugadores(int idPersona, int idJugador, string nombre, string primerApellido, string segundoApellido, string fechaNacimiento, string sexo, string telefono, string telefono2, string correo, string numDorsal, string sobreNombre, string posicion, int capitan)
        {
            db.tblJugadoresModificar(idPersona, nombre, primerApellido, segundoApellido, fechaNacimiento, sexo, telefono, telefono2, correo, idJugador, numDorsal, sobreNombre, posicion, capitan);
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

        // POST: api/tblJugadores
        [ResponseType(typeof(tblJugadores))]
        public IHttpActionResult PosttblJugadores(string nombre, string primerApellido, string segundoApellido, string fechaNacimiento, string sexo, string telefono, string telefono2, string correo, string numDorsal, string sobreNombre, string posicion, int capitan)
        {
            try
            {
                db.tblJugadoresAgregar(nombre, primerApellido, segundoApellido, fechaNacimiento, sexo, telefono, telefono2, correo, numDorsal, sobreNombre, posicion, capitan);
                db.SaveChanges();
                return StatusCode(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return BadRequest("Algo salio mal\n" + e);
            }
        }

        // DELETE: api/tblJugadores/5
        // Activate/Delete Jugadores - Activar/Eliminar jugadores
        [ResponseType(typeof(tblJugadores))]
        public IHttpActionResult DeletetblJugadores(int idJugador, int operacion)
        {
            tblJugadores tblJugadores = db.tblJugadores.Find(idJugador);
            if (tblJugadores == null)
            {
                return NotFound();
            }

            if (operacion == 0)
            {
                db.tblJugadoresEliminar(idJugador);
            }
            else
            {
                db.tblJugadoresActivar(idJugador);
            }

            db.SaveChanges();

            return StatusCode(HttpStatusCode.OK);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblJugadoresExists(int id)
        {
            return db.tblJugadores.Count(e => e.IdJugador == id) > 0;
        }
    }
}