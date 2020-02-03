using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnimeOnex.ModelData.Logic;

namespace AnimeOnex.Service.Logic
{
	public class AnimeService
	{
		private AnimeOnexDBEntities context= null;
		AnimeService(){
			context = new AnimeOnexDBEntities();
		}

		public Anime Add(Anime entity)
		{
			context.Anime.Add(entity);
			context.SaveChanges();
			return entity;
		}

		public  Read(Anime anime)
		{

			return anime;
		}

		public Object Delete(Anime anime)
		{

			return anime;
		}

		public Object Browsable(Anime anime)
		{

			return anime;
		}



	}


}