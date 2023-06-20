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
    [Route("api/jugadores")]
    public class JugadoresController
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public JugadoresController(ApplicationDbContext context, IMapper mapper)
        {

            this.context = context;
            this.mapper = mapper;
        }
        //Obtener la lista de los Jugadores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jugador>>> GetListJugadores()
        {
            var listaJugadores = await context.Jugadores.ToListAsync();
            return listaJugadores;
        }

    }
}
