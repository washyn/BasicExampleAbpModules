using System;
using WebApplicationMvc.Models;

namespace WebApplicationMvc.ViewModels
{
    public class DetalleListItemViewModel
    {
        public int Id { get; set; }
        public float Flotante { get; set; }
        public PruebaEnum Enum { get; set; }
        public string Cadena { get; set; }
        public DateTime FechaHora { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public string NombreArchivo { get; set; }
    }
}