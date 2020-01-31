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

		public Object Add(Comentario comentario)
		{

			return comentario;
		}

		public Object Read(Comentario comentario)
		{

			return comentario;
		}

		public Object Delete(Comentario comentario)
		{

			return comentario;
		}

		public Object Browsable(Comentario comentario)
		{

			return comentario;
		}
	}
}
}