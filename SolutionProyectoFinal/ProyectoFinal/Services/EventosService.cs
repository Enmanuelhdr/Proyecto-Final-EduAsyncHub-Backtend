using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Context;
using ProyectoFinal.Interfaces;
using ProyectoFinal.Models;

namespace ProyectoFinal.Services
{
    public class EventosService : IEventoService
    {
        private readonly EduAsyncHubContext _context;

        public EventosService(EduAsyncHubContext dbContext)
        {
            _context = dbContext;
        }
        public void CrearEvento(Evento nuevoEvento)
        {
            _context.Eventos.Add(nuevoEvento);
            _context.SaveChanges();
        }

        public void EditarEvento(int id, Evento eventoEditado)
        {
            var eventoExistente = _context.Eventos.Find(id);
            if (eventoExistente != null)
            {
                eventoExistente.Title = eventoEditado.Title;
                eventoExistente.Description = eventoEditado.Description;
                eventoExistente.Img = eventoEditado.Img;
                eventoExistente.Date = eventoEditado.Date;

                _context.SaveChanges();
            }
        }

        public void EliminarEvento(int id)
        {
            var eventoElminar = _context.Eventos.Find(id);
            if (eventoElminar != null)
            {
                _context.Eventos.Remove(eventoElminar);
                _context.SaveChanges();
            }
        }

        public List<Evento> MostrarTodosLosEventos()
        {
            return _context.Eventos.ToList();
        }
    }
}
