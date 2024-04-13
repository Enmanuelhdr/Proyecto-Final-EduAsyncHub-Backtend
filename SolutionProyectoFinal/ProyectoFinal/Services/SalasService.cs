using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Context;
using ProyectoFinal.Interfaces;
using ProyectoFinal.Models;


public class SalasService : ISalasService
{
    private readonly EduAsyncHubContext _context;

    public SalasService(EduAsyncHubContext dbContext)
    {
        _context = dbContext;
    }

    public async Task CrearSalaAsync(Sala sala)
    {
        _context.Salas.Add(sala);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Sala>> ObtenerSalasAsync()
    {
        return await _context.Salas.ToListAsync();
    }
}
