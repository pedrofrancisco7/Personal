using ModuloRH.Domain.Interfaces.Repositorios;
using ModuloRH.Domain.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModuloRH.Domain.Servicos
{
    public class ServicoBase<TEntity> : IDisposable, IServicoBase<TEntity> where TEntity : class
    {
        private readonly IRepositorioBase<TEntity> _repositorioBase;

        public ServicoBase(IRepositorioBase<TEntity> repositorioBase)
        {
            _repositorioBase = repositorioBase;
        }

        public bool Adicionar(TEntity obj)
        {
            return _repositorioBase.Adicionar(obj);
        }

        public bool Atualizar(TEntity obj)
        {
            return _repositorioBase.Atualizar(obj);
        }        

        public TEntity ObterPorId(int id)
        {
            return _repositorioBase.ObterPorId(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return _repositorioBase.ObterTodos();
        }

        public bool Remover(TEntity obj)
        {
            return _repositorioBase.Remover(obj);
        }

        public void Dispose()
        {

        }
    }
}
