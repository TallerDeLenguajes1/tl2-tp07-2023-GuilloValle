using Microsoft.AspNetCore.Mvc;

namespace tl2_tp07_2023_GuilloValle.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private ManejoDeTareas manejoDeTareas;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        var accesoADatos1 = new AccesoADatos();
        manejoDeTareas = new ManejoDeTareas(accesoADatos1);
    }

    [HttpGet("BuscarTareaPorId")]

    public ActionResult<tarea> buscarTareaId(int id){
        var tarea = manejoDeTareas.buscarTareaPorId(id);
        return Ok(tarea);
    }

    [HttpPost("CrearNuevaTarea")]
    public ActionResult<tarea> crearTarea(tarea tarea1)
    {
        manejoDeTareas.crearNuevaTarea(tarea1);
        return Ok(tarea1);
    }

    [HttpPut("actualizarTarea")]

    public ActionResult<tarea> actualizarTarea(tarea tarea1,int id)
    {
        manejoDeTareas.actulizar(tarea1,id);
        return Ok(tarea1);
    }

    [HttpDelete("eliminarTarea")]

    public ActionResult<bool> eliminarTarea(int id){
        
        
        if (manejoDeTareas.buscarTareaPorId(id) == null)
        {
            return NotFound("No existe la tarea");
        }

        var seElimino =manejoDeTareas.eliminarTarea(id);
        
            if (seElimino == false)
            {
                return BadRequest(false);
            }else
            {
                return Ok(true);
            }
        
        
    }
}
