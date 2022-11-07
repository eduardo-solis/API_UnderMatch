using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API_UnderMatch.Models
{
    [MetadataType(typeof(ctgCategorias.MetaData))]
    public partial class ctgCategorias
    {
        sealed class MetaData
        {
            [Required]
            [StringLength(100)]
            public string Categoria;
        }
    }
}