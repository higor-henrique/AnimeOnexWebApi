namespace AnimeOnex.ModelData.Logic
{
    using System.Data.Entity;

    public partial class AnimeOnexDBEntities: DbContext
    {
        public AnimeOnexDBEntities(string connection) : base(connection)
        {

        }
    }
}