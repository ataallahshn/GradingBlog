namespace GradingBlog.Seedwork.Guards;

public static class Guard
{
    public static class Against
    {
        public static void Null(object? o, Exception exception)
        {
            if (o is null)
            {
                throw exception;
            }
        }

        public static void Zero(long value, Exception exception)
        {
            if (value == 0)
            {
                throw exception;
            }
        }

        public static void Zero(decimal value, Exception exception)
        {
            if (value == 0)
            {
                throw exception;
            }
        }

        public static void False(bool b, Exception exception)
        {
            if (b is false)
            {
                throw exception;
            }
        }

        public static void True(bool b, Exception exception)
        {
            if (b)
            {
                throw exception;
            }
        }

        public static void NullOrWhiteSpace(string? s, Exception exception)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                throw exception;
            }
        }

        public static void NullOrEmpty(string? s, Exception exception)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw exception;
            }
        }

        public static void GreaterThan(long value, long maximumValue, Exception exception)
        {
            if (value > maximumValue)
            {
                throw exception;
            }
        }

        public static void LessThan(long value, long minimumValue, Exception exception)
        {
            if (value < minimumValue)
            {
                throw exception;
            }
        }

        public static void OutOfRange(long value, long start, long end, Exception exception)
        {
            if (value < start && value > end)
            {
                throw exception;
            }
        }
    }
}