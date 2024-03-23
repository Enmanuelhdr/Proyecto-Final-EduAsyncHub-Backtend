using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Context;
using ProyectoFinal.Interfaces;
using ProyectoFinal.Models;

namespace ProyectoFinal.Services
{
    public class NoticiasService : INoticiasService
    {
        private readonly EduAsyncHubContext _context;

        public NoticiasService(EduAsyncHubContext dbContext)
        {
            _context = dbContext;
        }
        public void CrearNoticia(Noticia nuevaNoticia)
        {
            _context.Noticias.Add(nuevaNoticia);
            _context.SaveChanges();
        }

        public void EditarNoticia(int id, Noticia noticiaEditada)
        {
            var noticiaExistente = _context.Noticias.Find(id);
            if (noticiaExistente != null)
            {
                noticiaExistente.Title = noticiaEditada.Title;
                noticiaExistente.Description = noticiaEditada.Description;
                noticiaExistente.Img = noticiaEditada.Img;
                noticiaExistente.Date = noticiaEditada.Date;

                _context.SaveChanges();
            }
        }

        public void EliminarNoticia(int id)
        {
            var noticiaAEliminar = _context.Noticias.Find(id);
            if (noticiaAEliminar != null)
            {
                _context.Noticias.Remove(noticiaAEliminar);
                _context.SaveChanges();
            }
        }

        public List<Noticia> MostrarTodasNoticias()
        {
            return _context.Noticias.ToList();
        }
    }
}
