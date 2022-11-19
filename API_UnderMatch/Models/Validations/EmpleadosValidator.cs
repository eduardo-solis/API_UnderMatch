using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API_UnderMatch.Models
{
    [MetadataType(typeof(tblEmpleados.MetaData))]
    public partial class tblEmpleados
    {
        sealed class MetaData
        {
            public int IdEmpleado;
            public int IdPersona;

            [Required]
            [StringLength(100)]
            public string Calle;

            [StringLength(50)]
            public string Numero;

            [StringLength(100)]
            public string Colonia;

            [StringLength(5)]
            public string CodigoPostal;

            [StringLength(100)]
            public string Ciudad;

            [StringLength(100)]
            public string Estado;

            [StringLength(18)]
            public string Curp;

            public int TipoEmpleado;

            [StringLength(13)]
            public string Rfc;
            [StringLength(11)]
            public string Nss;
            public decimal Salario;
            [StringLength(50)]
            public string Horario;



        }
    }
}