using Guide.Translate.AntiCorruption.DTO;
using Guide.Translate.AntiCorruption.Interfaces;
using Guide.Translate.Business.DTO;
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
            var chatGPTInput = new ChatGPTinputDTO($"Translate '{translate.Phrase}' Brazilian Portuguese");

           var translated = await _gPTFacade.Translate(chatGPTInput);

            return new TranslatedDTO { Translated = translated.Choices.Select(x=> x.Text).First() };
        }
    }
}
