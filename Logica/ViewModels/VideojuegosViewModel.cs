using System.ComponentModel.DataAnnotations;
using TiendaJuegos.Models;

public class VideojuegosViewModel
{
    [Required]
    public int idVideojuego { get; set; }

    [Required]
    public string Titulo { get; set; }

    [Required]
    public string Genero { get; set; }

    [Required]
    public string Plataforma { get; set; }

    [Required]
    public int PEGI { get; set; }

    public VideojuegosViewModel() { }

    public VideojuegosViewModel(Videojuego videojuego)
    {
        idVideojuego = videojuego.idVideojuego;
        Titulo = videojuego.Titulo;
        Genero = videojuego.Genero;
        Plataforma = videojuego.Plataforma;
        PEGI = videojuego.PEGI;
    }

    public Videojuego ToModel()
    {
        return new Videojuego
        {
            idVideojuego = this.idVideojuego,
            Titulo = this.Titulo,
            Genero = this.Genero,
            Plataforma = this.Plataforma,
            PEGI = this.PEGI
        };
    }
}
