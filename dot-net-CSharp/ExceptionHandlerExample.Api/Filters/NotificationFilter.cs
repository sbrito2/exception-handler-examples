using Infra.CrossCutting.Notifications;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Response;
using System.Net;

namespace Presentation.API.Filters
{
    public class NotificationFilter : IAsyncResultFilter
    {
        private readonly NotificationContext notificationContext;

        public NotificationFilter(NotificationContext notificationContext)
        {
            this.notificationContext = notificationContext;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (notificationContext.HasNotifications)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.HttpContext.Response.ContentType = "application/json";

                var response = notificationContext.notifications.AsErrorResponse();
                var notifications = JsonConvert.SerializeObject(response);
                await context.HttpContext.Response.WriteAsync(notifications);

                return;
            }

            await next();
        }
    }
}