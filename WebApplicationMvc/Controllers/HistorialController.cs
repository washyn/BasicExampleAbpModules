using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApplicationMvc.EfCore;
using WebApplicationMvc.Models;
using WebApplicationMvc.Services;
using WebApplicationMvc.ViewModels;
using WebApplicationMvc.ViewModels.Cita;
using WkHtmlToPdfDotNet;
using WkHtmlToPdfDotNet.Contracts;

namespace WebApplicationMvc.Controllers
{
    [Authorize(Roles = Rol.Asistente + "," + Rol.Medico)]
    public class HistorialController : Controller
    {
        private readonly ServiceList _serviceList;
        private readonly IConverter _converter;
        private readonly ILogger<HistorialController> _logger;
        private readonly IViewRenderService _renderService;
        private readonly IHostEnvironment _hostEnvironment;
        private readonly ApplicationDbContex _dbContex;

        public HistorialController(Services.ServiceList serviceList,
            IConverter converter,
            ILogger<HistorialController> logger,
            IViewRenderService renderService,
            IHostEnvironment hostEnvironment,
            ApplicationDbContex dbContex)
        {
            _serviceList = serviceList;
            _converter = converter;
            _logger = logger;
            _renderService = renderService;
            _hostEnvironment = hostEnvironment;
            _dbContex = dbContex;
        }

        public IActionResult Index(int? pacienteId)
        {
            ViewData["pacienteId"] = pacienteId;
            ViewData["pacientes"] = _serviceList.GetPacientes();
            
            var historia = new List<HistoriaPaciente>();

            if (pacienteId.HasValue)
            {
                var paciente = _dbContex.Usuarios.FirstOrDefault(a => a.Id == pacienteId.Value);
                ViewData["nombre"] = paciente.ToString();
                // categoria is missed
                var atenciones = _dbContex.Atencions
                    .Include(a => a.Cita)
                    .Include(a => a.UsuarioDoctor)
                    .Where(a => a.UsuarioPacienteId == pacienteId.Value)
                    .Select(a => new HistoriaPaciente()
                    {
                        Diagnostico = a.Diagnostico,
                        FechaAtencion = a.Fecha,
                        Doctor = a.UsuarioDoctor.ToString(),
                        Id = a.Id,
                        Categoria = a.Cita.Categoria
                    })
                    .ToList();
                
                historia.AddRange(atenciones);
            }
            return View(historia);
        }

        public IActionResult PruebaRender(int id)
        {
            // TODO:
            // fix why not include cita ???
            var data = _dbContex.Atencions
                .Include(a => a.Cita)
                .Include(a => a.UsuarioDoctor)
                .Include(a => a.UsuarioPaciente)
                .FirstOrDefault(c => c.Id == id);
            
            var model = new AtencionPdfViewModel()
            {
                // Categoria = data.Cita.Categoria,
                Numero = data.Id,
                Diagnostico = data.Diagnostico,
                Fecha = data.Fecha,
                Receta = data.Receta,
                Recomendaciones = data.Recomendaciones,
                UsuarioDoctor = data.UsuarioDoctor.ToString(),
                UsuarioPaciente = data.UsuarioPaciente.ToString()
            };
            return View("/Views/Historial/AtencionPdf.cshtml", model);
        }
        
        [AllowAnonymous]
        public async Task<IActionResult> PruebaPdfExport(int historiaId)
        {
            _logger.LogInformation(historiaId.ToString());
            _logger.LogInformation(System.Text.Encoding.UTF8.BodyName);
            var fechaAtencion = DateTime.Now.ToShortDateString();

            var data = _dbContex.Atencions
                .Include(a => a.Cita)
                .Include(a => a.UsuarioDoctor)
                .Include(a => a.UsuarioPaciente)
                .FirstOrDefault(c => c.Id == historiaId);
            
            var model = new AtencionPdfViewModel()
            {
                // Categoria = data.Cita.Categoria,
                Numero = data.Id,
                Diagnostico = data.Diagnostico,
                Fecha = data.Fecha,
                Receta = data.Receta,
                Recomendaciones = data.Recomendaciones,
                UsuarioDoctor = data.UsuarioDoctor.ToString(),
                UsuarioPaciente = data.UsuarioPaciente.ToString()
            };
            
            // WebApplicationMvc/Views/Historial/AtencionPdf.cshtml
            // var html = await _renderService.RederToStringAsync(@"\Historial\AtencionPdf.cshtml", model);
            var html = await _renderService.RederToStringAsync(@"/Views/Historial/AtencionPdf.cshtml", model);
            // D:\github\MVC\WebApplicationMvc\wwwroot\lib\bootstrap\dist\css\bootstrap.css
            var cssPath = Path.Combine(_hostEnvironment.ContentRootPath, @"lib\bootstrap\dist\css\bootstrap.css");
            _logger.LogInformation(cssPath);
            var document = new HtmlToPdfDocument()
            {
                GlobalSettings = new GlobalSettings()
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        HtmlContent = html,
                        PagesCount = true,
                        WebSettings = new WebSettings()
                        {
                            // DefaultEncoding = System.Text.Encoding.Get
                            DefaultEncoding = System.Text.Encoding.UTF8.BodyName,
                            // DefaultEncoding = System.Text.Encoding.UTF8.EncodingName,
                            // UserStyleSheet = cssPath
                        }
                    }
                }
            };
            
            var fileContent = _converter.Convert(document);
            
            return File(fileContent, 
                MediaTypeNames.Application.Pdf, 
                $"{fechaAtencion}.pdf");
        }
        
    }
}