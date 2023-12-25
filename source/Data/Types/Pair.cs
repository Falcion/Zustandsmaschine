namespace Zustand.Data.Types
{
    using Zustand.Data.Types.Interfaces;

    /// <summary>
    /// A class which represents a non-static container for pair of values
    /// </summary>
    /// <typeparam name="T">
    /// A generic type which defines type of both values which container will storage
    /// </typeparam>
    public class Pair<T> : IData
    {
        /// <summary>
        /// A generic type <see href="T"/> value representing one of parameters in the data type
        /// </summary>
        public T? Param1 { get; set; } = default;
        /// <summary>
        /// A generic type <see href="T"/> value representing one of parameters in the data type
        /// </summary>
        public T? Param2 { get; set; } = default;

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        public Pair() { }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="param1">
        /// A generic type <see href="T"/> value representing one of parameters in the data type
        /// </param>
        /// <param name="param2">
        /// A generic type <see href="T"/> value representing one of parameters in the data type
        /// </param>
        public Pair(T? param1, T? param2)
        {
            Param1 = param1;
            Param2 = param2;
        }

        /// <summary>
        /// Method which swaps two values inside the current instance
        /// </summary>
        public void Swap()
        {
            (Param1, Param2) = (Param2, Param1);
        }

        /// <summary>
        /// Method which replaces the value of one value with the value of the next one inside the current instance
        /// </summary>
        public void Move()
        {
            Swap();
        }

        /// <summary>
        /// Method which redefines every value with their default type value inside the data type
        /// </summary>
        public void Nullify()
        {
            Param1 = default;
            Param2 = default;
        }
    }

    /// <summary>
    /// A class which represents a non-static container for pair of values
    /// </summary>
    /// <typeparam name="K">
    /// A generic type which defines type of one of the values which container will storage
    /// </typeparam>
    /// <typeparam name="V">
    /// A generic type which defines type of one of the values which container will storage
    /// </typeparam>
    public class Pair<K, V> : IData
    {
        /// <summary>
        /// A generic type <see href="K"/> value representing one of parameters in the data type
        /// </summary>
        public K? Param1 { get; set; } = default;
        /// <summary>
        /// A generic type <see href="V"/> value representing one of parameters in the data type
        /// </summary>
        public V? Param2 { get; set; } = default;

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        public Pair() { }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="param1">
        /// A generic type <see href="K"/> value representing one of parameters in the data type
        /// </param>
        /// <param name="param2">
        /// A generic type <see href="V"/> value representing one of parameters in the data type
        /// </param>
        public Pair(K? param1, V? param2)
        {
            Param1 = param1;
            Param2 = param2;
        }

        /// <summary>
        /// Method which converts and swaps two values inside the current instance
        /// </summary>
        public void Swap()
        {
            var convert_param1 = (V?)Convert.ChangeType(Param1, typeof(V));
            var convert_param2 = (K?)Convert.ChangeType(Param2, typeof(K));

            Param1 = convert_param2;
            Param2 = convert_param1;
        }

        /// <summary>
        /// Method which converts and replaces the value of one value with the value of the next one inside the current instance
        /// </summary>
        public void Move()
        {
            Swap();
        }

        /// <summary>
        /// Method which redefines every value with their default type value inside the data type
        /// </summary>
        public void Nullify()
        {
            Param1 = default;
            Param2 = default;
        }
    }
}
