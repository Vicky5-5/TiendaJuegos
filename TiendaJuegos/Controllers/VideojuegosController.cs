using Microsoft.AspNetCore.Mvc;
using TiendaJuegos.Servicios;

namespace TiendaJuegos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideojuegosController : ControllerBase
    {
        private readonly IVideojuegoService _service;

        public VideojuegosController(IVideojuegoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<VideojuegosViewModel>> GetAll()
        {
            var lista = _service.GetAll()
                        .Select(v => new VideojuegosViewModel(v))
                        .ToList();

            return Ok(lista);
        }

        [HttpGet("{id}")]
        public ActionResult<VideojuegosViewModel> GetById(int id)
        {
            var videojuego = _service.GetById(id);
            if (videojuego == null) return NotFound();

            return Ok(new VideojuegosViewModel(videojuego));
        }

        [HttpPost]
        public ActionResult<VideojuegosViewModel> Create([FromBody] VideojuegosViewModel vm)

        {
            var nuevo = _service.Add(vm.ToModel());
            return CreatedAtAction(nameof(GetById), new { id = nuevo.idVideojuego }, new VideojuegosViewModel(nuevo));
        }
        //El frombody indica que el objeto viene en el cuerpo de la petición, del mismo JSON de la petición de Angular
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] VideojuegosViewModel vm)
        {
            var actualizado = _service.Update(id, vm.ToModel());
            if (!actualizado) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var eliminado = _service.Delete(id);
            if (!eliminado) return NotFound();

            return NoContent();
        }
    }

}
