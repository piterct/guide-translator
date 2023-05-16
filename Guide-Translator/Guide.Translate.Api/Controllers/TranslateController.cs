using AutoMapper;
using Guide.Translate.Api.ViewModels;
using Guide.Translate.Business.Interfaces.Services;
using Guide.Translate.Business.Models;
using Guide.Translate.Business.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Guide.Translate.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class TranslateController : MainController
    {
        private readonly ILogger<TranslateController> _logger;
        private readonly ITranslateService _translateService;
        private readonly IMapper _mapper;

        public TranslateController(ILogger<TranslateController> logger, ITranslateService translateService, IMapper mapper, INotifyer notifyer) : base(notifyer)
        {
            _logger = logger;
            _translateService = translateService;
            _mapper = mapper;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("")]
        public async Task<IActionResult> Post(TranslateViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return CustomResponse(model);

                var translate = await _translateService.Translate(_mapper.Map<TranslateModel>(model));

                return Ok(translate);
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
