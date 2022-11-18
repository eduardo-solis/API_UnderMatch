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
    public class tblEquiposController : ApiController
    {
        private BDUnderMatchEntities1 db = new BDUnderMatchEntities1();

        // GET: api/tblEquipos
        public IQueryable<tblEquipos> GettblEquipos()
        {
            return db.tblEquipos;
        }

        // GET: api/tblEquipos/5
        [ResponseType(typeof(tblEquipos))]
        public IHttpActionResult GettblEquipos(int id)
        {
            if (id < 0)
            {
                return BadRequest("Id invalido");
            }

            tblEquipos tblEquipos = db.tblEquipos.Find(id);

            if (tblEquipos == null)
            {
                return NotFound();
            }

            return Ok(tblEquipos);
        }

        // PUT: api/tblEquipos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblEquipos(int id, string Nombre, int Categoria, string AnioFundacion, string Zona, string ColorVisitante, string ColorLocal)
        {
            tblEquipos tblEquipos = new tblEquipos();

            tblEquipos.IdEquipo = id;
            tblEquipos.Nombre = Nombre;
            tblEquipos.Categoria = Categoria;
            tblEquipos.AnioFundacion = AnioFundacion;
            tblEquipos.Zona = Zona;
            tblEquipos.ColorVisitante = ColorVisitante;
            tblEquipos.ColorLocal = ColorLocal;
            tblEquipos.Estatus = 1;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(tblEquipos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblEquiposExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(tblEquipos);
        }

        // POST: api/tblEquipos
        [ResponseType(typeof(tblEquipos))]
        public IHttpActionResult PosttblEquipos(string Nombre, int Categoria, string AnioFundacion, string Zona, string ColorVisitante, string ColorLocal)
        {
            tblEquipos tblEquipos = new tblEquipos();

            tblEquipos.Nombre = Nombre;
            tblEquipos.Categoria = Categoria;
            tblEquipos.AnioFundacion = AnioFundacion;
            tblEquipos.Zona = Zona;
            tblEquipos.ColorVisitante = ColorVisitante;
            tblEquipos.ColorLocal = ColorLocal;
            tblEquipos.Estatus = 1;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblEquipos.Add(tblEquipos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblEquipos.IdEquipo }, tblEquipos);
        }

        // DELETE: api/tblEquipos/5
        [ResponseType(typeof(tblEquipos))]
        public IHttpActionResult DeletetblEquipos(int id, int operacion)
        {
            

            tblEquipos tblEquipos = db.tblEquipos.Find(id);
            if (tblEquipos == null)
            {
                return NotFound();
            }

            if(operacion == 0)
            {
                db.tblEquiposEliminar(tblEquipos.IdEquipo);
            }
            else
            {
                db.tblEquiposActivar(tblEquipos.IdEquipo);
            }
            db.SaveChanges();

            return Ok(tblEquipos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblEquiposExists(int id)
        {
            return db.tblEquipos.Count(e => e.IdEquipo == id) > 0;
        }
    }
}