using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationMvc.CustomHandler;
using WebApplicationMvc.EfCore;
using WebApplicationMvc.Models;
using WebApplicationMvc.ViewModels;

namespace WebApplicationMvc.Controllers
{
    /// <summary>
    /// Authorize -> esto para que requiera solo usuarios que esten logeados puedan accecder a los metodos
    /// Los controlladores deben heredar de la clase base, Controller para que sea un controlador, tambien debe de tener
    /// el sufijo controller, esto se puede cambiar pero por convecion se hace asi. 
    /// </summary>
    [Authorize]
    public class DetalleController : Controller
    {
        private readonly ApplicationDbContex _dbContex;

        public DetalleController(ApplicationDbContex dbContex)
        {
            _dbContex = dbContex;
        }


        /// <summary>
        /// La accion con el nombre Index, es la que hara llamado por default cuando se
        /// entra a la ruta "/detalle"
        /// </summary>
        /// <param name="InputSearch"></param>
        /// <param name="FloatMin"></param>
        /// <param name="FloatMax"></param>
        /// <param name="FechaMin"></param>
        /// <param name="FechaMax"></param>
        /// <returns></returns>
        public IActionResult Index(string InputSearch,
            float? FloatMin,
            float? FloatMax,
            DateTime? FechaMin,
            DateTime? FechaMax
        )
        {
            ViewData["TextoBusqueda"] = InputSearch;
            ViewData["FloatMin"] = FloatMin;
            ViewData["FloatMax"] = FloatMax;

            ViewData["FechaMin"] = FechaMin;
            ViewData["FechaMax"] = FechaMax;

            // AsNoTracking, normalmente cuando se obtiene datos, EF hace tracking de las entidades, esto para cuando
            // se modifica propiedades de una entidad y se haga el save changes, EF pueda saber que entidades fueron editadas
            // y hacer el update,
            // para este caso se obtiene una lista para visualizar, entonces no es necesario el tracking 
            // por eso se le pone AsNoTracking
            var datos = _dbContex.Detalles
                .AsNoTracking()
                .Select(a => new DetalleListItemViewModel
                {
                    Cadena = a.Cadena,
                    Enum = a.Enum,
                    Fecha = a.Fecha,
                    Flotante = a.Flotante,
                    Hora = a.Hora,
                    Id = a.Id,
                    FechaHora = a.FechaHora,
                    NombreArchivo = a.NombreArchivo
                })
                //TODO: create PR with hasValue method, string extenson has value, in abp lib
                .WhereIf(!string.IsNullOrEmpty(InputSearch),
                    s => s.Cadena.Contains(InputSearch))
                
                .WhereIf(FloatMin.HasValue,
                    s => s.Flotante >= FloatMin)
                .WhereIf(FloatMax.HasValue,
                    s => s.Flotante <= FloatMax)

                .WhereIf(FechaMin.HasValue,
                    s => s.Fecha >= FechaMin)
                .WhereIf(FechaMax.HasValue,
                    s => s.Fecha <= FechaMax)
                .ToList();
            
            return View(datos);
        }

        public IActionResult ShowDetails(int? id)
        {
            if (id.HasValue)
            {
                var detail = _dbContex.Detalles
                    .Where(a => a.Id == id)
                    .AsNoTracking()
                    .FirstOrDefault();

                if (detail is not null)
                {
                    detail.Maestro = _dbContex.Maestros.FirstOrDefault(a => a.Id == detail.MaestroId);
                    return View(detail);
                }
            }

            return NotFound();
        }


        public IActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var model = _dbContex.Detalles
                    .Where(b => b.Id == id)
                    .Select(a => new DetalleEditViewModel()
                    {
                        Booleano = a.booleano,
                        Cadena = a.Cadena,
                        Decimanl = a.decimanl,
                        Entero = a.Entero,
                        Enum = a.Enum,
                        Fecha = a.Fecha,
                        Flotante = a.Flotante,
                        Hora = a.Hora,
                        FechaHora = a.FechaHora,
                        Id = a.Id,
                        MaestroId = a.MaestroId
                    })
                    .FirstOrDefault();
                ViewData["SelectList"] = new SelectList(_dbContex.Maestros, "Id", "Cadena", model.MaestroId);
                return View(model);
            }

            return View();
        }

        [HttpPost]
        public IActionResult Edit(DetalleEditViewModel input)
        {
            if (ModelState.IsValid)
            {
                // TODO: esto no es correcto se puede guardar el archivo en un folder
                // o un array de bytes en base de datos como blob

                var modelEdit = _dbContex.Detalles.FirstOrDefault(a => a.Id == input.Id);

                modelEdit.booleano = input.Booleano;
                modelEdit.decimanl = input.Decimanl;
                modelEdit.Cadena = input.Cadena;
                modelEdit.Entero = input.Entero;
                modelEdit.Enum = input.Enum;
                modelEdit.Fecha = input.Fecha;
                modelEdit.Flotante = input.Flotante;
                modelEdit.Hora = input.Hora;
                modelEdit.FechaHora = input.FechaHora;
                modelEdit.MaestroId = input.MaestroId;

                if (input.Archivo != null)
                {
                    byte[] fileData;
                    var ms = new MemoryStream();
                    input.Archivo.CopyTo(ms);
                    fileData = ms.ToArray();
                    var fileContent = Convert.ToBase64String(fileData);

                    modelEdit.NombreArchivo = input.Archivo.FileName;
                    modelEdit.Archivo = fileContent;
                }

                _dbContex.Detalles.Update(modelEdit);
                _dbContex.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            ViewData["ManyId"] = new SelectList(_dbContex.Maestros, "Id", "Cadena", input.MaestroId);
            return View(input);
        }


        public IActionResult Create()
        {
            ViewData["SelectList"] = new SelectList(_dbContex.Maestros, "Id", "Cadena");
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] DetalleCreateViewModel input)
        {
            if (ModelState.IsValid)
            {
                var newModel = new Detalle()
                {
                    Entero = input.Entero,
                    Cadena = input.Cadena,
                    FechaHora = input.FechaHora,
                    Fecha = input.Fecha,
                    Hora = input.Hora,
                    decimanl = input.Decimanl,
                    booleano = input.Booleano,
                    Enum = input.Enum,
                    Flotante = input.Flotante,
                    MaestroId = input.MaestroId
                };

                if (input.Archivo != null)
                {
                    var ms = new MemoryStream();
                    input.Archivo.CopyTo(ms);
                    var fileData = ms.ToArray();
                    var fileContent = Convert.ToBase64String(fileData);

                    newModel.Archivo = fileContent;
                    newModel.NombreArchivo = input.Archivo.FileName;
                }

                _dbContex.Detalles.Add(newModel);
                _dbContex.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewData["SelectList"] = new SelectList(_dbContex.Maestros, "Id", "Cadena", input.MaestroId);
            return View(input);
        }


        public IActionResult ShowForDelete(int? id)
        {
            if (id.HasValue)
            {
                var detail = _dbContex.Detalles.FirstOrDefault(a => a.Id == id);
                if (detail is not null)
                {
                    return View(detail);
                }
            }

            return NotFound();
        }

        public IActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var detail = _dbContex.Detalles.FirstOrDefault(a => a.Id == id);
                if (detail is not null)
                {
                    _dbContex.Detalles.Remove(detail);
                    _dbContex.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }

            return NotFound();
        }


        public IActionResult GetFile(int? id)
        {
            if (id.HasValue)
            {
                var model = _dbContex.Detalles.FirstOrDefault(a => a.Id == id);
                return File(Convert.FromBase64String(model.Archivo),
                    System.Net.Mime.MediaTypeNames.Application.Octet, model.NombreArchivo);
            }

            return NotFound();
        }
    }
}