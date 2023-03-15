using System;
using Dapper.FluentMap.Mapping;
using Yupass.Domain.Entities;

namespace Yupass.Data.Mapping.Dapper
{
	public class UsuariosDapperMap : EntityMap<UsuariosEntity>
	{
		public UsuariosDapperMap()
		{
			Map(p => p.Id).ToColumn("Id");
            Map(p => p.Cpf).ToColumn("Cpf");
            Map(p => p.Nome).ToColumn("Nome");
            Map(p => p.Senha).ToColumn("Senha");
            Map(p => p.Email).ToColumn("Email");
            Map(p => p.PerfilId).ToColumn("PerfilId");
            Map(p => p.AcessoTemporario).ToColumn("AcessoTemporario");
            Map(p => p.CriadoEm).ToColumn("CriadoEm");
            Map(p => p.AtualizadoEm).ToColumn("AtualizadoEm");
            Map(p => p.Status).ToColumn("Status");      
        }
	}
}

