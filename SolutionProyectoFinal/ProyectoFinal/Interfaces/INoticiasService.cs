using ProyectoFinal.Models;

namespace ProyectoFinal.Interfaces
{
    public interface INoticiasService
    {
        public void CrearNoticia(Noticia nuevaNoticia);
        public void EditarNoticia(int id, Noticia noticiaEditada);
        public void EliminarNoticia(int id);
        public List<Noticia> MostrarTodasNoticias();

    }
}
