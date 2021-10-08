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
        private readonly Stopwatch _stopwatch = new Stopwatch();

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            _stopwatch.Start();
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            _stopwatch.Stop();
            Console.WriteLine("Request Elapsed Time: " + this._stopwatch.ElapsedMilliseconds + " ms");
        }
    }
}
