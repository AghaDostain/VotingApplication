using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VotingApplication.WebAPI.Extra
{
    public class ContentActionResult<T> : IActionResult where T : class
    {
        public ObjectResult objectResult { get; set; }

        public ContentActionResult(HttpStatusCode status, T data, string message, HttpRequest request, int total = 1)
        {
            objectResult = new ObjectResult(data)
            {
                StatusCode = (int)status,
                Value = new
                {
                    status = status,
                    message = message,
                    data = data,
                    total = total,
                    requestId = Activity.Current?.Id ?? Trace.CorrelationManager.ActivityId.ToString()
                }
            };
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            await objectResult.ExecuteResultAsync(context);
        }
    }
}
