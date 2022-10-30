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
    
    public partial class tblEquipos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblEquipos()
        {
            this.Jugadores_Equipos = new HashSet<Jugadores_Equipos>();
            this.tblPartidos = new HashSet<tblPartidos>();
            this.tblPartidos1 = new HashSet<tblPartidos>();
        }
    
        public int IdEquipo { get; set; }
        public string Nombre { get; set; }
        public int Categoria { get; set; }
        public string AnioFundacion { get; set; }
        public string Zona { get; set; }
        public string ColorVisitante { get; set; }
        public string ColorLocal { get; set; }
        public Nullable<int> Estatus { get; set; }

        [JsonIgnore]
        public virtual ctgCategorias ctgCategorias { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Jugadores_Equipos> Jugadores_Equipos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<tblPartidos> tblPartidos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<tblPartidos> tblPartidos1 { get; set; }
    }
}
