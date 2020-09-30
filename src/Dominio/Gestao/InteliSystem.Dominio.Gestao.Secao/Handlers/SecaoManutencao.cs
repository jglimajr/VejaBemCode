using FluentValidator;
using InteliSystem.Dominio.Gestao.Secoes.Repository;

namespace InteliSystem.Dominio.Gestao.Secoes.Handlers
{
    public class SecaoManutencao : Notifiable, ISecaoManutencao
    {
        private readonly ISecaoRepositorio _repositorio;
        public SecaoManutencao(ISecaoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void Add(Secao secao)
        {
            _repositorio.Add(secao);
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }
    }
}