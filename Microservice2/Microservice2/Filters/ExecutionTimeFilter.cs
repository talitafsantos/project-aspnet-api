using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Microservice2.Filters
{
    public class ExecutionTimeFilter : IActionFilter
    {
        private Stopwatch timer;

        public void OnActionExecuting(ActionExecutingContext context)
        {
            timer = Stopwatch.StartNew();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            timer.Stop();
            string message = $"Action took {timer.Elapsed.TotalMilliseconds} ms.";
            Console.WriteLine(message);
        }
    }

}
