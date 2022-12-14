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
    public class ctgTipoProveedoresController : ApiController
    {
        private BDUnderMatchEntities1 db = new BDUnderMatchEntities1();

        // GET: api/ctgTipoProveedores
        public IQueryable<ctgTipoProveedores> GetctgTipoProveedores()
        {
            return db.ctgTipoProveedores;
        }

        // GET: api/ctgTipoProveedores/5
        [ResponseType(typeof(ctgTipoProveedores))]
        public IHttpActionResult GetctgTipoProveedores(int idTipoProveedor)
        {
            ctgTipoProveedores ctgTipoProveedores = db.ctgTipoProveedores.Find(idTipoProveedor);
            if (ctgTipoProveedores == null)
            {
                return NotFound();
            }

            return Ok(ctgTipoProveedores);
        }

        // PUT: api/ctgTipoProveedores/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutctgTipoProveedores(int idTipoProveedor, string nombre)
        {
            try
            {
                List<ctgTipoProveedores> tipoProveedores = db.ctgTipoProveedores.Where(tipoProv => tipoProv.Nombre.ToLower() == nombre.ToLower() && tipoProv.IdTipoProveedor != idTipoProveedor).ToList();

                if (tipoProveedores.Count > 0)
                    return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.Conflict, "Ocurrió un error. Nombre existente"));

                db.ctgTipoProveedoresModificar(idTipoProveedor, nombre);
                db.SaveChanges();
                return StatusCode(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return BadRequest("Algo salio mal\n" + e);
            }
        }

        // POST: api/ctgTipoProveedores
        [ResponseType(typeof(ctgTipoProveedores))]
        public IHttpActionResult PostctgTipoProveedores(string nombre)
        {
            try
            {
                List<ctgTipoProveedores> tipoProveedores = db.ctgTipoProveedores.Where(tipoProv => tipoProv.Nombre.ToLower() == nombre.ToLower()).ToList();

                if (tipoProveedores.Count > 0)
                    return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.Conflict, "Ocurrió un error. Nombre existente"));

                db.ctgTipoProveedoresAgregar(nombre);
                db.SaveChanges();
                return StatusCode(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return BadRequest("Algo salio mal\n" + e);
            }
        }

        // DELETE: api/ctgTipoProveedores/5
        [ResponseType(typeof(ctgTipoProveedores))]
        public IHttpActionResult DeletectgTipoProveedores(int idTipoProveedor, int operacion)
        {
            ctgTipoProveedores ctgTipoProveedores = db.ctgTipoProveedores.Find(idTipoProveedor);
            if (ctgTipoProveedores == null)
            {
                return NotFound();
            }

            try
            {
                if ( operacion == 0 ) //Eliminar
                {
                    db.ctgTipoProveedoresEliminar(idTipoProveedor);
                    
                }
                else
                {
                    db.ctgTipoProveedoresActivar(idTipoProveedor);
                }

                db.SaveChanges();

                return StatusCode(HttpStatusCode.OK);

            }
            catch (Exception e)
            {
                return BadRequest("Algo salio mal\n" + e);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ctgTipoProveedoresExists(int id)
        {
            return db.ctgTipoProveedores.Count(e => e.IdTipoProveedor == id) > 0;
        }
    }
}