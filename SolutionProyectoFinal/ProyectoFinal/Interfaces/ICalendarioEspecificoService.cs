using ProyectoFinal.Models;

namespace ProyectoFinal.Interfaces
{
    public interface ICalendarioEspecificoService
    {
        void CrearActividad(CalendarioEspecifico nuevaActividad);
        void EditarActividad(int id, CalendarioEspecifico actividadEditada);
        void EliminarActividad(int id);
        List<CalendarioEspecifico> MostrarTodasLasActividades();
    }
}
