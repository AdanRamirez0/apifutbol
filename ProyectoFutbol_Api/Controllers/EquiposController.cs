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

namespace ProyectoFutbol_Api.Controllers
{
    [ApiController]
    //Nombrar a la API
    [Route("api/Equipos")]
    public class EquiposController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;

        public EquiposController(ApplicationDbContext context, IMapper mapper)
        {
            this._context = context;
            this.mapper = mapper; 
        }

    }
}
