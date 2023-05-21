// Overwriting namespace to add extensions to correct class
// ReSharper disable once CheckNamespace

namespace Extendable
{
    public sealed partial class Date
    {
        // example of conversion func
        private static Date StringToDate(string dateRepr)
        {
            var parts = dateRepr.Split("-");
            return new Date
            {
                Year = int.Parse(parts[0]),
                Month = int.Parse(parts[1]),
                Day = int.Parse(parts[2])
            };
        }

        // Since we can only have one == overload, we'd need to define bunch of these for every conceivable comparison.
        // Shouldn't be too many tho.
        public static implicit operator Date(string dateRepr) => StringToDate(dateRepr);

        public static bool operator ==(Date? left, Date? right)
        {
            // not sure how I'd avoid NPE here, as I can't check if it's equal to null :D
            return left.Year == right.Year && left.Month == right.Month && left.Day == right.Day;
        }

        public static bool operator !=(Date? left, Date? right)
        {
            return !(left == right);
        }
    }
}