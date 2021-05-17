using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplicationMvc.Models;

namespace WebApplicationMvc.ViewModels.Maestro
{
    public class MaestroListItemViewModel
    {
        public long Id { get; set; }
        
        public int? Entero { get; set; }
        public float? Flotante { get; set; }
        public PruebaEnum? Enum { get; set; }
        public string? Cadena { get; set; }
        public DateTime? FechaHora { get; set; }
        public DateTime? Fecha { get; set; }
        public DateTime? Hora { get; set; }
        public decimal? Decimal { get; set; }
        
        // Valor por defecto fecha de creacion
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaActualizacion { get; set; }

        // Ejemplo de valor por defecto
        public bool? Booleano { get; set; } = false;

        [NotMapped]
        public string ValorNoMapeado { get; set; }

        [NotMapped]
        public int CantidadDetalles { get; set; }
        
        // public IEnumerable<Detalle> Detalles { get; set; }
    }
}