using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API_UnderMatch.Models
{
    [MetadataType(typeof(tblJugadores.MetaData))]
    public partial class tblJugadores
    {
        sealed class MetaData
        {
            public int IdJugador;
            public int IdPersona;

            [Required]
            [StringLength(3)]
            public string NumDorsal;

            [StringLength(100)]
            public string SobreNombre;

            [Required]
            [StringLength(100)]
            public string Posicion;

            public int Capitan;
        }
    }
}