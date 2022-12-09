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
public class tblEmpleadosController : ApiController
    {
        private BDUnderMatchEntities1 db = new BDUnderMatchEntities1();

        // GET: api/tblEmpleados
        public IQueryable<viewEmpleados> GettblEmpleados()
        {
            return db.viewEmpleados;
        }

        // GET: api/tblEmpleados/5
        [ResponseType(typeof(viewEmpleados))]
        public IHttpActionResult GettblEmpleados(int idEmpleado)
        {
            viewEmpleados viewEmpleados = db.viewEmpleados.Where(empleado => empleado.IdEmpleado == idEmpleado).FirstOrDefault();

            if (viewEmpleados == null)
            {
                return NotFound();
            }

            return Ok(viewEmpleados);
        }



        // PUT: api/tblEmpleados/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblEmpleados(int idPersona, string nombre, string primerApellido, string segundoApellido, string fechaNacimiento, string sexo, string telefono, string telefono2, string correo, int idEmpleado, string calleE, string numeroE, string coloniaE, string codigoPostalE, int idMunicipioE, string curpe, int tipoEmpleado, string rfcE, string nssE, decimal salarioE, string horarioE)
        {

            db.tblEmpleadosModificar(idPersona, nombre, primerApellido, segundoApellido, fechaNacimiento, sexo, telefono, telefono2, correo, idEmpleado, calleE, numeroE, coloniaE, codigoPostalE, idMunicipioE, curpe, tipoEmpleado, rfcE, nssE, salarioE, horarioE);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();

            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/tblEmpleados
        [ResponseType(typeof(tblEmpleados))]
        public IHttpActionResult PosttblEmpleados(string nombre, string primerApellido, string segundoApellido, string fechaNacimiento, string sexo, string telefono, string telefono2, string correo, string calleE, string numeroE, string coloniaE, string codigoPostalE, int idMunicipioE, string curpe, int tipoEmpleado, string rfcE, string nssE, decimal salarioE, string horarioE)
        {
            try
            {
                db.tblEmpleadosAgregar(nombre, primerApellido, segundoApellido, fechaNacimiento, sexo, telefono, telefono2, correo, calleE, numeroE, coloniaE, codigoPostalE, idMunicipioE, curpe, tipoEmpleado, rfcE, nssE, salarioE, horarioE);
                db.SaveChanges();
                return StatusCode(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return BadRequest("Algo salio mal\n" + e);
            }
        }

        public IHttpActionResult GettblEmpleadosAuth(string pEmail, string pPassword)
        {
            viewEmpleados viewEmpleados = db.viewEmpleados.Where(empleado => empleado.Correo == pEmail && empleado.Curp == pPassword).FirstOrDefault();

            if (viewEmpleados == null)
            {
                return NotFound();
            }

            return Ok(viewEmpleados);
        }

        // DELETE: api/tblEmpleados
        [ResponseType(typeof(tblEmpleados))]
        public IHttpActionResult DeletetblEmpleados(int idEmpleado, int operacion)
        {
            tblEmpleados tblEmpleados = db.tblEmpleados.Find(idEmpleado);
            if (tblEmpleados == null)
            {
                return NotFound();
            }

            if ( operacion == 0 )
            {
                db.tblEmpleadosEliminar(idEmpleado);
            }
            else
            {
                db.tblEmpleadosActivar(idEmpleado);
            }

            db.SaveChanges();

            return StatusCode(HttpStatusCode.OK);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblEmpleadosExists(int id)
        {
            return db.tblEmpleados.Count(e => e.IdEmpleado == id) > 0;
        }
    }
}