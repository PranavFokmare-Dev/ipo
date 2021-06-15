using Contracts;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ipo.Filters
{
    public class LoggerFilter : ActionFilterAttribute
    {
        private readonly LoggerManager _logger;
        public LoggerFilter(LoggerManager logger)
        {
            _logger = logger;
        }

        //after
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            string LogMessage = "Executed " + GetControllerAndAction(context.RouteData);
            _logger.LogDebug(LogMessage);
        }

        //before
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string LogMessage = "Executing "+ GetControllerAndAction(context.RouteData);
            _logger.LogDebug(LogMessage);
        }
        private string GetControllerAndAction(RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            return $"Controller:{controllerName} Action:{actionName}";
        }
    }
}
