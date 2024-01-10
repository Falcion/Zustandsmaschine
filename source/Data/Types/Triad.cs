namespace Zustand.Data.Types
{
    using Zustand.Data.Types.Interfaces;

    /// <summary>
    /// A class which represents a non-static container for three values
    /// </summary>
    /// <typeparam name="T">
    /// A generic type which defines type of every value which container will storage
    /// </typeparam>
    public class Triad<T> : IData
    {
        /// <summary>
        /// A generic type <typeparamref name="T"/> value representing one of parameters in the data type
        /// </summary>
        public T? Param1 { get; set; } = default;
        /// <summary>
        /// A generic type <typeparamref name="T"/> value representing one of parameters in the data type
        /// </summary>
        public T? Param2 { get; set; } = default;
        /// <summary>
        /// A generic type <typeparamref name="T"/> value representing one of parameters in the data type
        /// </summary>
        public T? Param3 { get; set; } = default;

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        public Triad() { }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="param1">
        /// A generic type <typeparamref name="T"/> value representing one of parameters in the data type
        /// </param>
        /// <param name="param2">
        /// A generic type <typeparamref name="T"/> value representing one of parameters in the data type
        /// </param>
        /// <param name="param3">
        /// A generic type <typeparamref name="T"/> value representing one of parameters in the data type
        /// </param>
        public Triad(T? param1, T? param2, T? param3)
        {
            Param1 = param1;
            Param2 = param2;
            Param3 = param3;
        }

        /// <summary>
        /// Method which swaps first and last values inside the current instance
        /// </summary>
        public void Swap()
        {
            (Param1, Param3) = (Param3, Param1);
        }

        /// <summary>
        /// Method which replaces the value of one value with the value of the next one inside the current instance
        /// </summary>
        public void Move()
        {
            (Param1, Param2, Param3) = (Param2, Param3, Param1);
        }

        /// <summary>
        /// Method which redefines every value with their default type value inside the data type
        /// </summary>
        public void Nullify()
        {
            Param1 = default;
            Param2 = default;
            Param3 = default;
        }
    }

    /// <summary>
    /// A class which represents a non-static container for three values
    /// </summary>
    /// <typeparam name="K">
    /// A generic type which defines type of one value which container will storage
    /// </typeparam>
    /// <typeparam name="V">
    /// A generic type which defines type of both values which container will storage
    /// </typeparam>
    public class Triad<K, V> : IData
    {
        /// <summary>
        /// A generic type <typeparamref name="K"/> value representing one of parameters in the data type
        /// </summary>
        public K? Param1 { get; set; } = default;
        /// <summary>
        /// A generic type <typeparamref name="V"/> value representing one of parameters in the data type
        /// </summary>
        public V? Param2 { get; set; } = default;
        /// <summary>
        /// A generic type <typeparamref name="V"/> value representing one of parameters in the data type
        /// </summary>
        public V? Param3 { get; set; } = default;

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        public Triad() { }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="param1">
        /// A generic type <typeparamref name="K"/> value representing one of parameters in the data type
        /// </param>
        /// <param name="param2">
        /// A generic type <typeparamref name="V"/> value representing one of parameters in the data type
        /// </param>
        /// <param name="param3">
        /// A generic type <typeparamref name="V"/> value representing one of parameters in the data type
        /// </param>
        public Triad(K? param1, V? param2, V? param3)
        {
            Param1 = param1;
            Param2 = param2;
            Param3 = param3;
        }

        /// <summary>
        /// Method which converts and swaps first and last values inside the current instance
        /// </summary>
        public void Swap()
        {
            var convert_param1 = (K?)Convert.ChangeType(Param3, typeof(K));
            var convert_param3 = (V?)Convert.ChangeType(Param1, typeof(V));

            (Param1, Param3) = (convert_param1, convert_param3);
        }

        /// <summary>
        /// Method which converts and replaces the value of one value with the value of the next one inside the current instance
        /// </summary>
        public void Move()
        {
            var convert_param1 = (K?)Convert.ChangeType(Param2, typeof(K));
            var convert_param3 = (V?)Convert.ChangeType(Param1, typeof(V));

            (Param1, Param2, Param3) = (convert_param1, Param3, convert_param3);
        }

        /// <summary>
        /// Method which redefines every value with their default type value inside the data type
        /// </summary>
        public void Nullify()
        {
            Param1 = default;
            Param2 = default;
            Param3 = default;
        }
    }

    /// <summary>
    /// A class which represents a non-static container for three values
    /// </summary>
    /// <typeparam name="K">
    /// A generic type which defines type of one value which container will storage
    /// </typeparam>
    /// <typeparam name="V">
    /// A generic type which defines type of one value which container will storage
    /// </typeparam>
    /// <typeparam name="U">
    /// A generic type which defines type of one value which container will storage
    /// </typeparam>
    public class Triad<K, V, U> : IData
    {
        /// <summary>
        /// A generic type <typeparamref name="K"/> value representing one of parameters in the data type
        /// </summary>
        public K? Param1 { get; set; } = default;
        /// <summary>
        /// A generic type <typeparamref name="V"/> value representing one of parameters in the data type
        /// </summary>
        public V? Param2 { get; set; } = default;
        /// <summary>
        /// A generic type <typeparamref name="U"/> value representing one of parameters in the data type
        /// </summary>
        public U? Param3 { get; set; } = default;

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        public Triad() { }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="param1">
        /// A generic type <typeparamref name="K"/> value representing one of parameters in the data type
        /// </param>
        /// <param name="param2">
        /// A generic type <typeparamref name="V"/> value representing one of parameters in the data type
        /// </param>
        /// <param name="param3">
        /// A generic type <typeparamref name="U"/> value representing one of parameters in the data type
        /// </param>
        public Triad(K? param1, V? param2, U? param3)
        {
            Param1 = param1;
            Param2 = param2;
            Param3 = param3;
        }

        /// <summary>
        /// Method which converts and swaps first and last values inside the current instance
        /// </summary>
        public void Swap()
        {
            var convert_param1 = (K?)Convert.ChangeType(Param3, typeof(K));
            var convert_param3 = (U?)Convert.ChangeType(Param1, typeof(U));

            (Param1, Param3) = (convert_param1, convert_param3);
        }

        /// <summary>
        /// Method which converts and replaces the value of one value with the value of the next one inside the current instance
        /// </summary>
        public void Move()
        {
            var convert_param1 = (K?)Convert.ChangeType(Param2, typeof(K));
            var convert_param2 = (V?)Convert.ChangeType(Param3, typeof(V));
            var convert_param3 = (U?)Convert.ChangeType(Param1, typeof(U));

            (Param1, Param2, Param3) = (convert_param1, convert_param2, convert_param3);
        }

        /// <summary>
        /// Method which redefines every value with their default type value inside the data type
        /// </summary>
        public void Nullify()
        {
            Param1 = default;
            Param2 = default;
            Param3 = default;
        }
    }
}
