using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using API_UnderMatch.Models;
using Newtonsoft.Json;

namespace API_UnderMatch.Controllers
{
    public class tblProveedoresController : ApiController
    {
        private BDUnderMatchEntities1 db = new BDUnderMatchEntities1();

        // GET: api/tblProveedores
        public IQueryable<tblProveedores> GettblProveedores()
        {
            return db.tblProveedores;
        }

        // GET: api/tblProveedores/5
        [ResponseType(typeof(tblProveedores))]
        public IHttpActionResult GettblProveedores(int idProveedor)
        {
            tblProveedores tblProveedores = db.tblProveedores.Find(idProveedor);
            if (tblProveedores == null)
            {
                return NotFound();
            }

            return Ok(tblProveedores);
        }

        // PUT: api/tblProveedores/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblProveedores(int idProveedor, string rfc, string nombre, string razonSocial, string calle, string numero, string colonia, string codigoPostal, string ciudad, string estado, int idTipoProveedor, string correo, string telefono, int idPlantel)
        {
            try
            {
                db.tblProveedoresModificar(idProveedor, rfc, nombre, razonSocial, calle, numero, colonia, codigoPostal, ciudad, estado, idTipoProveedor, correo, telefono, idPlantel);
                db.SaveChanges();
                return StatusCode(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return BadRequest("Algo salio mal\n" + e);
            }
        }

        // POST: api/tblProveedores
        [ResponseType(typeof(tblProveedores))]
        public IHttpActionResult PosttblProveedores(string rfc, string nombre, string razonSocial, string calle, string numero, string colonia, string codigoPostal, string ciudad, string estado, int idTipoProveedor, string correo, string telefono, int idPlantel)
        {
            try
            {
                db.tblProveedoresAgregar(rfc, nombre, razonSocial, calle, numero, colonia, codigoPostal, ciudad, estado, idTipoProveedor, correo, telefono, idPlantel);
                db.SaveChanges();
                return StatusCode(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return BadRequest("Algo salio mal\n" + e);
            }
        }

        // DELETE: api/tblProveedores/5
        [ResponseType(typeof(tblProveedores))]
        public IHttpActionResult DeletetblProveedores(int idProveedor)
        {
            tblProveedores tblProveedores = db.tblProveedores.Find(idProveedor);
            if (tblProveedores == null)
            {
                return NotFound();
            }

            try
            {
                db.tblProveedoresEliminar(idProveedor);
                db.SaveChanges();
                return StatusCode(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return BadRequest("Algo salio mal\n" + e);
            }
        }

        // PUT: api/tblProveedores/5
        [ResponseType(typeof(tblProveedores))]
        public IHttpActionResult PuttblProveedores(int idProveedor)
        {
            tblProveedores tblProveedores = db.tblProveedores.Find(idProveedor);
            if (tblProveedores == null)
            {
                return NotFound();
            }

            try
            {
                db.tblProveedoresActivar(idProveedor);
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

        private bool tblProveedoresExists(int id)
        {
            return db.tblProveedores.Count(e => e.IdProveedor == id) > 0;
        }
    }
}