using Guide.Translate.Business.Enum;
using System.ComponentModel.DataAnnotations;

namespace Guide.Translate.Api.ViewModels
{
    public class TranslateViewModel
    {
        [Required(ErrorMessage = "The field {0} is Required")]
        [StringLength(500, ErrorMessage = "The field {0} must at least between {2} and {1} caracteres", MinimumLength = 2)]
        public string Phrase { get; set; }
        [Required(ErrorMessage = "The field {0} is Required")]
        public ELanguages PhaseTo { get; set; }
    }
}
