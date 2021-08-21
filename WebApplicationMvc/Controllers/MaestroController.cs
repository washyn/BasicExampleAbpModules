using System;
using System.IO;
using System.Linq;
using System.Net.Mime;
using Ganss.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationMvc.EfCore;
using WebApplicationMvc.Models;
using WebApplicationMvc.ViewModels;
using WebApplicationMvc.ViewModels.Maestro;
using WkHtmlToPdfDotNet;
using WkHtmlToPdfDotNet.Contracts;

namespace WebApplicationMvc.Controllers
{
    [Authorize]
    public class MaestroController : Controller
    {
        private readonly ApplicationDbContex _dbContex;
        private readonly IConverter _converter;

        public MaestroController(ApplicationDbContex dbContex,
            IConverter converter)
        {
            _dbContex = dbContex;
            _converter = converter;
        }

        // los Usuarios con rol de usuario o admin pueden entrar a la pagina de inicio(index)
        // este controlador solo sería accesible para los usuarios que son miembros del rol Admin o del rol Usuario .
        [Authorize(Roles = "Admin,Usuario")]
        public IActionResult Index(PruebaEnum? pruebaEnum, bool? booleano, int? cantidadDetalle)
        {
            ViewData["pruebaEnum"] = pruebaEnum;
            ViewData["booleano"] = booleano;
            ViewData["cantidadDetalle"] = cantidadDetalle;

            var datos = _dbContex.Maestros
                .AsNoTracking()
                .Select(a => new MaestroListItemViewModel()
                {
                    Cadena = a.Cadena,
                    Enum = a.Enum,
                    Fecha = a.Fecha,
                    Flotante = a.Flotante,
                    Hora = a.Hora,
                    Id = a.Id,
                    FechaHora = a.FechaHora,
                    Booleano = a.Booleano,
                    Decimal = a.Decimal,
                    Entero = a.Entero,
                    CantidadDetalles = _dbContex.Detalles.Count(b => b.MaestroId == a.Id),
                    FechaActualizacion = a.FechaActualizacion,
                    FechaCreacion = a.FechaCreacion,
                });

            if (booleano.HasValue)
            {
                datos = datos.Where(s => s.Booleano == booleano);
            }

            if (pruebaEnum.HasValue)
            {
                datos = datos.Where(s => s.Enum == pruebaEnum);
            }

            if (cantidadDetalle.HasValue)
            {
                datos = datos.Where(s => s.CantidadDetalles == cantidadDetalle);
            }

            return View(datos.ToList());
        }


        // el usuario que accede debe ser miembro de todos los roles especificados;
        // el siguiente ejemplo requiere que un usuario sea miembro del rol Admin y Usuario.

        // [Authorize(Roles = Rol.Admin)]
        // [Authorize(Roles = Rol.Usuario)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] MaestroCreateEditViewModel input)
        {
            // public int? Entero { get; set; }
            // public string? Cadena { get; set; }
            // public DateTime? FechaHora { get; set; }

            // public float? Flotante { get; set; }
            // public PruebaEnum? Enum { get; set; }
            // public DateTime? Fecha { get; set; }

            // public DateTime? Hora { get; set; }
            // public decimal? Decimal { get; set; }

            if (ModelState.IsValid)
            {
                var newModel = new Maestro()
                {
                    Entero = input.Entero,
                    Cadena = input.Cadena,
                    FechaHora = input.FechaHora,

                    Flotante = input.Flotante,
                    Enum = input.Enum,
                    Fecha = input.Fecha,

                    Hora = input.Hora,
                    Decimal = input.Decimal
                };

                _dbContex.Maestros.Add(newModel);
                _dbContex.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(input);
        }


        public IActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var model = _dbContex.Maestros
                    .Where(b => b.Id == id)
                    .Select(a => new MaestroCreateEditViewModel()
                    {
                        Cadena = a.Cadena,
                        Entero = a.Entero,
                        Enum = a.Enum,
                        Fecha = a.Fecha,
                        Flotante = a.Flotante,
                        Hora = a.Hora,
                        FechaHora = a.FechaHora,
                        Id = a.Id,
                        Decimal = a.Decimal
                    })
                    .FirstOrDefault();
                return View(model);
            }

            return View();
        }


        [HttpPost]
        public IActionResult Edit(MaestroCreateEditViewModel input)
        {
            if (ModelState.IsValid)
            {
                // TODO: esto no es correcto se puede guardar el archivo en un folder
                // o un array de bytes en base de datos como blob

                var modelEdit = _dbContex.Maestros.FirstOrDefault(a => a.Id == input.Id);

                // public int? Entero { get; set; }
                // public float? Flotante { get; set; }
                // public PruebaEnum? Enum { get; set; }
                //
                // [MaxLength(250)]
                // public string? Cadena { get; set; }
                // public DateTime? FechaHora { get; set; }
                // public DateTime? Fecha { get; set; }
                // public DateTime? Hora { get; set; }
                // public decimal? Decimal { get; set; }

                modelEdit.Entero = input.Entero;
                modelEdit.Flotante = input.Flotante;
                modelEdit.Enum = input.Enum;

                modelEdit.Cadena = input.Cadena;
                modelEdit.FechaHora = input.FechaHora;
                modelEdit.Fecha = input.Fecha;
                modelEdit.Hora = input.Hora;

                modelEdit.Decimal = input.Decimal;
                modelEdit.FechaActualizacion = DateTime.Now;

                _dbContex.Maestros.Update(modelEdit);
                _dbContex.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(input);
        }

        [Authorize(Roles = Rol.Usuario)]
        public IActionResult ShowDetails(int? detalle)
        {
            if (detalle.HasValue)
            {
                // la cosa es que aqui no se incluye detalles eso es aparte al parecer
                var detail = _dbContex.Maestros
                    .FirstOrDefault(a => a.Id == detalle);
                if (detail is not null)
                {
                    detail.Detalles = _dbContex.Detalles.Where(a => a.MaestroId == detail.Id);
                    return View(detail);
                }
            }

            return NotFound();
        }


        [Authorize(Roles = Rol.Admin)]
        public IActionResult ShowForDelete(int? id)
        {
            if (id.HasValue)
            {
                var detail = _dbContex.Maestros.FirstOrDefault(a => a.Id == id);
                if (detail is not null)
                {
                    return View(detail);
                }
            }

            return NotFound();
        }


        [Authorize(Roles = Rol.Admin)]
        public IActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var detail = _dbContex.Maestros.FirstOrDefault(a => a.Id == id);
                if (detail is not null)
                {
                    _dbContex.Maestros.Remove(detail);
                    _dbContex.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }

            return NotFound();
        }


        public IActionResult PruebaPdfExport()
        {
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
                        HtmlContent =
                            @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. In consectetur mauris eget ultrices  iaculis.",
                        PagesCount = true,
                        WebSettings = new WebSettings()
                        {
                            // DefaultEncoding = System.Text.Encoding.Get
                            DefaultEncoding = "UTF-8",
                            UserStyleSheet = ""
                        }
                    }
                }
            };

            var fileContent = _converter.Convert(document);

            return File(fileContent,
                MediaTypeNames.Application.Pdf,
                $"{Guid.NewGuid().ToString()}.pdf");
        }

        public IActionResult PruebaExcel()
        {
            using var ms = new MemoryStream();
            var excelMapper = new ExcelMapper();


            var datos = _dbContex.Maestros
                .AsNoTracking()
                .Select(a => new MaestroListItemViewModel()
                {
                    Cadena = a.Cadena,
                    Enum = a.Enum,
                    Fecha = a.Fecha,
                    Flotante = a.Flotante,
                    Hora = a.Hora,
                    Id = a.Id,
                    FechaHora = a.FechaHora,
                    Booleano = a.Booleano,
                    Decimal = a.Decimal,
                    Entero = a.Entero,
                    FechaActualizacion = a.FechaActualizacion,
                    FechaCreacion = a.FechaCreacion,
                })
                .ToArray();
            
            excelMapper.Save(ms, datos, xlsx: true);
            return File(ms.ToArray(), MediaTypeNames.Application.Octet, $"{Guid.NewGuid().ToString()}.xlsx");
        }
    }
}