using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : Controller
    {
        //Crear una instancia de nuestro contexto
        private readonly DbPruebasContext _dbContext;

        //Crear el constructor
        public TareaController(DbPruebasContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            List<TbTarea> lista = _dbContext.TbTareas.OrderByDescending(t => t.TareaPkId).ThenBy(t => t.FechaRegistro).ToList();

            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] TbTarea request)
        {
            await _dbContext.TbTareas.AddAsync(request);
            await _dbContext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "Ok");
        }

        [HttpDelete]
        [Route("Cerrar/{id:int}")]
        public async Task<IActionResult> Cerrar(int id)
        {
            TbTarea tarea = _dbContext.TbTareas.Find(id);

            _dbContext.TbTareas.Remove(tarea);
            await _dbContext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "Ok");
        }
    }
}

