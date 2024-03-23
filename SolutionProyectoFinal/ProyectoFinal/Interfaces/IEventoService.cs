using ProyectoFinal.Models;

namespace ProyectoFinal.Interfaces
{
    public interface IEventoService
    {
        public void CrearEvento(Evento nuevoEvento);
        public void EditarEvento(int id, Evento eventoEditado);
        public void EliminarEvento(int id);
        public List<Evento> MostrarTodosLosEventos();

    }
}
