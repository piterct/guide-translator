using Guide.Translate.Business.DTO;
using Guide.Translate.Business.Models;

namespace Guide.Translate.Business.Interfaces.Services
{
    public interface ITranslateService
    {
        Task<TranslatedDTO> Translate(TranslateModel translate);
    }
}
