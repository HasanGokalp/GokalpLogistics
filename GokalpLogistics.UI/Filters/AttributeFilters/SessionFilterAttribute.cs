using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GokalpLogistics.UI.Filters.AttributeFilters
{
    public class SessionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //var session = context.HttpContext.Session.GetString("DriverName");
            //if (session == null)
            //{
            //    //context.Result = new RedirectResult("/Admin/Home");
            //    context.Result = new BadRequestResult();
            //}
            
        }
    }
}
