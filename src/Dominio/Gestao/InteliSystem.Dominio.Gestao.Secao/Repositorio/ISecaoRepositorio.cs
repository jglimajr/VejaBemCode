using InteliSystem.Util.Interfaces;

namespace InteliSystem.Dominio.Gestao.Secoes.Repository
{
    public interface ISecaoRepositorio : IRepositorio<Secao>
    {
         void Add(Secao secao);
         void Update(Secao secao);
         Secao GetByUsuario(string usuarioId);
    }
}