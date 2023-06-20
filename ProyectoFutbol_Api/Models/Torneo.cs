using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFutbol_Api.Models
{
    public class Torneo
    {
        [Key]

        public int Id { get; set; }
        [Required(ErrorMessage = "Este dato es requerido")]

        public DateTime FechaInicio { get; set; }
        [Required(ErrorMessage = "Este dato es requerido")]

        public DateTime FechaTermino { get; set; }
        [Required(ErrorMessage = "Este dato es requerido")]

        public int ResultadoTorneo { get; set; }
        [ForeignKey("EstadioId")]
        public int EstadioId { get; set; }
        [ForeignKey("EquipoId")]

        public int EquipoId { get; set; }

    }
}
