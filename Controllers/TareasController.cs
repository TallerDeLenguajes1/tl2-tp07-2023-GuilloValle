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

    public ActionResult<Tarea> buscarTareaId(int id){
        var tarea = manejoDeTareas.buscarTareaPorId(id);
        return Ok(tarea);
    }

    [HttpPost("CrearNuevaTarea")]
    public ActionResult<Tarea> crearTarea(Tarea tarea1)
    {
        manejoDeTareas.crearNuevaTarea(tarea1);
        return Ok(tarea1);
    }

    [HttpPut("actualizarTarea")]

    public ActionResult<Tarea> actualizarTarea(Tarea tarea1,int id)
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

    [HttpGet("listarTareas")]
    public ActionResult<List<Tarea>> listarTareas(){
        return  Ok(manejoDeTareas.listarTareas());
    }

    [HttpGet("listarTareasCompletadas")]
    public ActionResult<List<Tarea>> listarTareasCompletadas(){
        var tareasCompletadas = manejoDeTareas.listarTareasCompletadas();
        if (tareasCompletadas.Count() > 0)
        {
            return Ok(tareasCompletadas);
        }else
        {
            return NotFound("No existen las tareas");
        }
    }
}
