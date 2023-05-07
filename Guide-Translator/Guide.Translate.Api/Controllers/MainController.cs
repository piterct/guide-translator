using Guide.Translate.Business.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Guide.Translate.Api.Controllers
{
    public abstract class MainController : Controller
    {
        private readonly INotifyer _notifyer;

        public MainController(INotifyer notifyer)
        {
            _notifyer = notifyer;
        }

        protected bool InvalidOperation()
        {
            return !_notifyer.HasNotification();
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotifyInvalidModelState(modelState);
            return CustomResponse();
        }

        protected void NotifyInvalidModelState(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                ErrorNotify(erroMsg);
            }
        }

        protected void ErrorNotify(string message)
        {
            _notifyer.Handle(new Notify(message));
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (InvalidOperation())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                erros = _notifyer.GetNotifications().Select(n => n.Message)
            });
        }
    }
}
