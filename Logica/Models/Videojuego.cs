using System.ComponentModel.DataAnnotations;

namespace TiendaJuegos.Models
{
    public class Videojuego
    {
        [Key]
        public int idVideojuego { get; set; }
        [Required]

        public string Titulo { get; set; }
        [Required]

        public string Genero { get; set; }
        [Required]

        public string Plataforma { get; set; }
        [Required]
        public int PEGI { get; set; }
    }
}
