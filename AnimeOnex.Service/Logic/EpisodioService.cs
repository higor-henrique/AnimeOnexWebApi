using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnimeOnex.ModelData.Logic;

namespace AnimeOnex.Service.Logic
{
	public class EpisodioService
	{
		private AnimeOnexEntities AnimeOnexEntities = null;
		EpisodioService()
		{
			AnimeOnexEntities = new AnimeOnexEntities();
		}
	}
}