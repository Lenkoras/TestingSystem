using System.Text;

namespace Auth.Cryptography
{
    public class KeySourceProvider
    {
        private IEnumerable<(char start, char end)> ranges;

        public KeySourceProvider(IEnumerable<(char start, char end)> ranges)
        {
            ArgumentNullException.ThrowIfNull(ranges);

            if (ranges.Any(range => range.start > range.end))
            {
                throw new ArgumentOutOfRangeException("One of ranges contains invalid sequence, where start character more than end character.");
            }

            this.ranges = ranges;
        }

        public string GetKeySource()
        {
            StringBuilder builder = new(ranges.Sum(range => MeasureLengthOfCharRange(range.start, range.end)));

            foreach (var range in ranges)
            {
                builder.Append(GetCharsInRange(range.start, range.end));
            }

            string source = builder.ToString();

            return source;
        }

        private static int MeasureLengthOfCharRange(char startChar, char endChar) =>
            endChar - startChar + 1;

        private static char[] GetCharsInRange(char startChar, char endChar)
        {
            char[] chars = new char[MeasureLengthOfCharRange(startChar, endChar)];

            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = (char)(i + startChar);
            }

            return chars;
        }
    }
}
