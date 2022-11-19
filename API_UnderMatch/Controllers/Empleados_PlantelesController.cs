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
    public class Empleados_PlantelesController : ApiController
    {
        private BDUnderMatchEntities1 db = new BDUnderMatchEntities1();

        // GET: api/Empleados_Planteles
        public IQueryable<Empleados_Planteles> GetEmpleados_Planteles()
        {
            return db.Empleados_Planteles;
        }

        // GET: api/Empleados_Planteles/5
        [ResponseType(typeof(Empleados_Planteles))]
        public IHttpActionResult GetEmpleados_Planteles(int id)
        {
            Empleados_Planteles empleados_Planteles = db.Empleados_Planteles.Find(id);
            if (empleados_Planteles == null)
            {
                return NotFound();
            }

            return Ok(empleados_Planteles);
        }

        // PUT: api/Empleados_Planteles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmpleados_Planteles(int id, Empleados_Planteles empleados_Planteles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empleados_Planteles.IdRelacionEmpleadoPlantel)
            {
                return BadRequest();
            }

            db.Entry(empleados_Planteles).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Empleados_PlantelesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Empleados_Planteles
        [ResponseType(typeof(Empleados_Planteles))]
        public IHttpActionResult PostEmpleados_Planteles(Empleados_Planteles empleados_Planteles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Empleados_Planteles.Add(empleados_Planteles);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = empleados_Planteles.IdRelacionEmpleadoPlantel }, empleados_Planteles);
        }

        // DELETE: api/Empleados_Planteles/5
        [ResponseType(typeof(Empleados_Planteles))]
        public IHttpActionResult DeleteEmpleados_Planteles(int id)
        {
            Empleados_Planteles empleados_Planteles = db.Empleados_Planteles.Find(id);
            if (empleados_Planteles == null)
            {
                return NotFound();
            }

            db.Empleados_Planteles.Remove(empleados_Planteles);
            db.SaveChanges();

            return Ok(empleados_Planteles);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Empleados_PlantelesExists(int id)
        {
            return db.Empleados_Planteles.Count(e => e.IdRelacionEmpleadoPlantel == id) > 0;
        }
    }
}