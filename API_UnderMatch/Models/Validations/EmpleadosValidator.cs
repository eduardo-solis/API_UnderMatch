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
            public string CalleE;

            [StringLength(50)]
            public string NumeroE;

            [StringLength(100)]
            public string ColoniaE;

            [StringLength(5)]
            public string CoidgoPostalE;

            [StringLength(100)]
            public string CiudadE;

            [StringLength(100)]
            public string EstadoE;

            [StringLength(18)]
            public string Curpe;

            public int TipoEmpleado;

            [StringLength(13)]
            public string RfcE;
            [StringLength(11)]
            public string nSSe;
            public decimal Salario;
            [StringLength(50)]
            public string HorarioE;



        }
    }
}