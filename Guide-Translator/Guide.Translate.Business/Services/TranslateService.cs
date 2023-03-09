using Guide.Translate.Business.DTO;
using Guide.Translate.Business.Interfaces.External;
using Guide.Translate.Business.Interfaces.Services;
using Guide.Translate.Business.Models;

namespace Guide.Translate.Business.Services
{
    public class TranslateService : ITranslateService
    {
        private readonly IGPTFacade _gPTFacade;

        public TranslateService(IGPTFacade gPTFacade)
        {
            _gPTFacade = gPTFacade;
        }

        public async Task<TranslatedDTO> Translate(TranslateModel translate)
        {
            return new TranslatedDTO { Translated = "Bla bla bla " };
        }
    }
}
