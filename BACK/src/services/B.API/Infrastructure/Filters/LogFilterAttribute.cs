using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace B.API.Infrastructure.Filters;

public class LogFilterAttribute : IActionFilter
{
    public async void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.HttpContext.Response.StatusCode == 200)
        {
            if (context.HttpContext.Request.Method == "PUT" || context.HttpContext.Request.Method == "DELETE")
            {
                if (context.ModelState.IsValid)
                {
                    var dateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    var id = context.ModelState["id"].RawValue;

                    var action = context.HttpContext.Request.Method == "PUT" ? "Alterar" : "Remover";

                    var logMessage = $"> {dateTime} - Card {id} - {action}";

                    Console.WriteLine(logMessage);
                }
            }
        }
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
    }
}