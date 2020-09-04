using System.Threading.Tasks;
using InteliSystem.Util.Interfaces;

namespace InteliSystem.App.Management.Pessoas
{
    public interface IRepositorioPessoa : IRepositorioBase<Pessoa>
    {
         Task<Pessoa> GetByCpf(string cpf);
    }
}