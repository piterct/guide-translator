using AutoMapper;
using Guide.Translate.Api.ViewModels;
using Guide.Translate.Business.Models;

namespace Guide.Translate.Api.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<TranslateModel, TranslateViewModel>().ReverseMap();
        }
    }
}
