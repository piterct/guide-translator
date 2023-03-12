using Guide.Translate.AntiCorruption.DTO;
using Guide.Translate.AntiCorruption.Interfaces;
using Guide.Translate.Business.DTO;
using Guide.Translate.Business.Enum;
using Guide.Translate.Business.Interfaces.Services;
using Guide.Translate.Business.Models;
using Microsoft.Extensions.Configuration;

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
            string phaseToTranslate = await LanguageChoice(translate);

            var chatGPTInput = new ChatGPTinputDTO(phaseToTranslate);

            var translated = await _gPTFacade.Translate(chatGPTInput);

            return new TranslatedDTO { Translated = translated.choices.Select(x => x.text).FirstOrDefault() };
        }

        private async Task<string> LanguageChoice(TranslateModel translate)
        {
            switch (translate.PhaseTo)
            {
                case ELanguages.BrazilianPortuguese:
                    return $"Translate '{translate.Phrase}' to Brazilian Portuguese";
                case ELanguages.Portuguese:
                    return $"Translate '{translate.Phrase}' to Portugal Portuguese";
                case ELanguages.Spanish:
                    return $"Translate '{translate.Phrase}' to Spanish";
                default:
                    return $"Translate '{translate.Phrase}' to English";
            }
        }
    }
}
