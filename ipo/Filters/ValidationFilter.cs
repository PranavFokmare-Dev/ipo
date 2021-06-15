using Contracts;
using Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ipo.Filters
{
    public class ValidationFilter: ActionFilterAttribute
    {
        private readonly LoggerManager _logger;
        public ValidationFilter(LoggerManager logger)
        {
            _logger = logger;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var entity = context.ActionArguments.SingleOrDefault(arg => arg.Value is IEntity);
            if(entity.Value == null)
            {
                _logger.LogError("Bad Request" + GetControllerAndAction(context.RouteData));
                context.Result = new BadRequestObjectResult("Object is null");
                return;
            }
            if (!context.ModelState.IsValid)
            {
                _logger.LogError("Bad Model" + GetControllerAndAction(context.RouteData));
                context.Result = new BadRequestObjectResult("Model is invalid");
            }
        }
        private string GetControllerAndAction(RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            return $"Controller:{controllerName} Action:{actionName}";
        }
    }
}
