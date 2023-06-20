using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFutbol_Api.Data;
using ProyectoFutbol_Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoFutbol_Api.Controllers
{
    [ApiController]
    //Nombrar a la api
    [Route("api/torneos")]
    public class TorneoController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public TorneoController(ApplicationDbContext context, IMapper mapper)
        {

            this.context = context;
            this.mapper = mapper;
        }

        //Obtener la lista de los Torneos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Torneo>>> GetListTorneos()
        {
            var listaToneos = await context.Torneos.ToListAsync();
            return listaToneos;
        }

        //Obteneer cada Torneo por Id

        [HttpGet("{id:int}", Name = "GetTorneoById")]
        public async Task<ActionResult<Torneo>> GetTorneoById(int Id)
        {
            var torneo = await context.Torneos.FirstOrDefaultAsync(a => a.Id == Id);
            {
                if (torneo == null)

                    return NotFound("El Torneo no se encontró");
            }
            return torneo;
        }
        //Registrar un Torneo Post
        [HttpPost]
        public async Task<ActionResult> RegistrarTorneo([FromBody] Torneo torneo)
        {
            var existe = await context.Torneos.AnyAsync(a => a.Id == torneo.Id);

            if (existe)
            {
                return BadRequest($"Ya hay un torneo con ese nombre {torneo.Id}");

            }
            //PPROCESO PARA COVERTIR EL DTO EN EL MODELO
            var estadioObj = mapper.Map<Torneo>(torneo);

            context.Torneos.Add(estadioObj);
            await context.SaveChangesAsync();
            return CreatedAtRoute("GetTorneoById", new { id = torneo.Id });

        }
        //Actualizar una Torneo
        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateTorneo([FromBody] Torneo torneo, int id)
        {
            if (torneo.Id != id)
            {
                return BadRequest("No se encuentra ese Id");
            }
            var existe = await context.Torneos.AnyAsync(a => a.Id == torneo.Id && a.Id != id);
            if (existe)
            {
                return BadRequest("El Id del torneo ya fue utilizado");
            }
            context.Torneos.Update(torneo);
            await context.SaveChangesAsync();
            return NoContent();
        }
        //Eliminar un Torneo
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteTorneo(int id)
        {
            var Torneo = await context.Torneos.FindAsync(id);
            if (Torneo == null)
            {
                return NotFound("Ese torneo no está registrado");
            }
            context.Torneos.Remove(Torneo);
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}
