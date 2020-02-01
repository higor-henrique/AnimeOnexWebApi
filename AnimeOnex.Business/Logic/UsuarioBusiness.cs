using System;
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

        public UsuarioEnvelopeJson Add(UsuarioService instance)
        {
            Usuario usuario = Mapper.Map<UsuarioEnvelopeJson, Usuario>(instance);
            usuario.nickname = usuario.nickname.ToUpper();
            return Mapper.Map<Usuario, UsuarioEnvelopeJson]>(usuario);
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
                this.academicoService.Edit(academico);

                if (instance.MaeNaoInformadaCertidao)
                {
                    FamiliaAcademicoEnvelopeJson familiaAcademico = this.familiaAcademicoBusiness.Browse(f => f.AcademicoID == instance.AcademicoID && f.GrauParentesco == EGrauParentesco.Mae.ToString()).SingleOrDefault();

                    if (familiaAcademico != null)
                    {
                        this.familiaAcademicoService.Delete(familiaAcademico.FamiliaAcademicoID);
                    }
                }
            }
        }

        public IQueryable<Usuario> Browsable(Expression<Func<Usuario, bool>> predicate = null)
        {
            return this.UsuarioService.Browsable(predicate);
        }

        public UsuarioEnvelopeJson Read(Expression<Func<Usuario, bool>> filter)
        {
            Usuario usuario = this.usuarioService.Read(filter);
            return Mapper.Map<Usuario, UsuarioEnvelopeJson>(usuario);
        }


    }
}