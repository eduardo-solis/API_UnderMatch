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
    public class tblLogsController : ApiController
    {
        private BDUnderMatchEntities1 db = new BDUnderMatchEntities1();

        // GET: api/ctgCategorias
        public IQueryable<tblLogs> GettblLogss()
        {
            return db.tblLogs;
        }

        // GET: api/ctgCategorias/5
        [ResponseType(typeof(tblLogs))]
        public IHttpActionResult GettblLogss(int idBitacora)
        {
            tblLogs tblLogs = db.tblLogs.Find(idBitacora);
            if (tblLogs == null)
            {
                return NotFound();
            }

            return Ok(tblLogs);
        }

        // POST: api/tblLogs
        [ResponseType(typeof(tblLogs))]
        public IHttpActionResult PosttblLogs(int idUsuario, string nombreUsuario, string tablaAfectada, string accion, string descripcion)
        {

            tblLogs tblLogs = new tblLogs
            {
                IdUsuario = idUsuario,
                NombreUsuario = nombreUsuario,
                TablaAfectada = tablaAfectada,
                Accion = accion,
                Descripcion = descripcion
            };

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblLogs.Add(tblLogs);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblLogs.IdBitacora }, tblLogs);
        }

       
    }
}