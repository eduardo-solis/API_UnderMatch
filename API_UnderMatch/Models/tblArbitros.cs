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
    
    public partial class tblArbitros
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblArbitros()
        {
            this.tblPartidos = new HashSet<tblPartidos>();
        }
    
        public int IdArbitro { get; set; }
        public int IdPersona { get; set; }
        public decimal CostoArbitraje { get; set; }
        public int Categoria { get; set; }
        public int TipoArbitro { get; set; }
        public Nullable<int> Estatus { get; set; }

        [JsonIgnore]
        public virtual ctgCategorias ctgCategorias { get; set; }
        [JsonIgnore]
        public virtual ctgTipoArbitros ctgTipoArbitros { get; set; }
        [JsonIgnore]
        public virtual tblPersonas tblPersonas { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPartidos> tblPartidos { get; set; }
    }
}
