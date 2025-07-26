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

    public Videojuego Update(int id, Videojuego juego)
    {
        try
        {
            var actualizado = VideojuegoManager.GuardarVideojuegos(
                id,
                juego.Titulo,
                juego.Genero,
                juego.Plataforma,
                juego.PEGI
            );

            return actualizado;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al actualizar videojuego: {ex.Message}");
            return null;
        }
    }

    public bool Delete(int id)
    {
        VideojuegoManager.EliminarVideojuego(id);
        return true; // o false si quieres validar algo
    }


}
