using Logica.Managers;
using TiendaJuegos.Models;
using TiendaJuegos.Servicios;

public class VideojuegosService : IVideojuegoService
{
    public IEnumerable<Videojuego> GetAll()
    {
        return VideojuegoManager.ListarVideojuegos();
    }

    public Videojuego? GetById(int id)
    {
        return VideojuegoManager.ObtenerVideojuego(id);
    }

    public Videojuego Add(Videojuego juego)
    {
        return VideojuegoManager.GuardarVideojuegos(juego.idVideojuego, juego.Titulo, juego.Genero, juego.Plataforma, juego.PEGI);
    }

    public bool Update(int id, Videojuego juego)
    {
        var actualizado = VideojuegoManager.GuardarVideojuegos(id, juego.Titulo, juego.Genero, juego.Plataforma, juego.PEGI);
        return actualizado != null;
    }

    public bool Delete(int id)
    {
        VideojuegoManager.EliminarVideojuego(id);
        return true; // o false si quieres validar algo
    }


}
