using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API_UnderMatch.Models
{
    [MetadataType(typeof(tblPersonas.MetaData))]
    public partial class tblPersonas
    {
        sealed class MetaData
        {
            
            public int IdPersona;

            [Required]
            [StringLength(80)]
            public string Nombre;

            [Required]
            [StringLength(80)]
            public string PrimerApellido;

            [StringLength(80)]
            public string SegundoApellido;

            [Required]
            [StringLength(10)]
            public string FechaNacimiento;

            [Required]
            [StringLength(30)]
            public string Sexo;

            [Required]
            [StringLength(10)]
            public string Telefono;

            [StringLength(10)]
            public string Telefono2;

            [Required]
            [StringLength(100)]
            [EmailAddress]
            public string Correo;
        }
    }
}