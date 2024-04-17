using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Context;
using ProyectoFinal.DTOs;
using ProyectoFinal.Interfaces;
using static ProyectoFinal.DTOs.SalasDTOcs;
using ProyectoFinal.Models;



public class SalasService : ISalasService
{
    private readonly EduAsyncHubContext _context;

    public SalasService(EduAsyncHubContext dbContext)
    {
        _context = dbContext;
    }

    public async Task CrearSalaAsync(SalasDTOcs salaDto)
    {
        Sala nuevaSala = new Sala
        {
            Nombre = salaDto.Nombre,
            Fecha = salaDto.Fecha
        };

        _context.Salas.Add(nuevaSala);
        await _context.SaveChangesAsync();
    }


    public async Task<List<Sala>> ObtenerSalasAsync()
    {
        return await _context.Salas.ToListAsync();
    }
}
