using System.Collections.Generic;

namespace ModuloRH.Application.Interface
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        bool Adicionar(TEntity obj);
        TEntity ObterPorId(int id);
        IEnumerable<TEntity> ObterTodos();
        bool Atualizar(TEntity obj);
        bool Remover(TEntity obj);
        void Dispose();
    }
}
