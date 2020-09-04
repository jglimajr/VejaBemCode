using System.Threading.Tasks;
using InteliSystem.Util.Interfaces;

namespace InteliSystem.App.Management.Pessoas
{
    public interface IManutencaoPessoa : IManutencaoBase<Pessoa>
    {
         Task<Pessoa> GetByCpf(string cpf);
    }
}