using Microsoft.EntityFrameworkCore;
using ModuloRH.Domain.Interfaces.Repositorios;
using ModuloRH.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModuloRH.Infra.Data.Repositorios
{
    public class RepositorioBase<TEntity> : IDisposable, IRepositorioBase<TEntity> where TEntity : class
    {
        protected ModuloRHContexto moduloRHContexto = new ModuloRHContexto(new DbContextOptions<ModuloRHContexto>());

        public bool Adicionar(TEntity obj)
        {
            try
            {
                moduloRHContexto.Set<TEntity>().Add(obj);
                moduloRHContexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Atualizar(TEntity obj)
        {
            try
            {
                moduloRHContexto.Entry(obj).State = EntityState.Modified;
                moduloRHContexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public TEntity ObterPorId(int id)
        {
            return moduloRHContexto.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return moduloRHContexto.Set<TEntity>();
        }

        public bool Remover(TEntity obj)
        {
            try
            {
                moduloRHContexto.Set<TEntity>().Remove(obj);
                moduloRHContexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
