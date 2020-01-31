using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnimeOnex.ModelData.Logic;

namespace AnimeOnex.Service.Logic
{
	public class UsuarioService
	{
		private AnimeOnexEntities AnimeOnexEntities = null;
		UsuarioService()
		{
			AnimeOnexEntities = new AnimeOnexEntities();
		}

		public Object Add(Usuario ususario)
		{

			return ususario;
		}

		public Object Read(Usuario ususario)
		{

			return ususario;
		}

		public Object Delete(Usuario ususario)
		{

			return ususario;
		}

		public Object Browsable(Usuario ususario)
		{

			return ususario;
		}
	}
}