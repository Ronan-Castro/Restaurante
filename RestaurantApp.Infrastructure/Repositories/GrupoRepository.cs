using RestaurantApp.Domain.Interfaces;
using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;


namespace RestaurantApp.Infrastructure.Repositories;
public class GrupoRepository(ApplicationDbContext context) : IGrupoRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Grupo> AdicionarGrupo(Grupo grupo)
    {
        if (_context is not null && grupo is not null && _context.Grupos is not null)
        {
            _context.Grupos.Add(grupo);
            await _context.SaveChangesAsync();
            return grupo;
        }
        else
        {
            throw new InvalidOperationException("Dados inválidos");
        }
    }

    public async Task<Grupo?> ObterGrupo(int id)
    {
        var grupo = await _context.Grupos.FirstOrDefaultAsync(x => x.Id == id);

        return grupo;
    }

    public async Task<IEnumerable<Grupo>> ObterGrupos()
    {
        if (_context is not null) // && _context.Grupos is not null
        {
            var grupos = await _context.Grupos.ToListAsync();
            return grupos;
        }
        else
        {
            throw new InvalidOperationException("Dados inválidos...");
        }
    }

    async Task<Grupo> IGrupoRepository.AtualizarGrupo(Grupo grupo)
    {
        if (grupo is not null)
        {
            _context.Entry(grupo).State = EntityState.Modified;
            await _context.SaveChangesAsync();            
        }
        return grupo;

    }

    async Task<Grupo> IGrupoRepository.DeletarGrupo(int id)
    {
        var grupo = await ObterGrupo(id);
        if (grupo is not null)
        {
            _context.Grupos.Remove(grupo);
            await _context.SaveChangesAsync();            
        }
        return grupo;
    }
}
