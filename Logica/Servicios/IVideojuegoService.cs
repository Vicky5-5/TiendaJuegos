using TiendaJuegos.Models;

namespace TiendaJuegos.Servicios
{
    public interface IVideojuegoService
    {
        IEnumerable<Videojuego> GetAll();
        Videojuego? GetById(int id);
        Videojuego Add(Videojuego juego);
        Videojuego Update(int id, Videojuego juego);
        bool Delete(int id);
    }
}
