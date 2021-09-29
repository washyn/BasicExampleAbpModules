using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationMvc.Models
{
    public class Maestro
    {
        public long Id { get; set; }
        
        [Column("NombreEntero", TypeName = "int")]
        public int? Entero { get; set; }
        public float? Flotante { get; set; }
        public PruebaEnum? Enum { get; set; }
        
        [Column("CualquierNombreDeCadena", TypeName = "nvarchar(max)")]
        public string? Cadena { get; set; }
        public DateTime? FechaHora { get; set; }
        public DateTime? Fecha { get; set; }
        public DateTime? Hora { get; set; }
        public decimal? Decimal { get; set; }
        
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaActualizacion { get; set; }

        public bool? Booleano { get; set; } = false;

        [NotMapped]
        public string ValorNoMapeado { get; set; }

        public IEnumerable<Detalle> Detalles { get; set; }
    }
}