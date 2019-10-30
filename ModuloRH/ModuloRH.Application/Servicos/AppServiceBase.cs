using ModuloRH.Application.Interface;
using ModuloRH.Domain.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace ModuloRH.Application.Servicos
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServicoBase<TEntity> _serviceBase;
        public bool Adicionar(TEntity obj)
        {
            return _serviceBase.Adicionar(obj);
        }

        public bool Atualizar(TEntity obj)
        {
            return _serviceBase.Atualizar(obj);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }

        public TEntity ObterPorId(int id)
        {
            return _serviceBase.ObterPorId(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return _serviceBase.ObterTodos();
        }

        public bool Remover(TEntity obj)
        {
            return _serviceBase.Remover(obj);
        }
    }
}
