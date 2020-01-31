
namespace AnimeOnex.ModelData.Logic
{
    using System.Data.Entity;
	public class AnimeOnexEntities: DbContext
	{

		public AnimeOnexEntities(string connection) : base(connection)
		{
		}

	}
}
