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
    public class tblArbitrosController : ApiController
    {
        private BDUnderMatchEntities1 db = new BDUnderMatchEntities1();

        // GET: api/tblArbitros
        public IQueryable<viewArbitros> GettblArbitros()
        {
            DbSet<viewArbitros> viewArbitros = db.viewArbitros;
            return viewArbitros;
        }

        // GET: api/tblArbitros/5
        [ResponseType(typeof(viewArbitros))]
        public IHttpActionResult GettblArbitros(int idArbitro)
        {
            tblArbitros tblArbitros = db.tblArbitros.Find(idArbitro);
            tblPersonas tblPersonas = db.tblPersonas.Find(tblArbitros.IdPersona);
            ctgCategorias categorias = db.ctgCategorias.Find(tblArbitros.Categoria);
            ctgTipoArbitros ctgTipoArbitros = db.ctgTipoArbitros.Find(tblArbitros.TipoArbitro);

            if (tblArbitros == null || tblPersonas == null)
            {
                return NotFound();
            }

            viewArbitros viewArbitros = new viewArbitros
            {
                IdArbitro = tblArbitros.IdArbitro,
                IdPersona = tblPersonas.IdPersona,
                Nombre = tblPersonas.Nombre,
                PrimerApellido = tblPersonas.PrimerApellido,
                SegundoApellido = tblPersonas.SegundoApellido,
                FechaNacimiento = tblPersonas.FechaNacimiento,
                Sexo = tblPersonas.Sexo,
                Telefono = tblPersonas.Telefono,
                Telefono2 = tblPersonas.Telefono2,
                Correo = tblPersonas.Correo,
                CostoArbitraje = tblArbitros.CostoArbitraje,
                Categoria = categorias.IdCategoria,
                TipoArbitro = ctgTipoArbitros.IdTipoArbitro,
                Expr3 = categorias.Categoria,
                Expr1 = ctgTipoArbitros.Nombre,
                Estatus = tblArbitros.Estatus
            };

            return Ok(viewArbitros);
        }

        // PUT: api/tblArbitros/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblArbitros(int idPersona, int idArbitro, string nombre, string primerApellido, string segundoApellido,
                string fechaNacimiento, string sexo, string telefono, string telefono2, string correo, decimal costoArbitraje, int idCategoria, int idTipoArbitro)
        {
            db.tblArbitrosModificar(idPersona, nombre, primerApellido, segundoApellido, fechaNacimiento, sexo, telefono, telefono2, correo,
                    idArbitro, costoArbitraje, idCategoria, idTipoArbitro);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return Ok(HttpStatusCode.OK);
        }

        // POST: api/tblArbitros
        [ResponseType(typeof(tblArbitros))]
        public IHttpActionResult PosttblArbitros(string nombre, string primerApellido, string segundoApellido, string fechaNacimiento,
                string sexo, string telefono, string telefono2, string correo, decimal costoArbitraje, int idCategoria, int idTipoArbitro)
        {
            try
            {
                db.tblArbitrosAgregar(nombre, primerApellido, segundoApellido, fechaNacimiento, sexo, telefono, telefono2, correo, costoArbitraje,
                    idCategoria, idTipoArbitro);
                db.SaveChanges();
                return Ok(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return BadRequest("Algo salio mal\n" + e);
            }
        }

        // DELETE: api/tblArbitros/5
        [ResponseType(typeof(tblArbitros))]
        public IHttpActionResult DeletetblArbitros(int idArbitro, int operacion)
        {
            tblArbitros tblArbitros = db.tblArbitros.Find(idArbitro);
            if (tblArbitros == null)
            {
                return NotFound();
            }

            if ( operacion == 0 ) // Eliminar
            {
                db.tblArbitrosEliminar(idArbitro, 1);
            }
            else
            {
                db.tblArbitrosEliminar(idArbitro, 0);
            }
            
            db.SaveChanges();

            return Ok(HttpStatusCode.OK);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblArbitrosExists(int id)
        {
            return db.tblArbitros.Count(e => e.IdArbitro == id) > 0;
        }
    }
}