using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFutbol_Api.Models
{
    public class Director
    {
        [Key]

        public int Id { get; set; }
        [Required(ErrorMessage = "Este dato es requerido")]

        public String Nombre { get; set; }
        [Required(ErrorMessage = "Este dato es requerido")]

        public String ApPaterno { get; set; }
        [Required(ErrorMessage = "Este dato es requerido")]

        public String Nacionalidad { get; set; }
        [Required(ErrorMessage = "Este dato es requerido")]

        public String Campeonatos { get; set; }
        [Required(ErrorMessage = "Este dato es requerido")]

       public String Antiguedad { get; set; }

    }
}
