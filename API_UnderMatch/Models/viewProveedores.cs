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
    
    public partial class viewProveedores
    {
        public int IdProveedor { get; set; }
        public string Rfc { get; set; }
        public string Nombre { get; set; }
        public string RazonSocial { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Colonia { get; set; }
        public string CodigoPostal { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public int TipoProveedor { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public int IdPlantel { get; set; }
        public Nullable<int> Estatus { get; set; }
        public string NombreTipoProveedor { get; set; }
        public string NombrePlantel { get; set; }
    }
}
