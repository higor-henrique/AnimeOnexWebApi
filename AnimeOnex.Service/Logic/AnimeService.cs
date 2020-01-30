using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnimeOnex.ModelData.Logic;

namespace AnimeOnex.Service.Logic
{
	public class AnimeService
	{
		private AnimeOnexEntities AnimeOnexEntities= null;
		AnimeService(){
			AnimeOnexEntities = new AnimeOnexEntities();
		}

		public Object Add(Anime anime)
		{

			return anime;
		}

		public Object Read(Anime anime)
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