namespace JalapenoCloud.Common.Helpers
{
    public static class StringHelper
    {
        public static byte[] GetBytes(string str)
        {
            byte[] bytes = ConstantContainer.Encoding.GetBytes(str);
            return bytes;
        }

        public static string GetString(byte[] bytes)
        {
            string str = ConstantContainer.Encoding.GetString(bytes);
            return str;
        }
    }
}