public class ManejoDeTareas
{
    
    private AccesoADatos accesoADatos;

    public AccesoADatos AccesoADatos { get => accesoADatos; set => accesoADatos = value; }

    public ManejoDeTareas(AccesoADatos acceso){
        accesoADatos = acceso;
    }

    public tarea crearNuevaTarea(tarea tarea){
        var tareas = accesoADatos.Obtener();
        tareas.Add(tarea);
        tarea.Id = tareas.Count();
        accesoADatos.Guardar(tareas);
        return tarea;
    }

    public tarea buscarTareaPorId(int id){
        var tareas = accesoADatos.Obtener();
        var tarea1 = tareas.FirstOrDefault(tar => tar.Id == id);
        return tarea1;
    }

    public tarea actulizar(tarea tareaNueva, int id){
        var tareas = accesoADatos.Obtener();
        var tareaAActualizar = tareas.FirstOrDefault(tar => tar.Id == id);
        if (tareaAActualizar != null)
        {
            tareaAActualizar.Titulo = tareaNueva.Titulo;
            tareaAActualizar.Descripcion = tareaNueva.Descripcion;
            tareaAActualizar.Estado = tareaNueva.Estado;
            accesoADatos.Guardar(tareas);
        }
        return tareaAActualizar;
    }

    public bool eliminarTarea(int id){
        var tareas = accesoADatos.Obtener();
        var tareaAEliminar = tareas.FirstOrDefault(x => x.Id == id);

        if (tareaAEliminar != null){
            var seElimino = tareas.Remove(tareaAEliminar);

            if(seElimino){
                accesoADatos.Guardar(tareas);
                return true;
            }
            
        }
        return false;
        
    }

}