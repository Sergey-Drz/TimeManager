namespace TimeManagerService
{
    public interface ITimeManager
    {
        public Task<DateTime> GetTime();
        public Task<bool> SetTimeZone(string currentTimeZone);
        public Task<string> ConvertDate(string date);
    }
}
