namespace FlightInfo.Common.Extensions
{
    public static class StringExtension
    {
        public static string ReplaceChars(this string str, params (string from, string to)[] replaces)
        {
            foreach (var (from, to) in replaces)
            {
                str = str.Replace(from, to);
            }
            return str;
        }
    }
}
