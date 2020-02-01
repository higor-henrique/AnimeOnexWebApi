namespace AnimeOnex.Business.Mappers
{
    using AutoMapper;
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(m =>
            {
                m.AddProfile<DomainToViewModelMappingProfile>();
                m.AdProfile<ViewModelToDomainMappingProfile>();
            });

        
    }
}