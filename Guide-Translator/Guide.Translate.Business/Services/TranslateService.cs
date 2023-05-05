using Guide.Translate.AntiCorruption.DTO;
using Guide.Translate.AntiCorruption.Interfaces;
using Guide.Translate.Business.DTO;
using Guide.Translate.Business.Enum;
using Guide.Translate.Business.Interfaces.Services;
using Guide.Translate.Business.Models;
using Guide.Translate.Business.Notifications;

namespace Guide.Translate.Business.Services
{
    public class TranslateService :  BaseService, ITranslateService
    {
        private readonly IGPTFacade _gPTFacade;
    
        public TranslateService(IGPTFacade gPTFacade, INotifyer notifyer) : base(notifyer)
        {
            _gPTFacade = gPTFacade;
        }

        public async Task<TranslatedDTO> Translate(TranslateModel translate)
        {
            string phaseToTranslate = await LanguageChoice(translate);

            var chatGPTInput = new ChatGPTinputDTO(phaseToTranslate);

            var translated = await _gPTFacade.Translate(chatGPTInput);

            return new TranslatedDTO { Translated = await ReplaceResponse(translated.choices.Select(x => x.text).FirstOrDefault() ?? string.Empty) };
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

        private async Task<string> ReplaceResponse(string text)
        {
            return await Task.FromResult(text.Replace("\n", "").Replace("\t", ""));
        }
    }
}
