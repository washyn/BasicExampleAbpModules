using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationMvc.Models
{
    //[Table("")]
    public class Detalle
    {
        public int Id { get; set; }

        public int Entero { get; set; }
        public float Flotante { get; set; }
        public PruebaEnum Enum { get; set; }
        public string Cadena { get; set; }
        public DateTime FechaHora { get; set; }

        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public decimal decimanl { get; set; }
        public bool booleano { get; set; }
        public string NombreArchivo { get; set; }
        public string Archivo { get; set; }
    }


    public enum PruebaEnum
    {
        Valor1,
        Valor2,
        Valor3,
    }

}
