using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationMvc.Models
{
    /// <summary>
    /// La Clase que representa una columna en la base de datos
    /// </summary>
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
        [Display(Name = "Valor1")]
        Valor1,
        [Display(Name = "Valor2")]
        Valor2,
        [Display(Name = "Valor3")]
        Valor3,
    }
    
}
