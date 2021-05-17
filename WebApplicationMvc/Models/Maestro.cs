using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationMvc.Models
{
    /// <summary>
    /// la tabla en base de datos se genero a partir de este modelo con ef core
    /// </summary>
    public class Maestro
    {
        public long Id { get; set; }
        
        [Column("NombreEntero", TypeName = "int")]
        public int? Entero { get; set; }
        public float? Flotante { get; set; }
        public PruebaEnum? Enum { get; set; }
        
        // Ejemplo de Custom column name and value type
        [Column("CualquierNombreDeCadena", TypeName = "nvarchar(max)")]
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

        public IEnumerable<Detalle> Detalles { get; set; }
    }
}