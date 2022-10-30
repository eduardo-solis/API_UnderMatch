using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API_UnderMatch.Models
{
    [MetadataType(typeof(tblEquipos.MetaData))]
    public partial class tblEquipos
    {
        sealed class MetaData
        {

            [Required]
            [StringLength(100)]
            public string Nombre;

            [Required]
            public int Categoria;

            [Required]
            [StringLength(4)]
            public string AnioFundacion;

            [Required]
            [StringLength(100)]
            public string Zona;

            [Required]
            [StringLength(100)]
            public string ColorVisitante;

            [Required]
            [StringLength(100)]
            public string ColorLocal;

        }
    }
}