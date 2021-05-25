using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationMvc.EfCore;
using WebApplicationMvc.Models;
using WebApplicationMvc.ViewModels;

namespace WebApplicationMvc.Controllers
{
    /// <summary>
    /// Controller de Tabla detalle
    /// </summary>
    public class DetalleController : Controller
    {
        private readonly ApplicationDbContex _dbContex;

        public DetalleController(ApplicationDbContex dbContex)
        {
            _dbContex = dbContex;
        }

        
        // index para mostrar los registros
        public IActionResult Index()
        {
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
                });
            return View(datos);
        }
        
        // para mostrar los detalles
        public IActionResult ShowDetails(int? id)
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
        
        // accion para mostrar el modelo a editar
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
                    Id = a.Id
                })
                    .FirstOrDefault();
                return View(model);
            }
            return View();
        }
        
        // accion para editar
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
                
                // si hay un archivo se guarda
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
            return View(input);
        }
        
        // vista de crear
        public IActionResult Create()
        {
            return View();
        }
        
        // Accion de crear
        [HttpPost]
        public IActionResult Create([FromForm]DetalleCreateViewModel input)
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
                };

                if (input.Archivo != null)
                {
                    var ms = new MemoryStream();
                    input.Archivo.CopyTo(ms);
                    var fileData = ms.ToArray();
                    // se guarda el archivo en base 64
                    var fileContent = Convert.ToBase64String(fileData);
                    
                    newModel.Archivo = fileContent;
                    newModel.NombreArchivo = input.Archivo.FileName;
                }
                
                _dbContex.Detalles.Add(newModel);
                _dbContex.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(input);
        }
        
        
        // mostrar elemento para eliminar
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
        
        // eliminar el elemento en si
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

        // accion para descargar el archivo subido en 
        // resvibe el id del registro
        public IActionResult GetFile(int? id)
        {
            if (id.HasValue)
            {
                // se obtiene el registro en de base de datos
                var model = _dbContex.Detalles.FirstOrDefault(a => a.Id == id);
                
                // se retorna el archivo, antes se convierte de base64 a bytes
                return File(Convert.FromBase64String(model.Archivo),
                    System.Net.Mime.MediaTypeNames.Application.Octet, model.NombreArchivo);
            }

            return NotFound();
        }
        
    }
}
