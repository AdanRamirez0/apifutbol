using AutoMapper;
using ProyectoFutbol_Api.Data;
using ProyectoFutbol_Api.DTOs;
using ProyectoFutbol_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFutbol_Api.Controllers
{
    [ApiController]
    //Nombrar a la api
    [Route("api/estadios")]
    public class EstadioController : ControllerBase
    {

        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public EstadioController(ApplicationDbContext context, IMapper mapper)
        {

            this.context = context;
            this.mapper = mapper;
        }

        //Obtener la lista de los Estadios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estadio>>> GetListEstadios()
        {
            var listaEstadios = await context.Estadios.ToListAsync();
            return listaEstadios;
        }

        //Obteneer cada Estadio por Id

        [HttpGet("{id:int}", Name = "GetEstadioById")]
        public async Task<ActionResult<Estadio>> GetEstadioById(int Id)
        {
            var Estadio = await context.Estadios.FirstOrDefaultAsync(a => a.Id == Id);
            {
                if (Estadio == null)

                    return NotFound("El Estadio no se encontró");
            }
            return Estadio;
        }
        //Registrar un Estadio Post
        [HttpPost]
        public async Task<ActionResult> RegistrarEstadio([FromBody] Estadio estadio)
        {
            var existe = await context.Estadios.AnyAsync(a => a.Nombre == estadio.Nombre);

            if (existe)
            {
                return BadRequest($"Ya hay un estadio con ese nombre {estadio.Nombre}");

            }
            //PPROCESO PARA COVERTIR EL DTO EN EL MODELO
            var estadioObj = mapper.Map<Estadio>(estadio);

            context.Estadios.Add(estadioObj);
            await context.SaveChangesAsync();
            return CreatedAtRoute("GetEstadioById", new { id = estadio.Id });

        }
        //Actualizar una Estadio
        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateEstadio([FromBody] Estadio estadio, int id)
        {
            if (estadio.Id != id)
            {
                return BadRequest("No se encuentra ese Id");
            }
            var existe = await context.Estadios.AnyAsync(a => a.Nombre == estadio.Nombre && a.Id != id);
            if (existe)
            {
                return BadRequest("El nombre del estadio ya fue utilizado");
            }
            context.Estadios.Update(estadio);
            await context.SaveChangesAsync();
            return NoContent();
        }
        //Eliminar un Estadio
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteEstadio(int id)
        {
            var estadio = await context.Estadios.FindAsync(id);
            if (estadio == null)
            {
                return NotFound("Ese estadio no está registrado");
            }
            context.Estadios.Remove(estadio);
            await context.SaveChangesAsync();
            return NoContent();
        }
        //Buscar un estadio por nombre,por numero de asientos 
        [HttpGet("{prefixText}")]
        public async Task<ActionResult<IEnumerable<Estadio>>> BuscarEstadioPrefijo
            (string prefixText)
        {
            var estadio = await context.Estadios.Where(a => a.Nombre.Contains
                (prefixText)).ToListAsync();
            return estadio;
        }
    }
}
