using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFutbol_Api.Models
{
    public class Estadio
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Este dato es requerido")]

        public String Nombre { get; set; }
        [Required(ErrorMessage = "Este dato es requerido")]

        public Double NoEntradas { get; set; }
        [Required(ErrorMessage = "Este dato es requerido")]

        public Double BoletosVendidos { get; set; }
        [Required(ErrorMessage = "Este dato es requerido")]

        public Double AsientosReservados { get; set; }
    }
}
  