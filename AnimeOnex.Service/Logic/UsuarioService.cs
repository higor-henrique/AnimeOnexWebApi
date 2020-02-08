using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnimeOnex.ModelData.Logic;
using System.Linq.Expressions;
using System.Data.Entity.Migrations;

namespace AnimeOnex.Service.Logic
{
	public class UsuarioService
	{
		private AnimeOnexDBEntities context = null;
		public UsuarioService()
		{
			context = new AnimeOnexDBEntities();
		}
		public int Count
		{
			get
			{
				return this.Browsable().Count();
			}
		}

		public int CountUsingParams(Expression<Func<Usuario, bool>> predicate)
		{
			return this.Browsable(predicate).Count();
		}


		public Usuario Add(Usuario entity)
		{
			context.Usuario.Add(entity);
			context.SaveChanges();
			return entity;

		}

		public Object Read(Usuario ususario)
		{

			return ususario;
		}
		public void Edit(Usuario entity)
		{
			//this.context.Set<Usuario>().AddOrUpdate(entity);
			//Usuario usuario = this.context.Usuario.SingleOrDefault(a => a.UsuaruioID == entity.UsuarioID
			//this.context.Ususario.Attach(entity);
			//this.context.Entry(entity).State = EntityState.Modified;
			//this.context.Entry(entity).Property(a => a.Senha).IsModified = false;
			//this.context.Entry(entity).Property(a => a.UsuarioCriacaoCPF).IsModified = false;
			//this.context.Entry(entity).Property(a => a.UsuarioCriacaoNome).IsModified = false;
			//this.context.Entry(entity).Property(a => a.DataCriacao).IsModified = false;

			this.context.SaveChanges();
		}

		public Object Delete(Usuario ususario)
		{

			return ususario;
		}

		public IQueryable<Usuario> Browsable(Expression<Func<Usuario, bool>> predicate = null)
		{
			if (predicate != null)
			{
				return this.context.Usuario.Where(predicate);
			}
			else
			{
				return this.context.Usuario;
			}
		}

		public Usuario Read(Expression<Func<Usuario, bool>> filter)
		{
			return this.context.Usuario.SingleOrDefault(filter);
		}
	}
}