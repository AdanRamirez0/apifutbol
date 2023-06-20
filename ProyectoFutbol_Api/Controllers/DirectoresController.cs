using AutoMapper;
using ProyectoFutbol_Api.Data;
using ProyectoFutbol_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoFutbol_Api.DTOs;

namespace ProyectoFutbol_Api.Controllers
{
    [ApiController]
    //Nombrar a la api
    [Route("api/directores")]
    public class DirectoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public DirectoresController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id:int}" ,Name = "GetDirectorById")] 
        public async Task<ActionResult<Director>> GetDirectorById(int id)
        {
            var Director = await _context.Directors.Include(a=> a.Id).FirstOrDefaultAsync(a => a.Id == id);
            if (Director == null)
            {
                return NotFound("No se encontro el Director");

            }
            return Director;
        }
        //Resgistrar un Director (Post)

        [HttpPost]
        public async Task<ActionResult> RegistrarDirector([FromBody] DirectorCreateDTO director)
        {
            var existe = await _context.Directors.AnyAsync(a => a.Nombre == director.Nombre);

            if (existe)
            {
                return BadRequest($"Ya hay un director con ese nombre {director.Nombre}");

            }
            //PPROCESO PARA COVERTIR EL DTO EN EL MODELO
            var directorObj = _mapper.Map<Director>(director);

            _context.Directors.Add(directorObj);
            await _context.SaveChangesAsync();
            return CreatedAtRoute("GetDirectorById", new { id = director.Id });

        }


    }
}
