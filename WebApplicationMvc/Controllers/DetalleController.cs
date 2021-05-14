using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationMvc.EfCore;
using WebApplicationMvc.Models;
using WebApplicationMvc.ViewModels;

namespace WebApplicationMvc.Controllers
{
    public class DetalleController : Controller
    {
        private readonly ApplicationDbContex _dbContex;

        public DetalleController(ApplicationDbContex dbContex)
        {
            _dbContex = dbContex;
        }

        public IActionResult Index()
        {
            var datos = _dbContex.Detalles.AsNoTracking();
            return View(datos);
        }
        
        public IActionResult ShowDetails(int? id)
        {
            if (id.HasValue)
            {
                // search
            }
            return View();
        }
        
        public IActionResult Edit(int? id)
        {
            return View();
        }
        
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create([FromForm]DetalleCreateViewModel input)
        {
            if (ModelState.IsValid)
            {
                _dbContex.Detalles.Add(new Detalle()
                {
                    Entero = input.Entero,
                    Cadena = input.Cadena,
                    FechaHora = input.FechaHora,
                    Fecha = input.Fecha,
                    Hora = input.Hora,
                    decimanl = input.Decimanl,
                    booleano = input.Booleano,
                });
                _dbContex.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(input);
        }
    }
}
