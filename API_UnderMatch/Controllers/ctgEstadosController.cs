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
    public class ctgEstadosController : ApiController
    {
        private BDUnderMatchEntities1 db = new BDUnderMatchEntities1();

        // GET: api/ctgEstados
        public IQueryable<ctgEstados> GetctgEstados()
        {
            return db.ctgEstados;
        }

        // GET: api/ctgEstados/5
        [ResponseType(typeof(ctgEstados))]
        public IHttpActionResult GetctgEstados(int id)
        {
            ctgEstados ctgEstados = db.ctgEstados.Find(id);
            if (ctgEstados == null)
            {
                return NotFound();
            }

            return Ok(ctgEstados);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ctgEstadosExists(int id)
        {
            return db.ctgEstados.Count(e => e.IdEstado == id) > 0;
        }
    }
}