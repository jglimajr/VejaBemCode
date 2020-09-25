using System;

namespace InteliSystem.Domain.Management.Secoes.Handlers
{
    public interface ISecaoManutencao : IDisposable
    {
         void Add(Secao secao);
    }
}