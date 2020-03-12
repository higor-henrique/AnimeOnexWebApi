using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnimeOnex.ModelData.Logic;
using System.Linq.Expressions;
using System.Data.Entity.Migrations;

namespace AnimeOnex.Service.Logic
{
	public class EpisodioService
	{
		private AnimeOnexDBEntities context = null;
		public EpisodioService()
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

		public int CountUsingParams(Expression<Func<Episodio, bool>> predicate)
		{
			return this.Browsable(predicate).Count();
		}


		public Episodio Add(Episodio entity)
		{
			context.Episodio.Add(entity);
			context.SaveChanges();
			return entity;

		}

		public Object Read(Episodio episodio)
		{

			return episodio;
		}
		public void Edit(Episodio entity)
		{
			//this.context.Set<Episodio>().AddOrUpdate(entity);
			//Episodio Episodio = this.context.Episodio.SingleOrDefault(a => a.UsuaruioID == entity.EpisodioID
			//this.context.Ususario.Attach(entity);
			//this.context.Entry(entity).State = EntityState.Modified;
			//this.context.Entry(entity).Property(a => a.Senha).IsModified = false;
			//this.context.Entry(entity).Property(a => a.EpisodioCriacaoCPF).IsModified = false;
			//this.context.Entry(entity).Property(a => a.EpisodioCriacaoNome).IsModified = false;
			//this.context.Entry(entity).Property(a => a.DataCriacao).IsModified = false;

			this.context.SaveChanges();
		}

		public Object Delete(Episodio episodio)
		{

			return episodio;
		}

		public IQueryable<Episodio> Browsable(Expression<Func<Episodio, bool>> predicate = null)
		{
			if (predicate != null)
			{
				return this.context.Episodio.Where(predicate);

			}
			else
			{
				return this.context.Episodio;
			}
		}

		public Episodio Read(Expression<Func<Episodio, bool>> filter)
		{
			return this.context.Episodio.SingleOrDefault(filter);
		}
	}
}