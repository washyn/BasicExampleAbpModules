using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using WebApplicationMvc.Models;

namespace WebApplicationMvc.ViewModels
{
    /// <summary>
    /// ViewModel esta clase se utiliza como intermediario para crear una entidad
    /// Se Agrego propiedades de diferentes tipos y la manera de usarlos
    /// </summary>
    public class DetalleCreateViewModel
    {
        public int Entero { get; set; }
        
        public float Flotante { get; set; }
        
        [Display(Name = "Prueba enum")]
        [AbpRadioButton(Inline = true)]
        [Required]
        [EnumDataType(typeof(PruebaEnum))]
        public PruebaEnum Enum { get; set; }
        
        [StringLength(255, MinimumLength = 2)]
        public string Cadena { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime FechaHora { get; set; }
        
        [Required(ErrorMessage = "Este campo es requerido")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        
        [DataType(DataType.Time)]
        public DateTime Hora { get; set; }
        
        public decimal Decimanl { get; set; }
        
        public bool Booleano { get; set; }

        public int? MaestroId { get; set; }
        public IFormFile Archivo { get; set; }
        
    }
}