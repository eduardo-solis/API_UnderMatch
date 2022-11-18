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
        public IHttpActionResult GettblArbitros(int id)
        {
            tblArbitros tblArbitros = db.tblArbitros.Find(id);
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
        public IHttpActionResult PuttblArbitros(int IdPersona, int IdArbitro, string Nombre, string PrimerApellido, string SegundoApellido,
                string FechaNacimiento, string Sexo, string Telefono, string Telefono2, string Correo, decimal CostoArbitraje, int IdCategoria, int IdTipoArbitro)
        {
            db.tblArbitrosModificar(IdPersona, Nombre, PrimerApellido, SegundoApellido, FechaNacimiento, Sexo, Telefono, Telefono2, Correo,
                    IdArbitro, CostoArbitraje, IdCategoria, IdTipoArbitro);

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
        public IHttpActionResult PosttblArbitros(string Nombre, string PrimerApellido, string SegundoApellido, string FechaNacimiento,
                string Sexo, string Telefono, string Telefono2, string Correo, decimal CostoArbitraje, int IdCategoria, int IdTipoArbitro)
        {
            try
            {
                db.tblArbitrosAgregar(Nombre, PrimerApellido, SegundoApellido, FechaNacimiento, Sexo, Telefono, Telefono2, Correo, CostoArbitraje,
                    IdCategoria, IdTipoArbitro);
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
        public IHttpActionResult DeletetblArbitros(int IdArbitro)
        {
            tblArbitros tblArbitros = db.tblArbitros.Find(IdArbitro);
            if (tblArbitros == null)
            {
                return NotFound();
            }

            db.tblArbitrosEliminar(IdArbitro, 1);
            db.SaveChanges();

            return Ok(HttpStatusCode.OK);
        }

        // POST: api/tblJugadores
        [ResponseType(typeof(tblJugadores))]
        public IHttpActionResult PosttblArbitros(int IdArbitro)
        {
            tblArbitros tblArbitros = db.tblArbitros.Find(IdArbitro);
            if (tblArbitros == null)
            {
                return NotFound();
            }

            db.tblArbitrosEliminar(IdArbitro, 0);
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