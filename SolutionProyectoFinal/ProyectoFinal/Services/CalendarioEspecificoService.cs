using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoFinal.Context;
using ProyectoFinal.Interfaces;
using ProyectoFinal.Models;

namespace ProyectoFinal.Services
{
    public class CalendarioEspecificoService : ICalendarioEspecificoService
    {
        private readonly EduAsyncHubContext _context;

        public CalendarioEspecificoService(EduAsyncHubContext dbContext)
        {
            _context = dbContext;
        }

        public void CrearActividad(CalendarioEspecifico nuevaActividad)
        {
            _context.CalendarioEspecificos.Add(nuevaActividad);
            _context.SaveChanges();
        }

        public void EditarActividad(int id, CalendarioEspecifico actividadEditada)
        {
            var actividadExistente = _context.CalendarioEspecificos.Find(id);
            if (actividadExistente != null)
            {
                actividadExistente.Title = actividadEditada.Title;
                actividadExistente.Date = actividadEditada.Date;
                actividadExistente.Hora = actividadEditada.Hora;


                _context.SaveChanges();
            }
        }

        public void EliminarActividad(int id)
        {
            var actividadEliminar = _context.CalendarioEspecificos.Find(id);
            if (actividadEliminar != null)
            {
                _context.CalendarioEspecificos.Remove(actividadEliminar);
                _context.SaveChanges();
            }
        }

        public List<CalendarioEspecifico> MostrarTodasLasActividades()
        {
            return _context.CalendarioEspecificos.ToList();
        }
    }
}
