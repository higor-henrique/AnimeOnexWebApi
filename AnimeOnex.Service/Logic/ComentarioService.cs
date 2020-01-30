using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnimeOnex.ModelData.Logic;

namespace AnimeOnex.Service.Logic
{
	public class ComentarioService
	{

		private AnimeOnexEntities AnimeOnexEntities = null;
		ComentarioService()
		{
			AnimeOnexEntities = new AnimeOnexEntities();
		}
	}
}