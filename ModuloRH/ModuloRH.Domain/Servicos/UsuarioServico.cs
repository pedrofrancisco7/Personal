using ModuloRH.Domain.Entites;
using ModuloRH.Domain.Interfaces.Repositorios;
using ModuloRH.Domain.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModuloRH.Domain.Servicos
{
    public class UsuarioServico : ServicoBase<Usuario>, IUsuarioServico
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioServico(IUsuarioRepositorio usuarioRepositorio) : base(usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
    }
}
