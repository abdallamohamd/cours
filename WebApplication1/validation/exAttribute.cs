using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebApplication1.validation
{
    public class exAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            ViewResult result= new ViewResult();
            result.ViewName = "ex";
            context.Result = result;
        }
    }
}
