﻿using System;
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

            for (int i = 0; i < viewJugadores.ToList().Count; i++)
            {
                // Se extrae el dato para manipular la informacion
                viewJugadores view = viewJugadores.ToList()[i];
                int idJugador = view.IdJugador;
                Jugadores_Equipos Jugadores_Equipos = db.Jugadores_Equipos.Where(jE => jE.IdJugador == idJugador).First();
                view.IdEquipo = Jugadores_Equipos.IdEquipo;
                view.NombreEquipo = db.tblEquipos.Find(Jugadores_Equipos.IdEquipo).Nombre;

                // Se regresa el dato con la informacion actualizada
                viewJugadores.ToList()[i] = view;
            }

            return viewJugadores;
        }

        // GET: api/tblJugadores/5
        [ResponseType(typeof(viewJugadores))]
        public IHttpActionResult GettblJugadores(int id)
        {
            tblJugadores tblJugadores = db.tblJugadores.Find(id);
            tblPersonas tblPersonas = db.tblPersonas.Find(tblJugadores.IdPersona);
            Jugadores_Equipos Jugadores_Equipos = db.Jugadores_Equipos.Where(jE => jE.IdJugador == tblJugadores.IdJugador).First();
            tblEquipos tblEquipos = db.tblEquipos.Find(Jugadores_Equipos.IdEquipo);

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
                Estatus = tblJugadores.Estatus,
                IdEquipo = Jugadores_Equipos.IdEquipo,
                NombreEquipo = tblEquipos.Nombre
            };

            return Ok(viewJugadores);
        }

        // PUT: api/tblJugadores/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblJugadores(int idPersona, int idJugador, string Nombre, string PrimerApellido, string SegundoApellido, string FechaNacimiento, string Sexo, string Telefono, string Telefono2, string Correo, string NumDorsal, string SobreNombre, string Posicion, int Capitan)
        {
            db.tblJugadoresModificar(idPersona, Nombre, PrimerApellido, SegundoApellido, FechaNacimiento, Sexo, Telefono, Telefono2, Correo, idJugador, NumDorsal, SobreNombre, Posicion, Capitan);
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
        public IHttpActionResult PosttblJugadores(string Nombre, string PrimerApellido, string SegundoApellido, string FechaNacimiento, string Sexo, string Telefono, string Telefono2, string Correo, string NumDorsal, string SobreNombre, string Posicion, int Capitan)
        {
            try
            {
                db.tblJugadoresAgregar(Nombre, PrimerApellido, SegundoApellido, FechaNacimiento, Sexo, Telefono, Telefono2, Correo, NumDorsal, SobreNombre, Posicion, Capitan);
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