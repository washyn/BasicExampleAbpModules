using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using WebApplicationMvc.EfCore;
using WebApplicationMvc.Models;
using WebApplicationMvc.Models.Dtos;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace WebApplicationMvc.Controllers
{
    // [RemoteService()] // can be use this decorator for mark this as remote service
    // by default create proxy scripts for call this services
    [Route("api/detail")]
    [ApiController]
    public class ApiDetailController : ControllerBase
        // , IRemoteService
    {
        private readonly IRepository<Detalle, int> _detalleRepository;

        public ApiDetailController(IRepository<Detalle, int> detalleRepository)
        {
            _detalleRepository = detalleRepository;
        }
        
        // ok
        [HttpGet]
        public async Task<PagedResultDto<Detalle>> GetListAsync([FromQuery] DetailsFilter filter)
        {
            var queryable = await _detalleRepository.GetQueryableAsync();

            var count = await queryable.WhereIf(!string.IsNullOrEmpty(filter.Filter), detalle => detalle.Cadena.Contains(filter.Filter))
                .CountAsync();
            
            var res = await queryable.WhereIf(!string.IsNullOrEmpty(filter.Filter), detalle => detalle.Cadena.Contains(filter.Filter))
                .OrderBy(filter.Sorting)
                .Skip(filter.SkipCount)
                .Take(filter.MaxResultCount)
                .ToListAsync();
            
            return new PagedResultDto<Detalle>()
            {
                TotalCount = count,
                Items = res
            };
        }
        // ok
        [Route("{id}")]
        [HttpGet]
        public Task<Detalle> Get(int id)
        {
            return _detalleRepository.GetAsync(id);
        }

        // ok
        [HttpPost]
        public Task<Detalle> Create([FromBody] Detalle detalle)
        {
            return _detalleRepository.InsertAsync(detalle);
        }

        // ok
        [HttpPut]
        [Route("{id}")]
        public async Task<Detalle> Update([FromRoute]int id, [FromBody]Detalle detalle)
        {
            var obj = await _detalleRepository.GetAsync(id);
            
            obj.Entero = detalle.Entero;
            obj.Flotante = detalle.Flotante;
            obj.Enum = detalle.Enum;
            obj.Cadena = detalle.Cadena;
            obj.FechaHora = detalle.FechaHora;
            obj.Fecha = detalle.Fecha;
            obj.Hora = detalle.Hora;
            obj.decimanl = detalle.decimanl;
            obj.booleano = detalle.booleano;
            obj.NombreArchivo = detalle.NombreArchivo;
            obj.Archivo = detalle.Archivo;

            var res = await _detalleRepository.UpdateAsync(obj);
            return res;
        }
        
        // ok
        [HttpDelete]
        [Route("{id}")]
        public Task Delete(int id)
        {
            return _detalleRepository.DeleteAsync(id);
        }
    }
}