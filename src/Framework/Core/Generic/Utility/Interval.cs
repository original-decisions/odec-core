namespace odec.Framework.Generic.Utility
{
    /// <summary>
    /// It is an utility class which allows you to use the intervals of different types.
    /// </summary>
    /// <typeparam name="TKey">Type of the interval boundaries</typeparam>
    public class Interval<TKey>
    {
        /// <summary>
        /// Starting boundary.
        /// </summary>
        public TKey Start { get; set; }
        /// <summary>
        /// Ending boundary.
        /// </summary>
        public TKey End { get; set; }
    }

}
