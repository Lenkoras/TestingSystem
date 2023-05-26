namespace Auth.Cryptography
{
    public class DefaultKeySourceProvider : KeySourceProvider
    {
        public DefaultKeySourceProvider() : this(
            ('a', 'z'),
            ('A', 'Z'),
            ('1', '9'))
        {
        }

        private DefaultKeySourceProvider(params (char first, char last)[] ranges) : base(ranges)
        {
        }
    }
}
