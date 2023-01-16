using Microsoft.AspNetCore.Mvc;

namespace TimeManagerService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeManagerController : ControllerBase
    {
        private readonly ITimeManager timeManager;
        public TimeManagerController(ITimeManager timeManager)
        {
            this.timeManager = timeManager;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<DateTime> GetTime()
        {
            return await timeManager.GetTime();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<bool> SetTimezone([FromBody]string timezone) 
        {
            return await timeManager.SetTimeZone(timezone);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<string> ConvertDate([FromBody]string dateTime)
        {
            return await timeManager.ConvertDate(dateTime);
        }
    }
}
