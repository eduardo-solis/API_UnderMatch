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

namespace API_UnderMatch.Controllers
{
    public class tblPlantelesController : ApiController
    {
        private BDUnderMatchEntities1 db = new BDUnderMatchEntities1();

        // GET: api/tblPlanteles
        public IQueryable<tblPlanteles> GettblPlanteles()
        {
            return db.tblPlanteles;
        }

        // GET: api/tblPlanteles/5
        [ResponseType(typeof(tblPlanteles))]
        public IHttpActionResult GettblPlanteles(int id)
        {
            tblPlanteles tblPlanteles = db.tblPlanteles.Find(id);
            if (tblPlanteles == null)
            {
                return NotFound();
            }

            return Ok(tblPlanteles);
        }

        // PUT: api/tblPlanteles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblPlanteles(int id, tblPlanteles tblPlanteles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblPlanteles.IdPlantel)
            {
                return BadRequest();
            }

            db.Entry(tblPlanteles).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblPlantelesExists(id))
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

        // POST: api/tblPlanteles
        [ResponseType(typeof(tblPlanteles))]
        public IHttpActionResult PosttblPlanteles(tblPlanteles tblPlanteles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblPlanteles.Add(tblPlanteles);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblPlanteles.IdPlantel }, tblPlanteles);
        }

        // DELETE: api/tblPlanteles/5
        [ResponseType(typeof(tblPlanteles))]
        public IHttpActionResult DeletetblPlanteles(int id)
        {
            tblPlanteles tblPlanteles = db.tblPlanteles.Find(id);
            if (tblPlanteles == null)
            {
                return NotFound();
            }

            db.tblPlanteles.Remove(tblPlanteles);
            db.SaveChanges();

            return Ok(tblPlanteles);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblPlantelesExists(int id)
        {
            return db.tblPlanteles.Count(e => e.IdPlantel == id) > 0;
        }
    }
}