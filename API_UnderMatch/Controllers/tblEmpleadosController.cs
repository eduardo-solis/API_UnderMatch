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

    [EnableCors(origins: "*", headers: "*", methods: "*")]
public class tblEmpleadosController : ApiController
    {
        private BDUnderMatchEntities1 db = new BDUnderMatchEntities1();

        // GET: api/tblEmpleados
        public IQueryable<viewEmpleados> GettblEmpleados()
        {
            DbSet<viewEmpleados> viewEmpleados = db.viewEmpleados;

            for (int i = 0; i < viewEmpleados.ToList().Count; i++)
            {
                // Se extrae el dato para manipular la informacion
                viewEmpleados view = viewEmpleados.ToList()[i];
                int idEmpleado = view.IdEmpleado;
                Empleados_Planteles Empleados_Planteles = db.Empleados_Planteles.Where(eP => eP.IdEmpleado == idEmpleado).First();//Find(viewEmpleados.ToList()[i].IdEmpleado);
                view.IdPlantel = Empleados_Planteles.IdPlantel;
                view.NombrePlantel = db.tblPlanteles.Find(Empleados_Planteles.IdPlantel).Nombre;

                // Se regresa el dato con la informacion actualizada
                viewEmpleados.ToList()[i] = view;
            }

            //return db.viewEmpleados;
            return viewEmpleados;
        }

        // GET: api/tblEmpleados/5
        [ResponseType(typeof(viewEmpleados))]
        public IHttpActionResult GettblEmpleados(int idEmpleado)
        {
            tblEmpleados tblEmpleados = db.tblEmpleados.Find(idEmpleado);
            tblPersonas tblPersonas = db.tblPersonas.Find(tblEmpleados.IdPersona);
            Empleados_Planteles Empleados_Planteles = db.Empleados_Planteles.Where(eP => eP.IdEmpleado == tblEmpleados.IdEmpleado).First();//Find(tblEmpleados.IdEmpleado);
            tblPlanteles tblPlanteles = db.tblPlanteles.Find(Empleados_Planteles.IdPlantel);

            if (tblEmpleados == null || tblPersonas == null)
            {
                return NotFound();
            }

            viewEmpleados viewEmpleados = new viewEmpleados
            {
                IdEmpleado = tblEmpleados.IdEmpleado,
                IdPersona = tblPersonas.IdPersona,
                Nombre = tblPersonas.Nombre,
                PrimerApellido = tblPersonas.PrimerApellido,
                SegundoApellido = tblPersonas.SegundoApellido,
                FechaNacimiento = tblPersonas.FechaNacimiento,
                Sexo = tblPersonas.Sexo,
                Telefono = tblPersonas.Telefono,
                Telefono2 = tblPersonas.Telefono2,
                Correo = tblPersonas.Correo,
                Calle = tblEmpleados.Calle,
                Numero = tblEmpleados.Numero,
                Colonia = tblEmpleados.Colonia,
                CodigoPostal = tblEmpleados.CodigoPostal,
                Ciudad = tblEmpleados.Ciudad,
                Estado = tblEmpleados.Estado,
                Curp = tblEmpleados.Curp,
                TipoEmpleado = tblEmpleados.TipoEmpleado,
                Rfc = tblEmpleados.Rfc,
                Nss = tblEmpleados.Nss,
                Salario = tblEmpleados.Salario,
                Horario = tblEmpleados.Horario,
                Estatus = tblEmpleados.Estatus,
                IdPlantel = tblPlanteles.IdPlantel,
                NombrePlantel = tblPlanteles.Nombre
            };

            return Ok(viewEmpleados);
        }

        // PUT: api/tblEmpleados/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblEmpleados(int idPersona, string nombre, string primerApellido, string segundoApellido, string fechaNacimiento, string sexo, string telefono, string telefono2, string correo, int idEmpleado, string calleE, string numeroE, string coloniaE, string codigoPostalE, string ciudadE, string estadoE, string curpe, int tipoEmpleado, string rfcE, string nssE, decimal salarioE, string horarioE)
        {

            db.tblEmpleadosModificar(idPersona, nombre, primerApellido, segundoApellido, fechaNacimiento, sexo, telefono, telefono2, correo, idEmpleado, calleE, numeroE, coloniaE, codigoPostalE, ciudadE, estadoE, curpe, tipoEmpleado, rfcE, nssE, salarioE, horarioE);

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
        public IHttpActionResult PosttblEmpleados(string nombre, string primerApellido, string segundoApellido, string fechaNacimiento, string sexo, string telefono, string telefono2, string correo, string calleE, string numeroE, string coloniaE, string codigoPostalE, string ciudadE, string estadoE, string curpe, int tipoEmpleado, string rfcE, string nssE, decimal salarioE, string horarioE)
        {
            try
            {
                db.tblEmpleadosAgregar(nombre, primerApellido, segundoApellido, fechaNacimiento, sexo, telefono, telefono2, correo, calleE, numeroE, coloniaE, codigoPostalE, ciudadE, estadoE, curpe, tipoEmpleado, rfcE, nssE, salarioE, horarioE);
                db.SaveChanges();
                return StatusCode(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return BadRequest("Algo salio mal\n" + e);
            }
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