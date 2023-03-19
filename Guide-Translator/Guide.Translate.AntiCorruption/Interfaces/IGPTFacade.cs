using Guide.Translate.AntiCorruption.DTO;
using Guide.Translate.AntiCorruption.DTOs;

namespace Guide.Translate.AntiCorruption.Interfaces
{
    public interface IGPTFacade
    {
        Task<ChatGPTOutputDTO> Translate(ChatGPTinputDTO TranslateModel);
    }
}
