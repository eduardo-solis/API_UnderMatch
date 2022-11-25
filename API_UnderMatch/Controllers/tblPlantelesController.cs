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
    public class tblPlantelesController : ApiController
    {
        private BDUnderMatchEntities1 db = new BDUnderMatchEntities1();

        // GET: api/tblPlanteles
        public IQueryable<viewPlanteles> GettblPlanteles()
        {
            return db.viewPlanteles;
        }

        // GET: api/tblPlanteles/5
        [ResponseType(typeof(viewPlanteles))]
        public IHttpActionResult GettblPlanteles(int idPlantel)
        {
            viewPlanteles tblPlanteles = db.viewPlanteles.Where(plantel => plantel.IdPlantel == idPlantel).FirstOrDefault();
            
            if (tblPlanteles == null)
            {
                return NotFound();
            }

            return Ok(tblPlanteles);
        }

        // PUT: api/tblPlanteles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblPlanteles(int idPlantel, string nombre, string calle, string numero, string colonia, string codigoPostal, int idMunicipio)
        {

            tblPlanteles tblPlanteles = new tblPlanteles
            {
                IdPlantel = idPlantel,
                Nombre = nombre,
                Calle = calle,
                Numero = numero,
                Colonia = colonia,
                CodigoPostal = codigoPostal,
                IdMunicipio = idMunicipio,
                Estatus = 1
            };

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(tblPlanteles).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblPlantelesExists(idPlantel))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.OK);
        }

        // POST: api/tblPlanteles
        [ResponseType(typeof(tblPlanteles))]
        public IHttpActionResult PosttblPlanteles(string nombre, string calle, string numero, string colonia, string codigoPostal, int idMunicipio)
        {

            tblPlanteles tblPlanteles = new tblPlanteles
            {
                Nombre = nombre,
                Calle = calle,
                Numero = numero,
                Colonia = colonia,
                CodigoPostal = codigoPostal,
                IdMunicipio = idMunicipio,
                Estatus = 1
            };

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
        public IHttpActionResult DeletetblPlanteles(int idPlantel, int operacion)
        {
            tblPlanteles tblPlanteles = db.tblPlanteles.Find(idPlantel);
            if (tblPlanteles == null)
            {
                return NotFound();
            }

            if ( operacion == 0)
            {
                db.tblPlantelEliminar(idPlantel);
            }
            else
            {
                db.tblPlantelActivar(idPlantel);
            }

            db.SaveChanges();

            return Ok();
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