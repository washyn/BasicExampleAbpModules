using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using WebApplicationMvc.Models;

namespace WebApplicationMvc.ViewModels
{
    // modelo que servira para editar el detalle
    public class DetalleEditViewModel
    {
        public int Id { get; set; }
        public int Entero { get; set; }
        
        public float Flotante { get; set; }
        
        // campo requerido
        [Required]
        // tipo de dato enum
        [EnumDataType(typeof(PruebaEnum))]
        public PruebaEnum Enum { get; set; }
        
        // longitud maxima y minima
        [StringLength(255, MinimumLength = 2)]
        public string Cadena { get; set; }
        
        // tipo de dato fecha hora
        [DataType(DataType.DateTime)]
        public DateTime FechaHora { get; set; }
        
        // campo requerido con mesaje custom de error
        [Required(ErrorMessage = "Este campo es requerido")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        
        // tipo de dato hora
        [DataType(DataType.Time)]
        public DateTime Hora { get; set; }
        
        public decimal Decimanl { get; set; }
        
        public bool Booleano { get; set; }

        
        public IFormFile Archivo { get; set; }
    }
}