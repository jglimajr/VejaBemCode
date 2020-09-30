using System;

namespace InteliSystem.Dominio.Gestao.Secoes.Handlers
{
    public interface ISecaoManutencao : IDisposable
    {
         void Add(Secao secao);
    }
}