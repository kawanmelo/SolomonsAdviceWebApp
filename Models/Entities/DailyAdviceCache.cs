namespace SolomonsAdviceWebApp.Models.Entities
{
    public static class DailyAdviceCache
    {
        private static Advice _dailyAdvice;

        public static Advice DailyAdvice
        {
            get { return  _dailyAdvice; }
            set { _dailyAdvice = value; }
        }
    }
}
