using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFutbol_Api.Models
{
    public class Jugador
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

        public String Posicion { get; set; }
        [Required(ErrorMessage = "Este dato es requerido")]

        public Double Estatura { get; set; }

        [ForeignKey("EquipoId")]

        public int EquipoId { get; set; }

        public virtual Equipo Equipo { get; set; }
    }
}
