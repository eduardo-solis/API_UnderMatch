using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Http.Results;
using System.Web.Mvc;
using API_UnderMatch.Models;
using Newtonsoft.Json;

namespace API_UnderMatch.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class tblProveedoresController : ApiController
    {
        private BDUnderMatchEntities1 db = new BDUnderMatchEntities1();

        // GET: api/tblProveedores
        public IQueryable<viewProveedores> GettblProveedores()
        {
            return db.viewProveedores;
        }

        // GET: api/tblProveedores/5
        [ResponseType(typeof(viewProveedores))]
        public IHttpActionResult GettblProveedores(int idProveedor)
        {
            try
            {
                viewProveedores proveedor = db.viewProveedores.Where(prov => prov.IdProveedor == idProveedor).FirstOrDefault();

                if (proveedor == null)
                    return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontró el proveedor"));

                return Ok(proveedor);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Ocurrió un error. " + e));
            }
        }

        // GET: api/tblProveedores/5
        [ResponseType(typeof(viewProveedores))]
        public IHttpActionResult GettblProveedores(string rfc)
        {
            try
            {
                IQueryable<viewProveedores> proveedores = db.viewProveedores.Where(proveedor => DbFunctions.Like(proveedor.Rfc.ToLower(), "%" + rfc.ToLower() + "%"));
                return Ok(proveedores);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Ocurrió un error. " + e));
            }
        }

        // PUT: api/tblProveedores/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblProveedores(int idProveedor, string rfc, string nombre, string razonSocial, string calle, string numero, string colonia,
            string codigoPostal, string ciudad, string estado, int idTipoProveedor, string correo, string telefono, int idPlantel)
        {
            try
            {
                List<tblProveedores> proveedor = db.tblProveedores.Where(prov => prov.Rfc.ToLower() == rfc.ToLower() && prov.IdProveedor != idProveedor).ToList();

                if (proveedor.Count > 0)
                    return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.Conflict, "Ocurrió un error. RFC existente"));
                else
                {
                    db.tblProveedoresModificar(idProveedor, rfc.ToUpper(), nombre, razonSocial, calle, numero, colonia, codigoPostal, ciudad, estado, idTipoProveedor,
                        correo, telefono, idPlantel);
                    db.SaveChanges();
                    return Json(new { Message = "Proveedor modificado con éxito" });
                }
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Ocurrió un error. " + e));
            }
        }

        // POST: api/tblProveedores
        [ResponseType(typeof(tblProveedores))]
        public IHttpActionResult PosttblProveedores(string rfc, string nombre, string razonSocial, string calle, string numero, string colonia, string codigoPostal,
            string ciudad, string estado, int idTipoProveedor, string correo, string telefono, int idPlantel)
        {
            try
            {
                List<tblProveedores> proveedor = db.tblProveedores.Where(prov => prov.Rfc.ToLower() == rfc.ToLower()).ToList();

                if (proveedor.Count > 0)
                    return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.Conflict, "Ocurrió un error. RFC existente"));
                else
                {
                    db.tblProveedoresAgregar(rfc.ToUpper(), nombre, razonSocial, calle, numero, colonia, codigoPostal, ciudad, estado, idTipoProveedor, correo, telefono,
                        idPlantel);
                    db.SaveChanges();
                    return Json(new { Message = "Proveedor agregado con éxito" });
                }

            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Ocurrió un error. " + e));
            }
        }

        // DELETE: api/tblProveedores/5
        [ResponseType(typeof(tblProveedores))]
        public IHttpActionResult DeletetblProveedores(int idProveedor)
        {
            try
            {
                tblProveedores proveedor = db.tblProveedores.Find(idProveedor);

                if (proveedor == null)
                    return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontró el proveedor"));

                db.tblProveedoresEliminar(idProveedor);
                db.SaveChanges();
                return Json(new { Message = "Proveedor eliminado con éxito" });
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Ocurrió un error. " + e));
            }
        }

        // PUT: api/tblProveedores/5
        [ResponseType(typeof(tblProveedores))]
        public IHttpActionResult PuttblProveedores(int idProveedor)
        {
            try
            {
                tblProveedores proveedor = db.tblProveedores.Find(idProveedor);

                if (proveedor == null)
                    return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontró el proveedor"));

                db.tblProveedoresActivar(idProveedor);
                db.SaveChanges();
                return Json(new { Message = "Proveedor activado con éxito" });
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Ocurrió un error. " + e));
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