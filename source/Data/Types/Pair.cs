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
#pragma warning disable S4035
    public class Pair<T> : IData, IEquatable<Pair<T>>,
#pragma warning restore S4035
                           IEqualityComparer<Pair<T>>
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

        public static implicit operator Pair<T>(
                                       Tuple<T, T> value)
        {
            return new Pair<T>(value);
        }

        public static implicit operator Pair<T>(
                                            (T, T) value)
        {
            return new Pair<T>(value);
        }

        public static bool operator ==(Pair<T>? pair1,
                                       Pair<T>? pair2)
        {
            if (ReferenceEquals(pair1,
                                pair2))
                return true;

            if (pair1 is null && pair2 is null)
                return true;
            if (pair1 is null || pair2 is null)
                return false;

            return EqualityComparer<T>.Default.Equals(pair1.Param1, pair2.Param1) &&
                   EqualityComparer<T>.Default.Equals(pair1.Param2, pair2.Param2);
        }

        public static bool operator !=(Pair<T>? pair1,
                                       Pair<T>? pair2)
        {
            return !(pair1 == pair2);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Pair<T> another)
            {
                return this == another;
            }

            return false;
        }

        public bool Equals(Pair<T>? other)
        {
            if (other is null)
                return false;

            return this == other;
        }

        public bool Equals(Pair<T>? pair1,
                           Pair<T>? pair2)
        {
            if (pair1 == null && pair2 == null) return true;
            if (pair1 == null || pair2 == null) return false;

            return pair1 == pair2;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (Param1?.GetHashCode() ?? 0);
                hash = hash * 23 + (Param2?.GetHashCode() ?? 0);
                return hash;
            }
        }

        public int GetHashCode(Pair<T>? other)
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (other?.Param1?.GetHashCode() ?? 0);
                hash = hash * 23 + (other?.Param2?.GetHashCode() ?? 0);
                return hash;
            }
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
#pragma warning disable S4035
    public class Pair<T1, T2> : IData, IEquatable<Pair<T1, T2>>,
#pragma warning restore S4035
                                IEqualityComparer<Pair<T1, T2>>
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

        public static implicit operator Pair<T1, T2>(
                                       Tuple<T1, T2> value)
        {
            return new Pair<T1, T2>(value);
        }

        public static implicit operator Pair<T1, T2>(
                                            (T1, T2) value)
        {
            return new Pair<T1, T2>(value);
        }

        public static bool operator ==(Pair<T1, T2>? pair1,
                                       Pair<T1, T2>? pair2)
        {
            if (ReferenceEquals(pair1,
                                pair2))
                return true;

            if (pair1 is null && pair2 is null)
                return true;
            if (pair1 is null || pair2 is null)
                return false;

            return EqualityComparer<T1>.Default.Equals(pair1.Param1, pair2.Param1) &&
                   EqualityComparer<T2>.Default.Equals(pair1.Param2, pair2.Param2);
        }

        public static bool operator !=(Pair<T1, T2>? pair1,
                                       Pair<T1, T2>? pair2)
        {
            return !(pair1 == pair2);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Pair<T1, T2> another)
            {
                return this == another;
            }

            return false;
        }

        public bool Equals(Pair<T1, T2>? other)
        {
            if(other is null)
                return false;

            return this == other;
        }

        public bool Equals(Pair<T1, T2>? pair1,
                           Pair<T1, T2>? pair2)
        {
            if (pair1 == null && pair2 == null) return true;
            if (pair1 == null || pair2 == null) return false;

            return pair1 == pair2;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (Param1?.GetHashCode() ?? 0);
                hash = hash * 23 + (Param2?.GetHashCode() ?? 0);
                return hash;
            }
        }

        public int GetHashCode(Pair<T1, T2>? other)
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (other?.Param1?.GetHashCode() ?? 0);
                hash = hash * 23 + (other?.Param2?.GetHashCode() ?? 0);
                return hash;
            }
        }
    }
}
