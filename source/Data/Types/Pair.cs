namespace Zustand.Data.Types
{
    using Zustand.Data.Types.Interfaces;

    /// <summary>
    /// A non-generic dynamic representation of <see cref="Pair{T}"/> which holds <see cref="Object"/> as it's primary type
    /// </summary>
    public class Pair : Pair<object>
    {
        /* Not-implemented code. */
    }

    /// <summary>
    /// A class which represents a non-static container for pair of values
    /// </summary>
    /// <typeparam name="T">
    /// A generic type which defines type of both values which container will storage
    /// </typeparam>
    public class Pair<T> : IData
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
        /// Instance constructor for the class
        /// </summary>
        public Pair() { }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="param1">
        /// A generic type <typeparamref name="T"/> value representing one of parameters in the data type
        /// </param>
        /// <param name="param2">
        /// A generic type <typeparamref name="T"/> value representing one of parameters in the data type
        /// </param>
        public Pair(T? param1, 
                    T? param2)
        {
            Param1 = param1;
            Param2 = param2;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="singleton1">
        /// An instance of <see cref="Singleton{T}"/> which contains generic type <typeparamref name="T"/> value representing one of parameters in the data type
        /// </param>
        /// <param name="singleton2">
        /// An instance of <see cref="Singleton{T}"/> which contains generic type <typeparamref name="T"/> value representing one of parameters in the data type
        /// </param>
        public Pair(Singleton<T> singleton1,
                    Singleton<T> singleton2)
        {
            Param1 = singleton1.Param;
            Param2 = singleton2.Param;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="other">
        /// An instance of <see cref="Pair{T}"/> from which current one will be constructed
        /// </param>
        public Pair(Pair<T> other)
        {
            Param1 = other.Param1;
            Param2 = other.Param2;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="tuple">
        /// An instance of <see cref="Tuple{T1, T2}"/> which contains correspondive number of values for current instance
        /// </param>
        public Pair(Tuple<T, T> tuple)
        {
            Param1 = tuple.Item1;
            Param2 = tuple.Item2;
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
    /// <typeparam name="T1">
    /// A generic type which defines type of one of the values which container will storage
    /// </typeparam>
    /// <typeparam name="T2">
    /// A generic type which defines type of one of the values which container will storage
    /// </typeparam>
    public class Pair<T1, T2> : IData
    {
        /// <summary>
        /// A generic type <typeparamref name="T1"/> value representing one of parameters in the data type
        /// </summary>
        public T1? Param1 { get; set; } = default;
        /// <summary>
        /// A generic type <typeparamref name="T2"/> value representing one of parameters in the data type
        /// </summary>
        public T2? Param2 { get; set; } = default;

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        public Pair() { }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="param1">
        /// A generic type <typeparamref name="T1"/> value representing one of parameters in the data type
        /// </param>
        /// <param name="param2">
        /// A generic type <typeparamref name="T2"/> value representing one of parameters in the data type
        /// </param>
        public Pair(T1? param1, 
                    T2? param2)
        {
            Param1 = param1;
            Param2 = param2;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="singleton1">
        /// An instance of <see cref="Singleton{T}"/> which contains generic type <typeparamref name="T1"/> value representing one of parameters in the data type
        /// </param>
        /// <param name="singleton2">
        /// An instance of <see cref="Singleton{T}"/> which contains generic type <typeparamref name="T2"/> value representing one of parameters in the data type
        /// </param>
        public Pair(Singleton<T1> singleton1,
                    Singleton<T2> singleton2)
        {
            Param1 = singleton1.Param;
            Param2 = singleton2.Param;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="other">
        /// An instance of <see cref="Pair{T1, T2}"/> from which current one will be constructed
        /// </param>
        public Pair(Pair<T1, T2> other)
        {
            Param1 = other.Param1;
            Param2 = other.Param2;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="tuple">
        /// An instance of <see cref="Tuple{T1, T2}"/> which contains correspondive number of values for current instance
        /// </param>
        public Pair(Tuple<T1, T2> tuple)
        {
            Param1 = tuple.Item1;
            Param2 = tuple.Item2;
        }

        /// <summary>
        /// Method which converts and swaps two values inside the current instance
        /// </summary>
        public void Swap()
        {
            var convert_param1 = (T2?)Convert.ChangeType(Param1, typeof(T2));
            var convert_param2 = (T1?)Convert.ChangeType(Param2, typeof(T1));

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
