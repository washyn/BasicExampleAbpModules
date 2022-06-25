using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using WebApplicationMvc.EfCore;
using WebApplicationMvc.Models;
using WebApplicationMvc.ViewModels;

namespace WebApplicationMvc.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContex _dbContex;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContex dbContex)
        {
            _logger = logger;
            _dbContex = dbContex;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = Rol.Medico)]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        [Authorize(Roles = Rol.Asistente + "," + Rol.Medico)]
        public IActionResult Dashboard()
        {
            var model = _dbContex.Citas
                .Include(a => a.UsuarioPaciente)
                .Where(a => a.Estado == EstadoCita.Atendido)
                .OrderByDescending(a => a.FechaHora)
                .Select(a => new PacientesRecientesViewModel()
                {
                    Categoria = a.Categoria,
                    Nombres = a.UsuarioPaciente.ToString(),
                    FechaHora = a.FechaHora
                })
                .Take(10)
                .ToList();
            return View(model);
        }

        public IActionResult TipoAtencion()
        {
            var model = _dbContex.Citas
                .GroupBy(a => a.Categoria)
                .Select(a => new DonutChartViewModel()
                {
                    Label = a.Key,
                    Value = a.Count(),
                })
                .ToList();
            return Json(model);
        }
        
        public IActionResult AtencionesMensual()
        {
            var culture = new CultureInfo("es-cl");
            var date = DateTime.Now;
            var dat1 = date.AddMonths(1);
            var junio = culture.DateTimeFormat.GetMonthName(date.Month);
            var julio = culture.DateTimeFormat.GetMonthName(dat1.Month);
            
            var modeljunio = _dbContex.Citas
                .Count(a => a.FechaHora.Year == date.Date.Year && a.FechaHora.Month == date.Date.Month);
            
            var modeljulio = _dbContex.Citas
                .Count(a => a.FechaHora.Year == dat1.Date.Year && a.FechaHora.Month == dat1.Date.Month);

            return Json(new List<BarChart>()
            {
                new BarChart()
                {
                    Month = junio,
                    Data = modeljunio,
                },
                new BarChart()
                {
                    Month = julio,
                    Data = modeljulio
                }
            });
        }
    }
}
