using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.API.Filters
{
    public class PerformanceResourceFilter : IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.HttpContext.Items["stopwatch"] = new Stopwatch();
            Stopwatch stopwatch = (Stopwatch)context.HttpContext.Items["stopwatch"];
            stopwatch.Start();
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Stopwatch stopwatch = (Stopwatch)context.HttpContext.Items["stopwatch"];
            stopwatch.Stop();
        }
    }
}
