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
            return db.viewJugadores;
        }

        // GET: api/tblJugadores/5
        [ResponseType(typeof(viewJugadores))]
        public IHttpActionResult GettblJugadores(int id)
        {
            tblJugadores tblJugadores = db.tblJugadores.Find(id);
            tblPersonas tblPersonas = db.tblPersonas.Find(tblJugadores.IdPersona);

            if (tblJugadores == null || tblPersonas == null)
            {
                return NotFound();
            }

            viewJugadores viewJugadores = new viewJugadores
            {
                IdJugador = tblJugadores.IdJugador,
                IdPersona = tblPersonas.IdPersona,
                Nombre = tblPersonas.Nombre,
                PrimerApellido = tblPersonas.PrimerApellido,
                SegundoApellido = tblPersonas.SegundoApellido,
                FechaNacimiento = tblPersonas.FechaNacimiento,
                Sexo = tblPersonas.Sexo,
                Telefono = tblPersonas.Telefono,
                Telefono2 = tblPersonas.Telefono2,
                Correo = tblPersonas.Correo,
                NumDorsal = tblJugadores.NumDorsal,
                SobreNombre = tblJugadores.SobreNombre,
                Posicion = tblJugadores.Posicion,
                Capitan = tblJugadores.Capitan,
                Estatus = tblJugadores.Estatus
            };

            return Ok(viewJugadores);
        }

        // PUT: api/tblJugadores/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblJugadores(int idPersona, int idJugador, string Nombre, string PrimerApellido, string SegundoApellido, string FechaNacimiento, string Sexo, string Telefono, string Telefono2, string Correo, string NumDorsal, string SobreNombre, string Posicion, int Capitan)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //if (id != tblJugadores.IdJugador)
            //{
            //    return BadRequest();
            //}

            db.tblJugadoresModificar(idPersona, Nombre, PrimerApellido, SegundoApellido, FechaNacimiento, Sexo, Telefono, Telefono2, Correo, idJugador, NumDorsal, SobreNombre, Posicion, Capitan);
            //db.Entry(tblJugadores).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
                //if (!tblJugadoresExists(id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/tblJugadores
        [ResponseType(typeof(tblJugadores))]
        public IHttpActionResult PosttblJugadores(string Nombre, string PrimerApellido, string SegundoApellido, string FechaNacimiento, string Sexo, string Telefono, string Telefono2, string Correo, string NumDorsal, string SobreNombre, string Posicion, int Capitan)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //db.tblJugadores.Add(tblJugadores);

            try
            {
                db.tblJugadoresAgregar(Nombre, PrimerApellido, SegundoApellido, FechaNacimiento, Sexo, Telefono, Telefono2, Correo, NumDorsal, SobreNombre, Posicion, Capitan);
                db.SaveChanges();
                return StatusCode(HttpStatusCode.OK);
            }
            catch(Exception e)
            {
                return BadRequest("Algo salio mal\n" + e);
            }
            //return CreatedAtRoute("DefaultApi", new { id = tblJugadores.IdJugador }, tblJugadores);
        }

        // DELETE: api/tblJugadores/5
        [ResponseType(typeof(tblJugadores))]
        public IHttpActionResult DeletetblJugadores(int idJugador)
        {
            tblJugadores tblJugadores = db.tblJugadores.Find(idJugador);
            if (tblJugadores == null)
            {
                return NotFound();
            }

            //db.tblJugadores.Remove(tblJugadores);
            db.tblJugadoresEliminar(idJugador);
            db.SaveChanges();

            return Ok(tblJugadores);
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