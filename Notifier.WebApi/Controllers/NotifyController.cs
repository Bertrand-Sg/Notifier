using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Notifier.WebApi.Model;

namespace Notifier.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class NotifyController : Controller
    {
        [HttpGet]
        public IEnumerable<Notification> Get()
        {
            return CreateNotifications();
        }

        private static IEnumerable<Notification> CreateNotifications()
        {
            int limit = new Random().Next(1, 10);
            var notifs = new List<Notification>();
            var ids = new Random(limit);

            for (var i = 0; i < limit; i++)
            {
                var id = ids.Next();
                var categoryId = id % Enum.GetValues(typeof(NotificationType)).Length;
                notifs.Add(new Notification()
                {
                    Id = id,
                    Message = "Message #" + id,
                    Category = (NotificationType) categoryId,
                    Title = "title #" + id
                });
            }

            return notifs;
        }

        [HttpGet("base")]
        public IEnumerable<NotificationBase> GetBase()
        {
            return CreateNotifications().OfType<NotificationBase>();
        }

        [HttpGet("test")]
        public IEnumerable<string> GetTest()
        {
            return new[] {"Test 1", "Test 2"};
        }
    }
}