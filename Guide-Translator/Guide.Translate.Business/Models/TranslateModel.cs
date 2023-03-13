using Guide.Translate.Business.Enum;

namespace Guide.Translate.Business.Models
{
    public class TranslateModel
    {
        public string Phrase { get; set; }
        public ELanguages PhaseTo { get; set; }
    }
}
