namespace ElephantSanctuary.Mapping
{
    using AutoMapper;
    using DataModel = Models.Data;
    using ViewModel = Models.View;

    public class Mapping
    {
        public static MapperConfiguration Configuration => Register();

        public static MapperConfiguration Register()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DataModel.Elephant, ViewModel.Elephant>();
                cfg.CreateMap<ViewModel.Elephant, DataModel.Elephant>().ForMember(dest => dest.Id, opt => opt.Ignore());
            });
        }
    }
}
