using RestaurantApp.Domain.Models;

namespace RestaurantApp.Domain.Interfaces;

public interface IGrupoRepository
{
    Task<IEnumerable<Grupo>> ObterGrupos();
    Task<Grupo?> ObterGrupo(int id);
    Task<Grupo> AdicionarGrupo(Grupo grupo);
    Task<Grupo> DeletarGrupo(int id);
    Task<Grupo> AtualizarGrupo(Grupo grupo);
}
