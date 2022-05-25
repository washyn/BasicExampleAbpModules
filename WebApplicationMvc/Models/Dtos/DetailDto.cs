using System;
using Volo.Abp.Application.Dtos;

namespace WebApplicationMvc.Models.Dtos
{
    public class DetailDto : EntityDto<int>
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
}