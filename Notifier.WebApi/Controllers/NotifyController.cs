using System.Collections.Generic;
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
            return Notification.CreateRandomList();
        }

        [HttpGet("test")]
        public IEnumerable<string> GetTest()
        {
            return new[] {"Test 1", "Test 2"};
        }
    }
}