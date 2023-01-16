namespace TimeManagerService
{
    public class TimeManager : ITimeManager
    {
        private TimeZoneInfo CurrentTimeZone;
        
        public TimeManager()
        {
            this.CurrentTimeZone = TimeZoneInfo.Utc;
        }

        public Task<DateTime> GetTime()
        {
            return Task.Run(() =>
            {
                return TimeZoneInfo.ConvertTime(DateTime.Now, CurrentTimeZone);
            });
        }

        public Task<bool> SetTimeZone(string currentTimeZone)
        {
            return Task.Run(() => 
            { 
                try
                {
                    CurrentTimeZone = TimeZoneInfo.FindSystemTimeZoneById(currentTimeZone);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public Task<string> ConvertDate(string date)
        {
            return Task.Run(() =>
            {
                try
                {
                    return TimeZoneInfo.ConvertTimeFromUtc(DateTime.Parse(date), CurrentTimeZone)
                                       .ToString(format: "dd.MM.yyyy HH:mm:ss zzz");
                }
                catch
                {
                    return "";
                }
            });
        }
    }
}
