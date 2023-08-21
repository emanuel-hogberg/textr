using System;
using System.Text;

namespace StringTransforms.Extensions
{
    static class Base64Extensions
    {
        public static string ToBase64Encoded(this string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value))
                {
                    return string.Empty;
                }

                return Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public static string FromBase64Encoded(this string base64String)
        {
            if (string.IsNullOrEmpty(base64String))
            {
                return string.Empty;
            }

            var result = string.Empty;
            const int maxStackSize = 64;

            if (string.IsNullOrEmpty(base64String))
            {
                return result;
            }

            Span<byte> buffer = stackalloc byte[maxStackSize];
            buffer.Clear();

            try
            {
                var converted = Convert.FromBase64String(base64String);

                // var slicedBuffer = buffer.Slice(0, converted);
                result = Encoding.UTF8.GetString(converted); //Will intentionally include U+FFFE if the buffer contains this character

                return result;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
