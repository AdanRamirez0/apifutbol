using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFutbol_Api.Models
{
    public class Equipo
    {
        [Key]

        public int Id { get; set; }
        [Required(ErrorMessage = "Este dato es requerido")]

        public String NomEquipo { get; set; }
        [Required(ErrorMessage = "Este dato es requerido")]
      

        public int JueegosGanados { get; set; }
        [Required(ErrorMessage = "Este dato es requerido")]

        public int JuegosPerdidos { get; set; }
        [Required(ErrorMessage = "Este dato es requerido")]

        public int JuegosEmpatados { get; set; }
        [Required(ErrorMessage = "Este dato es requerido")]


        //Relacion con las tablas DirectorId con jugadorId
        [ForeignKey("DirectorId")]
        public int DirectorId { get; set; }
        public virtual Director Director { get; set; }
        [ForeignKey("TorneoId")]

        public int TorneoId { get; set; } 

        public virtual Torneo Torneo { get; set; }
        
        
        
        
    }
}
