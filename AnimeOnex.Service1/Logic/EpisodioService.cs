using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnimeOnex.ModelData.Logic;

namespace AnimeOnex.Service.Logic
{
	public class EpisodioService
	{
		private AnimeOnexDBEntities AnimeOnexEntities = null;
		EpisodioService()
		{
			AnimeOnexEntities = new AnimeOnexDBEntities();
		}

		public Object Add(Episodio episodio)
		{

			return episodio;
		}

		public Object Read(Episodio episodio)
		{

			return episodio;
		}

		public Object Delete(Episodio episodio)
		{

			return episodio;
		}

		public Object Browsable(Episodio episodio)
		{

			return episodio;
		}
	}
}
