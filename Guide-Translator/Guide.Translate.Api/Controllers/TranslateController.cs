using Guide.Translate.Api.Model;
using Guide.Translate.Business.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Guide.Translate.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class TranslateController : BaseController
    {
        private readonly ILogger<TranslateController> _logger;
        private readonly ITranslateService _translateService;

        public TranslateController(ILogger<TranslateController> logger, ITranslateService translateService)
        {
            _logger = logger;
            _translateService = translateService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("")]
        public async ValueTask<IActionResult> Post(TranslateModel translate)
        {
            try
            {
                //var likes = await _likeRepository.GetQuantityLikesByArticle(article_ID);

                return Ok("tudo certo!");
            }
            catch (Exception exception)
            {
                _logger.LogError("An exception has occurred at {dateTime}. " +
                 "Exception message: {message}." +
                 "Exception Trace: {trace}", DateTime.UtcNow, exception.Message, exception.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
