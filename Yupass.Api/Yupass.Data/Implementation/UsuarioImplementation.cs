using Microsoft.EntityFrameworkCore;
using Yupass.Data.Context;
using Yupass.Data.Repository;
using Yupass.Domain.Entities;
using Yupass.Domain.Repository;

namespace Yupass.Data.Implementation
{
    public class UsuarioImplementation : RepositoryBase<UsuariosEntity>, IUsuarioRepository
    {
        private readonly DbSet<UsuariosEntity> _dataset;

        public UsuarioImplementation(AppDbContext context) : base(context)
        {
            _dataset = context.Set<UsuariosEntity>();
        }

        public async Task<UsuariosEntity?> FindByLogin(string cpf, string senha)
        {

            var userAdmin = await _dataset.FirstOrDefaultAsync(u => u.Perfil.Nome.Equals("SysAdmin") && u.Senha.Equals(senha));
            
            if (userAdmin != null)
            {
                var usuarioAdmin = await _dataset.FirstOrDefaultAsync(u => u.Cpf.Equals(cpf) && u.Senha.Equals(senha));

                if (usuarioAdmin == null)
                {
                    return await _dataset.FirstOrDefaultAsync(u => u.Cpf.Equals(cpf) && u.AcessoTemporario);
                }
                else
                {
                    return usuarioAdmin;
                }               
            }
            else
            {
                return await _dataset.FirstOrDefaultAsync(u => u.Cpf.Equals(cpf) && u.Senha.Equals(senha));
            }            

        }

        public async Task<UsuariosEntity?> FindByLogin(string login)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.Cpf.Equals(login));
        }

        public async Task<UsuariosEntity?> UpdateTemporaryAccess(UsuariosEntity login)
        {
            return null;
        }
    }
}
