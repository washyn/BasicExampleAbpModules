﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using WebApplicationMvc.Models;

namespace WebApplicationMvc.ViewModels
{
    public class DetalleEditViewModel
    {
        public int Id { get; set; }
        public int Entero { get; set; }
        
        public float Flotante { get; set; }
        
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