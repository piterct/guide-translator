using Guide.Translate.Business.Enum;

namespace Guide.Translate.Api.Model
{
    public class TranslateModel
    {
        public string Phrase { get; set; }
        public ELanguages PhaseTo { get; set; }
    }
}
