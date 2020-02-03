using System; // qualquer coisa 
using AutoMapper;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using AnimeOnex.Service.Logic;
using AnimeOnex.EnvelopeJson.Logic;
using AnimeOnex.ModelData.Logic;

namespace AnimeOnex.Business.Logic
{
    public class UsuarioBusiness 
    {
        private UsuarioService usuarioService;
        
        public UsuarioBusiness()
        {
            usuarioService = new UsuarioService();
        }

        public int Count
        {
            get
            {
                return this.usuarioService.Count;
            }
        }

        public int CountUsingParams(Expression<Func<Usuario, bool>> predicate)
        {
            return this.usuarioService.CountUsingParams(predicate);
        }

        public UsuarioEnvelopeJson Add(UsuarioEnvelopeJson instance)
        {
            Usuario usuario = Mapper.Map<UsuarioEnvelopeJson, Usuario>(instance);
            usuario.nickname = usuario.nickname.ToUpper();
            usuario = this.usuarioService.Add(usuario);
            return Mapper.Map<Usuario,UsuarioEnvelopeJson>(usuario);
        }

        public void Edit(UsuarioEnvelopeJson instance, bool comSenha = false)
        {
            Usuario academico = Mapper.Map<UsuarioEnvelopeJson,Usuario>(instance);
            if (comSenha)
            {
            // this.usuarioService.EditWithPassword(Usuario);
            }
            else
            {
                this.usuarioService.Edit(academico);


            }
        }

        public IQueryable<Usuario> Browsable(Expression<Func<Usuario, bool>> predicate = null)
        {
            return this.usuarioService.Browsable(predicate);
        }

        public UsuarioEnvelopeJson Read(Expression<Func<Usuario, bool>> filter)
        {
            Usuario usuario = this.usuarioService.Read(filter);
            return Mapper.Map<Usuario, UsuarioEnvelopeJson>(usuario);
        }


    }
}