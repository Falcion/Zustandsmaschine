namespace Zustand.Data.Types
{
    using Zustand.Data.Types.Interfaces;

    /// <summary>
    /// A non-generic dynamic representation of <see cref="Triad{T}"/> which holds <see cref="Object"/> as it's primary type
    /// </summary>
    public class Triad : Triad<object>
    {
        /* Not-implemented code. */
    }

    /// <summary>
    /// A class which represents a non-static container for three values
    /// </summary>
    /// <typeparam name="T">
    /// A generic type which defines type of every value which container will storage
    /// </typeparam>
#pragma warning disable S4035
    public class Triad<T> : IData, IEquatable<Triad<T>>,
#pragma warning restore S4035
                            IEqualityComparer<Triad<T>>
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
        public Triad(T? param1, 
                     T? param2, 
                     T? param3)
        {
            Param1 = param1;
            Param2 = param2;
            Param3 = param3;
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
        /// <param name="singleton3">
        /// An instance of <see cref="Singleton{T}"/> which contains generic type <typeparamref name="T"/> value representing one of parameters in the data type
        /// </param>
        public Triad(Singleton<T> singleton1,
                     Singleton<T> singleton2,
                     Singleton<T> singleton3)
        {
            Param1 = singleton1.Param;
            Param2 = singleton2.Param;
            Param3 = singleton3.Param;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="other">
        /// An instance of <see cref="Triad{T}"/> from which current one will be constructed
        /// </param>
        public Triad(Triad<T> other)
        {
            Param1 = other.Param1;
            Param2 = other.Param2;
            Param3 = other.Param3;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="tuple">
        /// An instance of <see cref="Tuple{T1, T2, T3}"/> which contains correspondive number of values for current instance
        /// </param>
        public Triad(Tuple<T, T, T> tuple)
        {
            Param1 = tuple.Item1;
            Param2 = tuple.Item2;
            Param3 = tuple.Item3;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="pair">
        /// An instance of <see cref="Pair{T}"/> which contains two values for current instance
        /// </param>
        /// <param name="param">
        /// A generic type <typeparamref name="T"/> value representing one of parameters in the data type
        /// </param>
        public Triad(Pair<T> pair, T param)
        {
            Param1 = pair.Param1;
            Param2 = pair.Param2;
            Param3 = param;
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

        public static implicit operator Triad<T>(
                                        Tuple<T, T, T> value)
        {
            return new Triad<T>(value);
        }

        public static implicit operator Triad<T>(
                                             (T, T, T) value)
        {
            return new Triad<T>(value);
        }

        public static bool operator ==(Triad<T>? triad1,
                                       Triad<T>? triad2)
        {
            if (ReferenceEquals(triad1,
                                triad2))
                return true;

            if (triad1 is null && triad2 is null)
                return true;
            if (triad1 is null || triad2 is null)
                return false;

            return EqualityComparer<T>.Default.Equals(triad1.Param1, triad2.Param1) &&
                   EqualityComparer<T>.Default.Equals(triad1.Param2, triad2.Param2) &&
                   EqualityComparer<T>.Default.Equals(triad1.Param3, triad2.Param3);
        }

        public static bool operator !=(Triad<T>? triad1,
                                       Triad<T>? triad2)
        {
            return !(triad1 == triad2);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Triad<T> another)
            {
                return this == another;
            }

            return false;
        }

        public bool Equals(Triad<T>? other)
        {
            if(other is null)
                return false;

            return this == other;
        }

        public bool Equals(Triad<T>? triad1,
                           Triad<T>? triad2)
        {
            if (triad1 == null && triad2 == null) return true;
            if (triad1 == null || triad2 == null) return false;

            return triad1 == triad2;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (Param1?.GetHashCode() ?? 0);
                hash = hash * 23 + (Param2?.GetHashCode() ?? 0);
                hash = hash * 23 + (Param3?.GetHashCode() ?? 0);
                return hash;
            }
        }

        public int GetHashCode(Triad<T>? other)
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (Param1?.GetHashCode() ?? 0);
                hash = hash * 23 + (Param2?.GetHashCode() ?? 0);
                hash = hash * 23 + (Param3?.GetHashCode() ?? 0);
                return hash;
            }
        }
    }

    /// <summary>
    /// A class which represents a non-static container for three values
    /// </summary>
    /// <typeparam name="T1">
    /// A generic type which defines type of one value which container will storage
    /// </typeparam>
    /// <typeparam name="T2">
    /// A generic type which defines type of both values which container will storage
    /// </typeparam>
#pragma warning disable S4035
    public class Triad<T1, T2> : IData, IEquatable<Triad<T1, T2>>,
#pragma warning restore S4035
                                 IEqualityComparer<Triad<T1, T2>>
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
        /// A generic type <typeparamref name="T2"/> value representing one of parameters in the data type
        /// </summary>
        public T2? Param3 { get; set; } = default;

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        public Triad() { }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="param1">
        /// A generic type <typeparamref name="T1"/> value representing one of parameters in the data type
        /// </param>
        /// <param name="param2">
        /// A generic type <typeparamref name="T2"/> value representing one of parameters in the data type
        /// </param>
        /// <param name="param3">
        /// A generic type <typeparamref name="T2"/> value representing one of parameters in the data type
        /// </param>
        public Triad(T1? param1, 
                     T2? param2, 
                     T2? param3)
        {
            Param1 = param1;
            Param2 = param2;
            Param3 = param3;
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
        /// <param name="singleton3">
        /// An instance of <see cref="Singleton{T}"/> which contains generic type <typeparamref name="T2"/> value representing one of parameters in the data type
        /// </param>
        public Triad(Singleton<T1> singleton1,
                     Singleton<T2> singleton2,
                     Singleton<T2> singleton3)
        {
            Param1 = singleton1.Param;
            Param2 = singleton2.Param;
            Param3 = singleton3.Param;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="other">
        /// An instance of <see cref="Triad{T1, T2}"/> from which current one will be constructed
        /// </param>
        public Triad(Triad<T1, T2> other)
        {
            Param1 = other.Param1;
            Param2 = other.Param2;
            Param3 = other.Param3;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="tuple">
        /// An instance of <see cref="Tuple{T1, T2, T3}"/> which contains correspondive number of values for current instance
        /// </param>
        public Triad(Tuple<T1, T2, T2> tuple)
        {
            Param1 = tuple.Item1;
            Param2 = tuple.Item2;
            Param3 = tuple.Item3;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="tuple">
        /// An instance of <see cref="Tuple{T1, T2, T3}"/> which contains correspondive number of values for current instance
        /// </param>
        public Triad(Tuple<T2, T1, T2> tuple)
        {
            Param1 = tuple.Item2;
            Param2 = tuple.Item1;
            Param3 = tuple.Item3;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="pair">
        /// An instance of <see cref="Pair{T}"/> which contains two values for current instance
        /// </param>
        /// <param name="param">
        /// A generic type <typeparamref name="T1"/> value representing one of parameters in the data type
        /// </param>
        public Triad(Pair<T2> pair, T1 param)
        {
            Param1 = param;
            Param2 = pair.Param1;
            Param3 = pair.Param2;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="pair">
        /// An instance of <see cref="Pair{T1, T2}"/> which contains two values for current instance
        /// </param>
        /// <param name="param">
        /// A generic type <typeparamref name="T2"/> value representing one of parameters in the data type
        /// </param>
        public Triad(Pair<T1, T2> pair, T2 param)
        {
            Param1 = pair.Param1;
            Param2 = pair.Param2;
            Param3 = param;
        }

        /// <summary>
        /// Method which converts and swaps first and last values inside the current instance
        /// </summary>
        public void Swap()
        {
            var convert_param1 = (T1?)Convert.ChangeType(Param3, typeof(T1));
            var convert_param3 = (T2?)Convert.ChangeType(Param1, typeof(T2));

            (Param1, Param3) = (convert_param1, convert_param3);
        }

        /// <summary>
        /// Method which converts and replaces the value of one value with the value of the next one inside the current instance
        /// </summary>
        public void Move()
        {
            var convert_param1 = (T1?)Convert.ChangeType(Param2, typeof(T1));
            var convert_param3 = (T2?)Convert.ChangeType(Param1, typeof(T2));

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

        public static implicit operator Triad<T1, T2>(
                                        Tuple<T1, T2, T2> value)
        {
            return new Triad<T1, T2>(value);
        }

        public static implicit operator Triad<T1, T2>(
                                             (T1, T2, T2) value)
        {
            return new Triad<T1, T2>(value);
        }

        public static implicit operator Triad<T1, T2>(
                                        Tuple<T2, T1, T2> value)
        {
            return new Triad<T1, T2>(value);
        }

        public static implicit operator Triad<T1, T2>(
                                             (T2, T1, T2) value)
        {
            return new Triad<T1, T2>(value);
        }

        public static bool operator ==(Triad<T1, T2>? triad1,
                                       Triad<T1, T2>? triad2)
        {
            if (ReferenceEquals(triad1,
                                triad2))
                return true;

            if (triad1 is null && triad2 is null)
                return true;
            if (triad1 is null || triad2 is null)
                return false;

            return EqualityComparer<T1>.Default.Equals(triad1.Param1, triad2.Param1) &&
                   EqualityComparer<T2>.Default.Equals(triad1.Param2, triad2.Param2) &&
                   EqualityComparer<T2>.Default.Equals(triad1.Param3, triad2.Param3);
        }

        public static bool operator !=(Triad<T1, T2>? triad1,
                                       Triad<T1, T2>? triad2)
        {
            return !(triad1 == triad2);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Triad<T1, T2> another)
            {
                return this == another;
            }

            return false;
        }

        public bool Equals(Triad<T1, T2>? other)
        {
            if(other is null)
                return false;

            return this == other;
        }

        public bool Equals(Triad<T1, T2>? triad1,
                           Triad<T1, T2>? triad2)
        {
            if (triad1 == null && triad2 == null) return true;
            if (triad1 == null || triad2 == null) return false;

            return triad1 == triad2;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (Param1?.GetHashCode() ?? 0);
                hash = hash * 23 + (Param2?.GetHashCode() ?? 0);
                hash = hash * 23 + (Param3?.GetHashCode() ?? 0);
                return hash;
            }
        }

        public int GetHashCode(Triad<T1, T2>? other)
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (Param1?.GetHashCode() ?? 0);
                hash = hash * 23 + (Param2?.GetHashCode() ?? 0);
                hash = hash * 23 + (Param3?.GetHashCode() ?? 0);
                return hash;
            }
        }
    }

    /// <summary>
    /// A class which represents a non-static container for three values
    /// </summary>
    /// <typeparam name="T1">
    /// A generic type which defines type of one value which container will storage
    /// </typeparam>
    /// <typeparam name="T2">
    /// A generic type which defines type of one value which container will storage
    /// </typeparam>
    /// <typeparam name="T3">
    /// A generic type which defines type of one value which container will storage
    /// </typeparam>
#pragma warning disable S4035
    public class Triad<T1, T2, T3> : IData, IEquatable<Triad<T1, T2, T3>>,
#pragma warning restore S4035
                                     IEqualityComparer<Triad<T1, T2, T3>>
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
        /// A generic type <typeparamref name="T3"/> value representing one of parameters in the data type
        /// </summary>
        public T3? Param3 { get; set; } = default;

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        public Triad() { }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="param1">
        /// A generic type <typeparamref name="T1"/> value representing one of parameters in the data type
        /// </param>
        /// <param name="param2">
        /// A generic type <typeparamref name="T2"/> value representing one of parameters in the data type
        /// </param>
        /// <param name="param3">
        /// A generic type <typeparamref name="T3"/> value representing one of parameters in the data type
        /// </param>
        public Triad(T1? param1, 
                     T2? param2, 
                     T3? param3)
        {
            Param1 = param1;
            Param2 = param2;
            Param3 = param3;
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
        /// <param name="singleton3">
        /// An instance of <see cref="Singleton{T}"/> which contains generic type <typeparamref name="T3"/> value representing one of parameters in the data type
        /// </param>
        public Triad(Singleton<T1> singleton1,
                     Singleton<T2> singleton2,
                     Singleton<T3> singleton3)
        {
            Param1 = singleton1.Param;
            Param2 = singleton2.Param;
            Param3 = singleton3.Param;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="other">
        /// An instance of <see cref="Triad{T1, T2, T3}"/> from which current one will be constructed
        /// </param>
        public Triad(Triad<T1, T2, T3> other)
        {
            Param1 = other.Param1;
            Param2 = other.Param2;
            Param3 = other.Param3;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="tuple">
        /// An instance of <see cref="Tuple{T1, T2, T3}"/> which contains correspondive number of values for current instance
        /// </param>
        public Triad(Tuple<T1, T2, T3> tuple)
        {
            Param1 = tuple.Item1;
            Param2 = tuple.Item2;
            Param3 = tuple.Item3;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="pair">
        /// An instance of <see cref="Pair{T1, T2}"/> which contains two values for current instance
        /// </param>
        /// <param name="param">
        /// A generic type <typeparamref name="T3"/> value representing one of parameters in the data type
        /// </param>
        public Triad(Pair<T1, T2> pair, T3 param)
        {
            Param1 = pair.Param1;
            Param2 = pair.Param2;
            Param3 = param;
        }

        /// <summary>
        /// Method which converts and swaps first and last values inside the current instance
        /// </summary>
        public void Swap()
        {
            var convert_param1 = (T1?)Convert.ChangeType(Param3, typeof(T1));
            var convert_param3 = (T3?)Convert.ChangeType(Param1, typeof(T3));

            (Param1, Param3) = (convert_param1, convert_param3);
        }

        /// <summary>
        /// Method which converts and replaces the value of one value with the value of the next one inside the current instance
        /// </summary>
        public void Move()
        {
            var convert_param1 = (T1?)Convert.ChangeType(Param2, typeof(T1));
            var convert_param2 = (T2?)Convert.ChangeType(Param3, typeof(T2));
            var convert_param3 = (T3?)Convert.ChangeType(Param1, typeof(T3));

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

        public static implicit operator Triad<T1, T2, T3>(
                                        Tuple<T1, T2, T3> value)
        {
            return new Triad<T1, T2, T3>(value);
        }

        public static implicit operator Triad<T1, T2, T3>(
                                             (T1, T2, T3) value)
        {
            return new Triad<T1, T2, T3>(value);
        }

        public static bool operator ==(Triad<T1, T2, T3>? triad1,
                                       Triad<T1, T2, T3>? triad2)
        {
            if (ReferenceEquals(triad1,
                                triad2))
                return true;

            if (triad1 is null && triad2 is null)
                return true;
            if (triad1 is null || triad2 is null)
                return false;

            return EqualityComparer<T1>.Default.Equals(triad1.Param1, triad2.Param1) &&
                   EqualityComparer<T2>.Default.Equals(triad1.Param2, triad2.Param2) &&
                   EqualityComparer<T3>.Default.Equals(triad1.Param3, triad2.Param3);
        }

        public static bool operator !=(Triad<T1, T2, T3>? triad1,
                                       Triad<T1, T2, T3>? triad2)
        {
            return !(triad1 == triad2);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Triad<T1, T2, T3> another)
            {
                return this == another;
            }

            return false;
        }

        public bool Equals(Triad<T1, T2, T3>? other)
        {
            if(other is null)
                return false;

            return this == other;
        }

        public bool Equals(Triad<T1, T2, T3>? triad1,
                           Triad<T1, T2, T3>? triad2)
        {
            if (triad1 == null && triad2 == null) return true;
            if (triad1 == null || triad2 == null) return false;

            return triad1 == triad2;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (Param1?.GetHashCode() ?? 0);
                hash = hash * 23 + (Param2?.GetHashCode() ?? 0);
                hash = hash * 23 + (Param3?.GetHashCode() ?? 0);
                return hash;
            }
        }

        public int GetHashCode(Triad<T1, T2, T3>? other)
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (Param1?.GetHashCode() ?? 0);
                hash = hash * 23 + (Param2?.GetHashCode() ?? 0);
                hash = hash * 23 + (Param3?.GetHashCode() ?? 0);
                return hash;
            }
        }
    }
}
