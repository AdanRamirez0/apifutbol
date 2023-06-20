using System;

namespace ProyectoFutbol_Api.DTOs
{
    public class DirectorCreateDTO
    {
        public int Id { get; set; }

        public String Nombre { get; set; }

        public String ApPaterno { get; set; }

        public String Nacionalidad { get; set; }

        public String Campeonatos { get; set; }

        public String Antiguedad { get; set; }
    }
}
