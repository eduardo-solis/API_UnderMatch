//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class viewJugadores
    {
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string Telefono { get; set; }
        public string Telefono2 { get; set; }
        public string Correo { get; set; }
        public int IdJugador { get; set; }
        public int IdPersona { get; set; }
        public string NumDorsal { get; set; }
        public string SobreNombre { get; set; }
        public string Posicion { get; set; }
        public Nullable<int> Capitan { get; set; }
        public Nullable<int> Estatus { get; set; }
        public Nullable<int> IdEquipo { get; set; }
        public string Equipo { get; set; }
    }
}
