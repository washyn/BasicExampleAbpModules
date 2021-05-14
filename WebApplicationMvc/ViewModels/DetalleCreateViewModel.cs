using System;
using System.ComponentModel.DataAnnotations;
using WebApplicationMvc.Models;

namespace WebApplicationMvc.ViewModels
{
    public class DetalleCreateViewModel
    {
        

        public int Entero { get; set; }
        // public float Flotante { get; set; }
        // public PruebaEnum Enum { get; set; }
        [StringLength(255, MinimumLength = 2)]
        public string Cadena { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime FechaHora { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        
        [DataType(DataType.Time)]
        public DateTime Hora { get; set; }
        

        public decimal Decimanl { get; set; }
        public bool Booleano { get; set; }
        // public string NombreArchivo { get; set; }
        // public string Archivo { get; set; }
    }
}