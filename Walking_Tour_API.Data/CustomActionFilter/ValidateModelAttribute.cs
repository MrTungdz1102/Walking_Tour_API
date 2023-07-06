using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Walking_Tour_API.Infrastructure.CustomActionFilter
{
	public class ValidateModelAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			if (filterContext.ModelState.IsValid == false)
			{
				filterContext.Result = new BadRequestResult();
			}
		}
	}
}
