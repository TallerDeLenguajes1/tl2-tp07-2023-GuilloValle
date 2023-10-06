using System.Text.Json;
public class AccesoADatos
{   

    public static bool ExisteArchivo(string rutaArchivo)
    {
        if (File.Exists(rutaArchivo))
        {
            var info = new FileInfo(rutaArchivo);

            if (info.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    private string rutaTareas = "DatosTareas/listaTareas.json";
    public List<tarea> Obtener()
    {
        var pedidos = new List<tarea>();
        if (ExisteArchivo(rutaTareas))
        {
            string TextoJson = File.ReadAllText(rutaTareas);
            pedidos = JsonSerializer.Deserialize<List<tarea>>(TextoJson);
        }
        return pedidos;
    }

    public void Guardar(List<tarea> Tareas)
    {
        string formatoJson = JsonSerializer.Serialize(Tareas);
        File.WriteAllText(rutaTareas, formatoJson);
    }
}