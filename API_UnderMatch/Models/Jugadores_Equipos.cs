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
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class Jugadores_Equipos
    {
        public int IdRelacionJugadorEquipo { get; set; }
        public int IdJugador { get; set; }
        public int IdEquipo { get; set; }

        [JsonIgnore]
        public virtual tblEquipos tblEquipos { get; set; }
        [JsonIgnore]
        public virtual tblJugadores tblJugadores { get; set; }
    }
}
