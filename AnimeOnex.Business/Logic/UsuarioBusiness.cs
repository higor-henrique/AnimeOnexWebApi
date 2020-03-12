using System; // qualquer coisa 
using AutoMapper;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using AnimeOnex.Service.Logic;
using AnimeOnex.EnvelopeJson.Logic;
using AnimeOnex.ModelData.Logic;
using AnimeOnex.Util.Pass;
using AnimeOnex.Util.Mail;
using System.Net;
using System.Net.Mail;

namespace AnimeOnex.Business.Logic
{
    public class UsuarioBusiness
    {
        private UsuarioService usuarioService;
        private Email email;


        public UsuarioBusiness()
        {
            usuarioService = new UsuarioService();
            email = new Email();
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
            return Mapper.Map<Usuario, UsuarioEnvelopeJson>(usuario);
        }

        public void Edit(UsuarioEnvelopeJson instance, bool comSenha = false)
        {
            Usuario academico = Mapper.Map<UsuarioEnvelopeJson, Usuario>(instance);
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


        public bool EsqueciSenha(string email, string nickname)
        {
            
            if(this.usuarioService.CountUsingParams(usuario => email.Equals(usuario.email) && nickname.Equals(usuario.nickname))> 0)
            {
                Usuario usuario = usuarioService.Browsable(usu => email.Equals(usu.email) && nickname.Equals(usu.nickname)).FirstOrDefault();

                usuario.senha = gerarSenha();
                this.email.Enviar();
                
                
                return true;
            }
            return false;

        }



        public string gerarSenha()
        {
            string novaSenha = "asdaseSd";//Password.Generate(0,8);
            return novaSenha;
        }

    }
}