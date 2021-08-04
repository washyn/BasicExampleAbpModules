using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using WebApplicationMvc.Models;

namespace WebApplicationMvc.ViewModels.Maestro
{
    public class MaestroCreateEditViewModel
    {
        public long Id { get; set; }
        
        public int? Entero { get; set; }
        public float? Flotante { get; set; }
        public PruebaEnum? Enum { get; set; }
        
        [TextArea(Rows = 5)]
        [MaxLength(250)]
        public string? Cadena { get; set; }
        public DateTime? FechaHora { get; set; }
        public DateTime? Fecha { get; set; }
        public DateTime? Hora { get; set; }
        public decimal? Decimal { get; set; }
        
    }
}