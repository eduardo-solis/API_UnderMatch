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
        public IHttpActionResult GettblEmpleados(int id)
        {
            tblEmpleados tblEmpleados = db.tblEmpleados.Find(id);
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
        public IHttpActionResult PuttblEmpleados(int idPersona, string Nombre, string PrimerApellido, string SegundoApellido, string FechaNacimiento, string Sexo, string Telefono, string Telefono2, string Correo, int idEmpleado, string CalleE, string NumeroE, string ColoniaE, string CodigoPostalE, string CiudadE, string EstadoE, string Curpe, int TipoEmpleado, string RfcE, string NssE, decimal SalarioE, string HorarioE)
        {

            db.tblEmpleadosModificar(idPersona, Nombre, PrimerApellido, SegundoApellido, FechaNacimiento, Sexo, Telefono, Telefono2, Correo, idEmpleado, CalleE, NumeroE, ColoniaE, CodigoPostalE, CiudadE, EstadoE, Curpe, TipoEmpleado, RfcE, NssE, SalarioE, HorarioE);

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
        public IHttpActionResult PosttblEmpleados(string Nombre, string PrimerApellido, string SegundoApellido, string FechaNacimiento, string Sexo, string Telefono, string Telefono2, string Correo, string CalleE, string NumeroE, string ColoniaE, string CodigoPostalE, string CiudadE, string EstadoE, string Curpe, int TipoEmpleado, string RfcE, string NssE, decimal SalarioE, string HorarioE, int IdPlantel)
        {
            try
            {
                db.tblEmpleadosAgregar(Nombre, PrimerApellido, SegundoApellido, FechaNacimiento, Sexo, Telefono, Telefono2, Correo, CalleE, NumeroE, ColoniaE, CodigoPostalE, CiudadE, EstadoE, Curpe, TipoEmpleado, RfcE, NssE, SalarioE, HorarioE, IdPlantel);
                db.SaveChanges();
                return StatusCode(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return BadRequest("Algo salio mal\n" + e);
            }
        }

        // POST: api/tblEmpleados
        [ResponseType(typeof(tblEmpleados))]
        public IHttpActionResult PosttblEmpleados(int idEmpleado)
        {
            tblEmpleados tblEmpleados = db.tblEmpleados.Find(idEmpleado);
            if (tblEmpleados == null)
            {
                return NotFound();
            }

            //db.tblEmpleados.Remove(tblEmpleados);
            db.tblEmpleadosActivar(idEmpleado);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.OK);
        }

        // DELETE: api/tblEmpleados
        [ResponseType(typeof(tblEmpleados))]
        public IHttpActionResult DeletetblEmpleados(int idEmpleado)
        {
            tblEmpleados tblEmpleados = db.tblEmpleados.Find(idEmpleado);
            if (tblEmpleados == null)
            {
                return NotFound();
            }

            db.tblEmpleadosEliminar(idEmpleado);
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