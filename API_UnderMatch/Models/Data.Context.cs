﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API_UnderMatch.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BDUnderMatchEntities1 : DbContext
    {
        public BDUnderMatchEntities1()
            : base("name=BDUnderMatchEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ctgCategorias> ctgCategorias { get; set; }
        public virtual DbSet<ctgTipoArbitros> ctgTipoArbitros { get; set; }
        public virtual DbSet<ctgTipoEmpleados> ctgTipoEmpleados { get; set; }
        public virtual DbSet<ctgTipoProveedores> ctgTipoProveedores { get; set; }
        public virtual DbSet<Jugadores_Equipos> Jugadores_Equipos { get; set; }
        public virtual DbSet<tblArbitros> tblArbitros { get; set; }
        public virtual DbSet<tblCanchas> tblCanchas { get; set; }
        public virtual DbSet<tblEmpleados> tblEmpleados { get; set; }
        public virtual DbSet<tblEquipos> tblEquipos { get; set; }
        public virtual DbSet<tblJugadores> tblJugadores { get; set; }
        public virtual DbSet<tblPartidos> tblPartidos { get; set; }
        public virtual DbSet<tblPersonas> tblPersonas { get; set; }
        public virtual DbSet<tblPlanteles> tblPlanteles { get; set; }
        public virtual DbSet<tblProveedores> tblProveedores { get; set; }
        public virtual DbSet<tblTemporadas> tblTemporadas { get; set; }
        public virtual DbSet<viewJugadores> viewJugadores { get; set; }
        public virtual DbSet<viewProveedores> viewProveedores { get; set; }
    
        public virtual int tblJugadoresAgregar(string nombre, string primerApellido, string segundoApellido, string fechaNacimiento, string sexo, string telefono, string telefono2, string correo, string numDorsal, string sobreNombre, string posicion, Nullable<int> capitan, Nullable<int> idEquipo)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var primerApellidoParameter = primerApellido != null ?
                new ObjectParameter("PrimerApellido", primerApellido) :
                new ObjectParameter("PrimerApellido", typeof(string));
    
            var segundoApellidoParameter = segundoApellido != null ?
                new ObjectParameter("SegundoApellido", segundoApellido) :
                new ObjectParameter("SegundoApellido", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento != null ?
                new ObjectParameter("FechaNacimiento", fechaNacimiento) :
                new ObjectParameter("FechaNacimiento", typeof(string));
    
            var sexoParameter = sexo != null ?
                new ObjectParameter("Sexo", sexo) :
                new ObjectParameter("Sexo", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var telefono2Parameter = telefono2 != null ?
                new ObjectParameter("Telefono2", telefono2) :
                new ObjectParameter("Telefono2", typeof(string));
    
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            var numDorsalParameter = numDorsal != null ?
                new ObjectParameter("NumDorsal", numDorsal) :
                new ObjectParameter("NumDorsal", typeof(string));
    
            var sobreNombreParameter = sobreNombre != null ?
                new ObjectParameter("SobreNombre", sobreNombre) :
                new ObjectParameter("SobreNombre", typeof(string));
    
            var posicionParameter = posicion != null ?
                new ObjectParameter("Posicion", posicion) :
                new ObjectParameter("Posicion", typeof(string));
    
            var capitanParameter = capitan.HasValue ?
                new ObjectParameter("Capitan", capitan) :
                new ObjectParameter("Capitan", typeof(int));
    
            var idEquipoParameter = idEquipo.HasValue ?
                new ObjectParameter("IdEquipo", idEquipo) :
                new ObjectParameter("IdEquipo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("tblJugadoresAgregar", nombreParameter, primerApellidoParameter, segundoApellidoParameter, fechaNacimientoParameter, sexoParameter, telefonoParameter, telefono2Parameter, correoParameter, numDorsalParameter, sobreNombreParameter, posicionParameter, capitanParameter, idEquipoParameter);
        }
    
        public virtual int tblJugadoresEliminar(Nullable<int> idJugador)
        {
            var idJugadorParameter = idJugador.HasValue ?
                new ObjectParameter("IdJugador", idJugador) :
                new ObjectParameter("IdJugador", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("tblJugadoresEliminar", idJugadorParameter);
        }
    
        public virtual int tblJugadoresModificar(Nullable<int> idPersona, string nombre, string primerApellido, string segundoApellido, string fechaNacimiento, string sexo, string telefono, string telefono2, string correo, Nullable<int> idJugador, string numDorsal, string sobreNombre, string posicion, Nullable<int> capitan, Nullable<int> idEquipo)
        {
            var idPersonaParameter = idPersona.HasValue ?
                new ObjectParameter("IdPersona", idPersona) :
                new ObjectParameter("IdPersona", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var primerApellidoParameter = primerApellido != null ?
                new ObjectParameter("PrimerApellido", primerApellido) :
                new ObjectParameter("PrimerApellido", typeof(string));
    
            var segundoApellidoParameter = segundoApellido != null ?
                new ObjectParameter("SegundoApellido", segundoApellido) :
                new ObjectParameter("SegundoApellido", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento != null ?
                new ObjectParameter("FechaNacimiento", fechaNacimiento) :
                new ObjectParameter("FechaNacimiento", typeof(string));
    
            var sexoParameter = sexo != null ?
                new ObjectParameter("Sexo", sexo) :
                new ObjectParameter("Sexo", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var telefono2Parameter = telefono2 != null ?
                new ObjectParameter("Telefono2", telefono2) :
                new ObjectParameter("Telefono2", typeof(string));
    
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            var idJugadorParameter = idJugador.HasValue ?
                new ObjectParameter("IdJugador", idJugador) :
                new ObjectParameter("IdJugador", typeof(int));
    
            var numDorsalParameter = numDorsal != null ?
                new ObjectParameter("NumDorsal", numDorsal) :
                new ObjectParameter("NumDorsal", typeof(string));
    
            var sobreNombreParameter = sobreNombre != null ?
                new ObjectParameter("SobreNombre", sobreNombre) :
                new ObjectParameter("SobreNombre", typeof(string));
    
            var posicionParameter = posicion != null ?
                new ObjectParameter("Posicion", posicion) :
                new ObjectParameter("Posicion", typeof(string));
    
            var capitanParameter = capitan.HasValue ?
                new ObjectParameter("Capitan", capitan) :
                new ObjectParameter("Capitan", typeof(int));
    
            var idEquipoParameter = idEquipo.HasValue ?
                new ObjectParameter("IdEquipo", idEquipo) :
                new ObjectParameter("IdEquipo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("tblJugadoresModificar", idPersonaParameter, nombreParameter, primerApellidoParameter, segundoApellidoParameter, fechaNacimientoParameter, sexoParameter, telefonoParameter, telefono2Parameter, correoParameter, idJugadorParameter, numDorsalParameter, sobreNombreParameter, posicionParameter, capitanParameter, idEquipoParameter);
        }
    
        public virtual int tblEquiposActivar(Nullable<int> iD_EQUIPO)
        {
            var iD_EQUIPOParameter = iD_EQUIPO.HasValue ?
                new ObjectParameter("ID_EQUIPO", iD_EQUIPO) :
                new ObjectParameter("ID_EQUIPO", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("tblEquiposActivar", iD_EQUIPOParameter);
        }
    
        public virtual int tblEquiposEliminar(Nullable<int> iD_EQUIPO)
        {
            var iD_EQUIPOParameter = iD_EQUIPO.HasValue ?
                new ObjectParameter("ID_EQUIPO", iD_EQUIPO) :
                new ObjectParameter("ID_EQUIPO", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("tblEquiposEliminar", iD_EQUIPOParameter);
        }
    
        public virtual int tblJugadoresActivar(Nullable<int> idJugador)
        {
            var idJugadorParameter = idJugador.HasValue ?
                new ObjectParameter("IdJugador", idJugador) :
                new ObjectParameter("IdJugador", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("tblJugadoresActivar", idJugadorParameter);
        }
    
        public virtual int ctgTipoProveedoresActivar(Nullable<int> idTipoProveedor)
        {
            var idTipoProveedorParameter = idTipoProveedor.HasValue ?
                new ObjectParameter("IdTipoProveedor", idTipoProveedor) :
                new ObjectParameter("IdTipoProveedor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ctgTipoProveedoresActivar", idTipoProveedorParameter);
        }
    
        public virtual int ctgTipoProveedoresAgregar(string nombre)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ctgTipoProveedoresAgregar", nombreParameter);
        }
    
        public virtual int ctgTipoProveedoresEliminar(Nullable<int> idTipoProveedor)
        {
            var idTipoProveedorParameter = idTipoProveedor.HasValue ?
                new ObjectParameter("IdTipoProveedor", idTipoProveedor) :
                new ObjectParameter("IdTipoProveedor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ctgTipoProveedoresEliminar", idTipoProveedorParameter);
        }
    
        public virtual int ctgTipoProveedoresModificar(Nullable<int> idTipoProveedor, string nombre)
        {
            var idTipoProveedorParameter = idTipoProveedor.HasValue ?
                new ObjectParameter("IdTipoProveedor", idTipoProveedor) :
                new ObjectParameter("IdTipoProveedor", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ctgTipoProveedoresModificar", idTipoProveedorParameter, nombreParameter);
        }
    
        public virtual int tblProveedoresActivar(Nullable<int> idProveedor)
        {
            var idProveedorParameter = idProveedor.HasValue ?
                new ObjectParameter("IdProveedor", idProveedor) :
                new ObjectParameter("IdProveedor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("tblProveedoresActivar", idProveedorParameter);
        }
    
        public virtual int tblProveedoresAgregar(string rfc, string nombre, string razonSocial, string calle, string numero, string colonia, string codigoPostal, string ciudad, string estado, Nullable<int> idTipoProveedor, string correo, string telefono, Nullable<int> idPlantel)
        {
            var rfcParameter = rfc != null ?
                new ObjectParameter("Rfc", rfc) :
                new ObjectParameter("Rfc", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var razonSocialParameter = razonSocial != null ?
                new ObjectParameter("RazonSocial", razonSocial) :
                new ObjectParameter("RazonSocial", typeof(string));
    
            var calleParameter = calle != null ?
                new ObjectParameter("Calle", calle) :
                new ObjectParameter("Calle", typeof(string));
    
            var numeroParameter = numero != null ?
                new ObjectParameter("Numero", numero) :
                new ObjectParameter("Numero", typeof(string));
    
            var coloniaParameter = colonia != null ?
                new ObjectParameter("Colonia", colonia) :
                new ObjectParameter("Colonia", typeof(string));
    
            var codigoPostalParameter = codigoPostal != null ?
                new ObjectParameter("CodigoPostal", codigoPostal) :
                new ObjectParameter("CodigoPostal", typeof(string));
    
            var ciudadParameter = ciudad != null ?
                new ObjectParameter("Ciudad", ciudad) :
                new ObjectParameter("Ciudad", typeof(string));
    
            var estadoParameter = estado != null ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(string));
    
            var idTipoProveedorParameter = idTipoProveedor.HasValue ?
                new ObjectParameter("IdTipoProveedor", idTipoProveedor) :
                new ObjectParameter("IdTipoProveedor", typeof(int));
    
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var idPlantelParameter = idPlantel.HasValue ?
                new ObjectParameter("IdPlantel", idPlantel) :
                new ObjectParameter("IdPlantel", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("tblProveedoresAgregar", rfcParameter, nombreParameter, razonSocialParameter, calleParameter, numeroParameter, coloniaParameter, codigoPostalParameter, ciudadParameter, estadoParameter, idTipoProveedorParameter, correoParameter, telefonoParameter, idPlantelParameter);
        }
    
        public virtual int tblProveedoresEliminar(Nullable<int> idProveedor)
        {
            var idProveedorParameter = idProveedor.HasValue ?
                new ObjectParameter("IdProveedor", idProveedor) :
                new ObjectParameter("IdProveedor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("tblProveedoresEliminar", idProveedorParameter);
        }
    
        public virtual int tblProveedoresModificar(Nullable<int> idProveedor, string rfc, string nombre, string razonSocial, string calle, string numero, string colonia, string codigoPostal, string ciudad, string estado, Nullable<int> idTipoProveedor, string correo, string telefono, Nullable<int> idPlantel)
        {
            var idProveedorParameter = idProveedor.HasValue ?
                new ObjectParameter("IdProveedor", idProveedor) :
                new ObjectParameter("IdProveedor", typeof(int));
    
            var rfcParameter = rfc != null ?
                new ObjectParameter("Rfc", rfc) :
                new ObjectParameter("Rfc", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var razonSocialParameter = razonSocial != null ?
                new ObjectParameter("RazonSocial", razonSocial) :
                new ObjectParameter("RazonSocial", typeof(string));
    
            var calleParameter = calle != null ?
                new ObjectParameter("Calle", calle) :
                new ObjectParameter("Calle", typeof(string));
    
            var numeroParameter = numero != null ?
                new ObjectParameter("Numero", numero) :
                new ObjectParameter("Numero", typeof(string));
    
            var coloniaParameter = colonia != null ?
                new ObjectParameter("Colonia", colonia) :
                new ObjectParameter("Colonia", typeof(string));
    
            var codigoPostalParameter = codigoPostal != null ?
                new ObjectParameter("CodigoPostal", codigoPostal) :
                new ObjectParameter("CodigoPostal", typeof(string));
    
            var ciudadParameter = ciudad != null ?
                new ObjectParameter("Ciudad", ciudad) :
                new ObjectParameter("Ciudad", typeof(string));
    
            var estadoParameter = estado != null ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(string));
    
            var idTipoProveedorParameter = idTipoProveedor.HasValue ?
                new ObjectParameter("IdTipoProveedor", idTipoProveedor) :
                new ObjectParameter("IdTipoProveedor", typeof(int));
    
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var idPlantelParameter = idPlantel.HasValue ?
                new ObjectParameter("IdPlantel", idPlantel) :
                new ObjectParameter("IdPlantel", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("tblProveedoresModificar", idProveedorParameter, rfcParameter, nombreParameter, razonSocialParameter, calleParameter, numeroParameter, coloniaParameter, codigoPostalParameter, ciudadParameter, estadoParameter, idTipoProveedorParameter, correoParameter, telefonoParameter, idPlantelParameter);
        }
    }
}
