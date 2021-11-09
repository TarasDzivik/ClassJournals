namespace ClassJournals.Service
{
    public static class Extensions
    {
        public static string CutController(this string str)
        {
            return str.Replace("Controller", ""); // У вхідному рядку вирізаємо вхід Controller
        }
    }
}