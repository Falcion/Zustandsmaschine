namespace Zustand.Data.Types
{
    using Zustand.Data.Types.Interfaces;

    /// <summary>
    /// A non-generic dynamic representation of <see cref="Quadra{T}"/> which holds <see cref="Object"/> as it's primary type
    /// </summary>
    public class Quadra : Quadra<object>
    {
        /* Not-implemented code. */
    }

    /// <summary>
    /// A class which represents a non-static container for four values
    /// </summary>
    /// <typeparam name="T">
    /// A generic type which defines type of values which container will storage
    /// </typeparam>
#pragma warning disable S4035
    public class Quadra<T> : IData, IEquatable<Quadra<T>>,
#pragma warning restore S4035
                             IEqualityComparer<Quadra<T>>
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
        /// A generic type <typeparamref name="T"/> value representing one of parameters in the data type
        /// </summary>
        public T? Param4 { get; set; } = default;

        /// <summary>
        /// An instance of <see cref="Pair{T}"/> which contains first two parameters of the instance, correspondive <see cref="Param1"/> and <see cref="Param2"/>
        /// </summary>
        private Pair<T> _pair1 = new();
        /// <summary>
        /// An instance of <see cref="Pair{T}"/> which contains other two parameters of the instance, correspondive <see cref="Param3"/> and <see cref="Param4"/>
        /// </summary>
        private Pair<T> _pair2 = new();

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        public Quadra() { }

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
        /// <param name="param4">
        /// A generic type <typeparamref name="T"/> value representing one of parameters in the data type
        /// </param>
        public Quadra(T? param1, 
                      T? param2, 
                      T? param3, 
                      T? param4)
        {
            Param1 = param1;
            Param2 = param2;
            Param3 = param3;
            Param4 = param4;

            _pair1 = new Pair<T>(param1, param2);
            _pair2 = new Pair<T>(param3, param4);
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
        /// <param name="singleton4">
        /// An instance of <see cref="Singleton{T}"/> which contains generic type <typeparamref name="T"/> value representing one of parameters in the data type
        /// </param>
        public Quadra(Singleton<T> singleton1,
                      Singleton<T> singleton2,
                      Singleton<T> singleton3,
                      Singleton<T> singleton4)
        {
            Param1 = singleton1.Param;
            Param2 = singleton2.Param;
            Param3 = singleton3.Param;
            Param4 = singleton4.Param;

            _pair1 = new Pair<T>(singleton1, singleton2);
            _pair2 = new Pair<T>(singleton3, singleton4);
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="pair1">
        /// An instance of <see cref="Pair{T}"/> which contains pair of generic type <typeparamref name="T"/> values for current instance of data type
        /// </param>
        /// <param name="pair2">
        /// An instance of <see cref="Pair{T}"/> which contains pair of generic type <typeparamref name="T"/> values for current instance of data type
        /// </param>
        public Quadra(Pair<T> pair1,
                      Pair<T> pair2)
        {
            Param1 = pair1.Param1;
            Param2 = pair1.Param2;
            Param3 = pair2.Param1;
            Param4 = pair2.Param2;

            _pair1 = new Pair<T>(pair1);
            _pair2 = new Pair<T>(pair2);
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="other">
        /// An instance of <see cref="Quadra{T}"/> from which current one will be constructed
        /// </param>
        public Quadra(Quadra<T> other)
        {
            Param1 = other.Param1;
            Param2 = other.Param2;
            Param3 = other.Param3;
            Param4 = other.Param4;

            _pair1 = other.Pair1;
            _pair2 = other.Pair2;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="tuple">
        /// An instance of <see cref="Tuple{T1, T2, T3, T4}"/> which contains correspondive number of values for current instance
        /// </param>
        public Quadra(Tuple<T, T, T, T> tuple)
        {
            Param1 = tuple.Item1;
            Param2 = tuple.Item2;
            Param3 = tuple.Item3;
            Param4 = tuple.Item4;

            _pair1 = new Pair<T>(tuple.Item1, tuple.Item2);
            _pair2 = new Pair<T>(tuple.Item3, tuple.Item4);
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="triad">
        /// An instance of <see cref="Triad{T}"/> which contains three values for current instance
        /// </param>
        /// <param name="param">
        /// A generic type <typeparamref name="T"/> value representing one of parameters in the data type
        /// </param>
        public Quadra(Triad<T> triad, T? param)
        {
            Param1 = triad.Param1;
            Param2 = triad.Param2;
            Param3 = triad.Param3;
            Param4 = param;

            _pair1 = new Pair<T>(triad.Param1, triad.Param2);
            _pair2 = new Pair<T>(triad.Param3, param);
        }

        /// <summary>
        /// Method which swaps two pairs of values inside the current instance
        /// </summary>
        public void Swap()
        {
            (Param1, Param2, Param3, Param4) = (Param3, Param4, Param1, Param2);

            (_pair1, _pair2) = (_pair2, _pair1);
        }

        /// <summary>
        /// Method which replaces the value of one value with the value of the next one inside the current instance, also applied to inner pairs
        /// </summary>
        public void Move()
        {
            (Param1, Param2, Param3, Param4) = (Param4, Param1, Param2, Param3);

            (_pair1, _pair2) = (_pair2, _pair1);
        }

        /// <summary>
        /// Method which redefines every value with their default type value inside the data type
        /// </summary>
        public void Nullify()
        {
            Param1 = default;
            Param2 = default;
            Param3 = default;
            Param4 = default;

            _pair1 = new Pair<T>();
            _pair2 = new Pair<T>();
        }

        /// <summary>
        /// An instance of <see cref="Pair{T}"/> which contains first two parameters of the instance, correspondive <see cref="Param1"/> and <see cref="Param2"/>
        /// </summary>
        public Pair<T> Pair1 => _pair1;
        /// <summary>
        /// An instance of <see cref="Pair{T}"/> which contains other two parameters of the instance, correspondive <see cref="Param3"/> and <see cref="Param4"/>
        /// </summary>
        public Pair<T> Pair2 => _pair2;

        public static implicit operator Quadra<T>(
                                         Tuple<T, T, T, T> value)
        {
            return new Quadra<T>(value);
        }

        public static implicit operator Quadra<T>(
                                              (T, T, T, T) value)
        {
            return new Quadra<T>(value);
        }

        public static bool operator ==(Quadra<T>? quadra1,
                                       Quadra<T>? quadra2)
        {
            if (ReferenceEquals(quadra1,
                                quadra2))
                return true;

            if (quadra1 is null && quadra2 is null)
                return true;
            if (quadra1 is null || quadra2 is null)
                return false;

            return EqualityComparer<T>.Default.Equals(quadra1.Param1, quadra2.Param1) &&
                   EqualityComparer<T>.Default.Equals(quadra1.Param2, quadra2.Param2) &&
                   EqualityComparer<T>.Default.Equals(quadra1.Param3, quadra2.Param3) &&
                   EqualityComparer<T>.Default.Equals(quadra1.Param4, quadra2.Param4);
        }

        public static bool operator !=(Quadra<T>? quadra1,
                                       Quadra<T>? quadra2)
        {
            return !(quadra1 == quadra2);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Quadra<T> another)
            {
                return this == another;
            }

            return false;
        }

        public bool Equals(Quadra<T>? other)
        {
            if(other is null)
                return false;

            return this == other;
        }

        public bool Equals(Quadra<T>? quadra1,
                           Quadra<T>? quadra2)
        {
            if (quadra1 == null && quadra2 == null) return true;
            if (quadra1 == null || quadra2 == null) return false;

            return quadra1 == quadra2;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (Param1?.GetHashCode() ?? 0);
                hash = hash * 23 + (Param2?.GetHashCode() ?? 0);
                hash = hash * 23 + (Param3?.GetHashCode() ?? 0);
                hash = hash * 23 + (Param4?.GetHashCode() ?? 0);
                return hash;
            }
        }

        public int GetHashCode(Quadra<T>? other)
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (Param1?.GetHashCode() ?? 0);
                hash = hash * 23 + (Param2?.GetHashCode() ?? 0);
                hash = hash * 23 + (Param3?.GetHashCode() ?? 0);
                hash = hash * 23 + (Param4?.GetHashCode() ?? 0);
                return hash;
            }
        }
    }

    /// <summary>
    /// A class which represents a non-static container for four values
    /// </summary>
    /// <typeparam name="T1">
    /// A generic type which defines type of pair of values which container will storage
    /// </typeparam>
    /// <typeparam name="T2">
    /// A generic type which defines type of pair of values which container will storage
    /// </typeparam>
#pragma warning disable S4035
    public class Quadra<T1, T2> : IData, IEquatable<Quadra<T1, T2>>,
#pragma warning restore S4035
                                  IEqualityComparer<Quadra<T1, T2>>
    {
        /// <summary>
        /// A generic type <typeparamref name="T1"/> value representing one of parameters in the data type
        /// </summary>
        public T1? Param1 { get; set; } = default;
        /// <summary>
        /// A generic type <typeparamref name="T1"/> value representing one of parameters in the data type
        /// </summary>
        public T1? Param2 { get; set; } = default;
        /// <summary>
        /// A generic type <typeparamref name="T2"/> value representing one of parameters in the data type
        /// </summary>
        public T2? Param3 { get; set; } = default;
        /// <summary>
        /// A generic type <typeparamref name="T2"/> value representing one of parameters in the data type
        /// </summary>
        public T2? Param4 { get; set; } = default;

        /// <summary>
        /// An instance of <see cref="Pair{T}"/> which contains first two parameters of the instance, correspondive <see cref="Param1"/> and <see cref="Param2"/>
        /// </summary>
        private Pair<T1> _pair1 = new();
        /// <summary>
        /// An instance of <see cref="Pair{T}"/> which contains other two parameters of the instance, correspondive <see cref="Param3"/> and <see cref="Param4"/>
        /// </summary>
        private Pair<T2> _pair2 = new();

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        public Quadra() { }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="param1">
        /// A generic type <typeparamref name="T1"/> value representing one of parameters in the data type
        /// </param>
        /// <param name="param2">
        /// A generic type <typeparamref name="T1"/> value representing one of parameters in the data type
        /// </param>
        /// <param name="param3">
        /// A generic type <typeparamref name="T2"/> value representing one of parameters in the data type
        /// </param>
        /// <param name="param4">
        /// A generic type <typeparamref name="T2"/> value representing one of parameters in the data type
        /// </param>
        public Quadra(T1? param1,
                      T1? param2,
                      T2? param3,
                      T2? param4)
        {
            Param1 = param1;
            Param2 = param2;
            Param3 = param3;
            Param4 = param4;

            _pair1 = new Pair<T1>(param1, param2);
            _pair2 = new Pair<T2>(param3, param4);
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="singleton1">
        /// An instance of <see cref="Singleton{T}"/> which contains generic type <typeparamref name="T1"/> value representing one of parameters in the data type
        /// </param>
        /// <param name="singleton2">
        /// An instance of <see cref="Singleton{T}"/> which contains generic type <typeparamref name="T1"/> value representing one of parameters in the data type
        /// </param>
        /// <param name="singleton3">
        /// An instance of <see cref="Singleton{T}"/> which contains generic type <typeparamref name="T2"/> value representing one of parameters in the data type
        /// </param>
        /// <param name="singleton4">
        /// An instance of <see cref="Singleton{T}"/> which contains generic type <typeparamref name="T2"/> value representing one of parameters in the data type
        /// </param>
        public Quadra(Singleton<T1> singleton1,
                      Singleton<T1> singleton2,
                      Singleton<T2> singleton3,
                      Singleton<T2> singleton4)
        {
            Param1 = singleton1.Param;
            Param2 = singleton2.Param;
            Param3 = singleton3.Param;
            Param4 = singleton4.Param;

            _pair1 = new Pair<T1>(singleton1, singleton2);
            _pair2 = new Pair<T2>(singleton3, singleton4);
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="pair1">
        /// An instance of <see cref="Pair{T}"/> which contains pair of generic type <typeparamref name="T1"/> values for current instance of data type
        /// </param>
        /// <param name="pair2">
        /// An instance of <see cref="Pair{T}"/> which contains pair of generic type <typeparamref name="T2"/> values for current instance of data type
        /// </param>
        public Quadra(Pair<T1> pair1,
                      Pair<T2> pair2)
        {
            Param1 = pair1.Param1;
            Param2 = pair1.Param2;
            Param3 = pair2.Param1;
            Param4 = pair2.Param2;

            _pair1 = new Pair<T1>(pair1);
            _pair2 = new Pair<T2>(pair2);
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="pair1">
        /// An instance of <see cref="Pair{T1, T2}"/> which contains pair of generic type <typeparamref name="T1"/> and <typeparamref name="T2"/> values for current instance of data type
        /// </param>
        /// <param name="pair2">
        /// An instance of <see cref="Pair{T1, T2}"/> which contains pair of generic type <typeparamref name="T1"/> and <typeparamref name="T2"/> values for current instance of data type
        /// </param>
        public Quadra(Pair<T1, T2> pair1,
                      Pair<T1, T2> pair2)
        {
            Param1 = pair1.Param1;
            Param2 = pair2.Param1;
            Param3 = pair1.Param2;
            Param4 = pair2.Param2;

            _pair1 = new Pair<T1>(pair1.Param1, pair2.Param1);
            _pair2 = new Pair<T2>(pair1.Param2, pair2.Param2);
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="other">
        /// An instance of <see cref="Quadra{T1, T2}"/> from which current one will be constructed
        /// </param>
        public Quadra(Quadra<T1, T2> other)
        {
            Param1 = other.Param1;
            Param2 = other.Param2;
            Param3 = other.Param3;
            Param4 = other.Param4;

            _pair1 = other.Pair1;
            _pair2 = other.Pair2;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="tuple">
        /// An instance of <see cref="Tuple{T1, T2, T3, T4}"/> which contains correspondive number of values for current instance
        /// </param>
        public Quadra(Tuple<T1, T1, T2, T2> tuple)
        {
            Param1 = tuple.Item1;
            Param2 = tuple.Item2;
            Param3 = tuple.Item3;
            Param4 = tuple.Item4;

            _pair1 = new Pair<T1>(tuple.Item1, tuple.Item2);
            _pair2 = new Pair<T2>(tuple.Item3, tuple.Item4);
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="tuple">
        /// An instance of <see cref="Tuple{T1, T2, T3, T4}"/> which contains correspondive number of values for current instance
        /// </param>
        public Quadra(Tuple<T1, T2, T1, T2> tuple)
        {
            Param1 = tuple.Item1;
            Param2 = tuple.Item3;
            Param3 = tuple.Item2;
            Param4 = tuple.Item4;

            _pair1 = new Pair<T1>(tuple.Item1, tuple.Item3);
            _pair2 = new Pair<T2>(tuple.Item2, tuple.Item4);
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="triad">
        /// An instance of <see cref="Triad{T1, T2}"/> which contains three values for current instance
        /// </param>
        /// <param name="param">
        /// A generic type <typeparamref name="T1"/> value representing one of parameters in the data type
        /// </param>
        public Quadra(Triad<T1, T2> triad, T1? param)
        {
            Param1 = triad.Param1;
            Param2 = param;
            Param3 = triad.Param2;
            Param4 = triad.Param2;

            _pair1 = new Pair<T1>(triad.Param1, param);
            _pair2 = new Pair<T2>(triad.Param2, triad.Param3);
        }

        /// <summary>
        /// Method which swaps two pairs of values inside the current instance
        /// </summary>
        public void Swap()
        {
            var converted_param1 = (T2?)Convert.ChangeType(Param1, typeof(T2));
            var converted_param2 = (T2?)Convert.ChangeType(Param2, typeof(T2));
            var converted_param3 = (T1?)Convert.ChangeType(Param3, typeof(T1));
            var converted_param4 = (T1?)Convert.ChangeType(Param4, typeof(T1));

            (Param1, Param2, Param3, Param4) = (converted_param3, converted_param4, converted_param1, converted_param2);

            (_pair1, _pair2) = (new Pair<T1>(converted_param3, converted_param4),
                                new Pair<T2>(converted_param1, converted_param2));
        }

        /// <summary>
        /// Method which replaces the value of one value with the value of the next one inside the current instance, also applied to inner pairs
        /// </summary>
        public void Move()
        {
            var converted_param1 = (T2?)Convert.ChangeType(Param1, typeof(T2));
            var converted_param2 = (T2?)Convert.ChangeType(Param2, typeof(T2));
            var converted_param3 = (T1?)Convert.ChangeType(Param3, typeof(T1));
            var converted_param4 = (T1?)Convert.ChangeType(Param4, typeof(T1));

            (Param1, Param2, Param3, Param4) = (converted_param4, Param1, converted_param2, Param3);

            (_pair1, _pair2) = (new Pair<T1>(converted_param3, converted_param4),
                                new Pair<T2>(converted_param1, converted_param2));
        }

        /// <summary>
        /// Method which redefines every value with their default type value inside the data type
        /// </summary>
        public void Nullify()
        {
            Param1 = default;
            Param2 = default;
            Param3 = default;
            Param4 = default;

            _pair1 = new Pair<T1>();
            _pair2 = new Pair<T2>();
        }

        /// <summary>
        /// An instance of <see cref="Pair{T}"/> which contains first two parameters of the instance, correspondive <see cref="Param1"/> and <see cref="Param2"/>
        /// </summary>
        public Pair<T1> Pair1 => _pair1;
        /// <summary>
        /// An instance of <see cref="Pair{T}"/> which contains other two parameters of the instance, correspondive <see cref="Param3"/> and <see cref="Param4"/>
        /// </summary>
        public Pair<T2> Pair2 => _pair2;

        public static implicit operator Quadra<T1, T2>(
                                         Tuple<T1, T1, T2, T2> value)
        {
            return new Quadra<T1, T2>(value);
        }

        public static implicit operator Quadra<T1, T2>(
                                              (T1, T1, T2, T2) value)
        {
            return new Quadra<T1, T2>(value);
        } 

        public static implicit operator Quadra<T1, T2>(
                                         Tuple<T1, T2, T1, T2> value)
        {
            return new Quadra<T1, T2>(value);
        }

        public static implicit operator Quadra<T1, T2>(
                                              (T1, T2, T1, T2) value)
        {
            return new Quadra<T1, T2>(value);
        }

        public static bool operator ==(Quadra<T1, T2>? quadra1,
                                       Quadra<T1, T2>? quadra2)
        {
            if (ReferenceEquals(quadra1,
                                quadra2))
                return true;

            if (quadra1 is null && quadra2 is null)
                return true;
            if (quadra1 is null || quadra2 is null)
                return false;

            return EqualityComparer<T1>.Default.Equals(quadra1.Param1, quadra2.Param1) &&
                   EqualityComparer<T1>.Default.Equals(quadra1.Param2, quadra2.Param2) &&
                   EqualityComparer<T2>.Default.Equals(quadra1.Param3, quadra2.Param3) &&
                   EqualityComparer<T2>.Default.Equals(quadra1.Param4, quadra2.Param4);
        }

        public static bool operator !=(Quadra<T1, T2>? quadra1,
                                       Quadra<T1, T2>? quadra2)
        {
            return !(quadra1 == quadra2);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Quadra<T1, T2> another)
            {
                return this == another;
            }

            return false;
        }

        public bool Equals(Quadra<T1, T2>? other)
        {
            if(other is null)
                return false;

            return this == other;
        }

        public bool Equals(Quadra<T1, T2>? quadra1,
                           Quadra<T1, T2>? quadra2)
        {
            if (quadra1 == null && quadra2 == null) return true;
            if (quadra1 == null || quadra2 == null) return false;

            return quadra1 == quadra2;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (Param1?.GetHashCode() ?? 0);
                hash = hash * 23 + (Param2?.GetHashCode() ?? 0);
                hash = hash * 23 + (Param3?.GetHashCode() ?? 0);
                hash = hash * 23 + (Param4?.GetHashCode() ?? 0);
                return hash;
            }
        }

        public int GetHashCode(Quadra<T1, T2>? other)
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (Param1?.GetHashCode() ?? 0);
                hash = hash * 23 + (Param2?.GetHashCode() ?? 0);
                hash = hash * 23 + (Param3?.GetHashCode() ?? 0);
                hash = hash * 23 + (Param4?.GetHashCode() ?? 0);
                return hash;
            }
        }
    }

    /// <summary>
    /// A class which represents a non-static container for four values
    /// </summary>
    /// <typeparam name="T1">
    /// A generic type which defines type of value which container will storage
    /// </typeparam>
    /// <typeparam name="T2">
    /// A generic type which defines type of value which container will storage
    /// </typeparam>
    /// <typeparam name="T3">
    /// A generic type which defines type of pair of values which container will storage
    /// </typeparam>
#pragma warning disable S4035
    public class Quadra<T1, T2, T3> : IData, IEquatable<Quadra<T1, T2, T3>>,
#pragma warning restore S4035
                                      IEqualityComparer<Quadra<T1, T2, T3>>
    {
        /// <summary>
        /// A generic type <typeparamref name="T1"/> value representing one of parameters in the data type
        /// </summary>
        public T1? Param1 { get; set; } = default;
        /// <summary>
        /// A generic type <typeparamref name="T1"/> value representing one of parameters in the data type
        /// </summary>
        public T2? Param2 { get; set; } = default;
        /// <summary>
        /// A generic type <typeparamref name="T2"/> value representing one of parameters in the data type
        /// </summary>
        public T3? Param3 { get; set; } = default;
        /// <summary>
        /// A generic type <typeparamref name="T2"/> value representing one of parameters in the data type
        /// </summary>
        public T3? Param4 { get; set; } = default;

        /// <summary>
        /// An instance of <see cref="Pair{T1, T2}"/> which contains first two parameters of the instance, correspondive <see cref="Param1"/> and <see cref="Param2"/>
        /// </summary>
        private Pair<T1, T2> _pair1 = new();
        /// <summary>
        /// An instance of <see cref="Pair{T}"/> which contains other two parameters of the instance, correspondive <see cref="Param3"/> and <see cref="Param4"/>
        /// </summary>
        private Pair<T3> _pair2 = new();

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        public Quadra() { }

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
        /// <param name="param4">
        /// A generic type <typeparamref name="T3"/> value representing one of parameters in the data type
        /// </param>
        public Quadra(T1? param1,
                      T2? param2,
                      T3? param3,
                      T3? param4)
        {
            Param1 = param1;
            Param2 = param2;
            Param3 = param3;
            Param4 = param4;

            _pair1 = new Pair<T1, T2>(param1, param2);
            _pair2 = new Pair<T3>(param3, param4);
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
        /// <param name="singleton4">
        /// An instance of <see cref="Singleton{T}"/> which contains generic type <typeparamref name="T3"/> value representing one of parameters in the data type
        /// </param>
        public Quadra(Singleton<T1> singleton1,
                      Singleton<T2> singleton2,
                      Singleton<T3> singleton3,
                      Singleton<T3> singleton4)
        {
            Param1 = singleton1.Param;
            Param2 = singleton2.Param;
            Param3 = singleton3.Param;
            Param4 = singleton4.Param;

            _pair1 = new Pair<T1, T2>(singleton1, singleton2);
            _pair2 = new Pair<T3>(singleton3, singleton4);
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="pair1">
        /// An instance of <see cref="Pair{T1, T2}"/> which contains pair of generic type <typeparamref name="T1"/> and <typeparamref name="T3"/> values for current instance of data type
        /// </param>
        /// <param name="pair2">
        /// An instance of <see cref="Pair{T1, T2}"/> which contains pair of generic type <typeparamref name="T2"/> and <typeparamref name="T3"/> values for current instance of data type
        /// </param>
        public Quadra(Pair<T1, T3> pair1,
                      Pair<T2, T3> pair2)
        {
            Param1 = pair1.Param1;
            Param2 = pair2.Param1;
            Param3 = pair1.Param2;
            Param4 = pair2.Param2;

            _pair1 = new Pair<T1, T2>(pair1.Param1, pair2.Param1);
            _pair2 = new Pair<T3>(pair1.Param2, pair2.Param2);
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="pair1">
        /// An instance of <see cref="Pair{T1, T2}"/> which contains pair of generic type <typeparamref name="T1"/> and <typeparamref name="T2"/> values for current instance of data type
        /// </param>
        /// <param name="pair2">
        /// An instance of <see cref="Pair{T}"/> which contains pair of generic type <typeparamref name="T3"/> values for current instance of data type
        /// </param>
        public Quadra(Pair<T1, T2> pair1,
                      Pair<T3> pair2)
        {
            Param1 = pair1.Param1;
            Param2 = pair1.Param2;
            Param3 = pair2.Param1;
            Param4 = pair2.Param2;

            _pair1 = new Pair<T1, T2>(pair1.Param1, pair1.Param2);
            _pair2 = new Pair<T3>(pair2);
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="other">
        /// An instance of <see cref="Quadra{T1, T2, T3}"/> from which current one will be constructed
        /// </param>
        public Quadra(Quadra<T1, T2, T3> other)
        {
            Param1 = other.Param1;
            Param2 = other.Param2;
            Param3 = other.Param3;
            Param4 = other.Param4;

            _pair1 = other.Pair1;
            _pair2 = other.Pair2;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="tuple">
        /// An instance of <see cref="Tuple{T1, T2, T3, T4}"/> which contains correspondive number of values for current instance
        /// </param>
        public Quadra(Tuple<T1, T2, T3, T3> tuple)
        {
            Param1 = tuple.Item1;
            Param2 = tuple.Item2;
            Param3 = tuple.Item3;
            Param4 = tuple.Item4;

            _pair1 = new Pair<T1, T2>(tuple.Item1, tuple.Item2);
            _pair2 = new Pair<T3>(tuple.Item3, tuple.Item4);
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="tuple">
        /// An instance of <see cref="Tuple{T1, T2, T3, T4}"/> which contains correspondive number of values for current instance
        /// </param>
        public Quadra(Tuple<T1, T3, T3, T2> tuple)
        {
            Param1 = tuple.Item1;
            Param2 = tuple.Item4;
            Param3 = tuple.Item2;
            Param4 = tuple.Item3;

            _pair1 = new Pair<T1, T2>(tuple.Item1, tuple.Item4);
            _pair2 = new Pair<T3>(tuple.Item2, tuple.Item3);
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="tuple">
        /// An instance of <see cref="Tuple{T1, T2, T3, T4}"/> which contains correspondive number of values for current instance
        /// </param>
        public Quadra(Tuple<T3, T3, T1, T2> tuple)
        {
            Param1 = tuple.Item3;
            Param2 = tuple.Item4;
            Param3 = tuple.Item1;
            Param4 = tuple.Item2;

            _pair1 = new Pair<T1, T2>(tuple.Item3, tuple.Item4);
            _pair2 = new Pair<T3>(tuple.Item1, tuple.Item2);
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="triad">
        /// An instance of <see cref="Triad{T1, T2, T3}"/> which contains three values for current instance
        /// </param>
        /// <param name="param">
        /// A generic type <typeparamref name="T3"/> value representing one of parameters in the data type
        /// </param>
        public Quadra(Triad<T1, T2, T3> triad, T3? param)
        {
            Param1 = triad.Param1;
            Param2 = triad.Param2;
            Param3 = triad.Param3;
            Param4 = param;

            _pair1 = new Pair<T1, T2>(triad.Param1, triad.Param2);
            _pair2 = new Pair<T3>(triad.Param3, param);
        }

        /// <summary>
        /// Method which swaps two pairs of values inside the current instance
        /// </summary>
        public void Swap()
        {
            var converted_param1 = (T3?)Convert.ChangeType(Param1, typeof(T3));
            var converted_param2 = (T3?)Convert.ChangeType(Param2, typeof(T3));
            var converted_param3 = (T1?)Convert.ChangeType(Param3, typeof(T1));
            var converted_param4 = (T2?)Convert.ChangeType(Param4, typeof(T2));

            (Param1, Param2, Param3, Param4) = (converted_param3, converted_param4, converted_param1, converted_param2);

            (_pair1, _pair2) = (new Pair<T1, T2>(converted_param3, converted_param4),
                                new Pair<T3>(converted_param1, converted_param2));
        }

        /// <summary>
        /// Method which replaces the value of one value with the value of the next one inside the current instance, also applied to inner pairs
        /// </summary>
        public void Move()
        {
            var converted_param1 = (T2?)Convert.ChangeType(Param1, typeof(T2));
            var converted_param2 = (T3?)Convert.ChangeType(Param2, typeof(T3));
            var converted_param3 = (T1?)Convert.ChangeType(Param3, typeof(T1));
            var converted_param4 = (T1?)Convert.ChangeType(Param4, typeof(T1));

            /* Converting fourth parameter in another type for moving pairs operation. */
            var converted_param1_other = (T3?)Convert.ChangeType(Param1, typeof(T3));
            var converted_param4_other = (T2?)Convert.ChangeType(Param4, typeof(T2));

            (Param1, Param2, Param3, Param4) = (converted_param4, converted_param1, converted_param2, Param3);

            (_pair1, _pair2) = (new Pair<T1, T2>(converted_param3, converted_param4_other),
                                new Pair<T3>(converted_param1_other, converted_param2));
        }

        /// <summary>
        /// Method which redefines every value with their default type value inside the data type
        /// </summary>
        public void Nullify()
        {
            Param1 = default;
            Param2 = default;
            Param3 = default;
            Param4 = default;

            _pair1 = new Pair<T1, T2>();
            _pair2 = new Pair<T3>();
        }

        /// <summary>
        /// An instance of <see cref="Pair{T}"/> which contains first two parameters of the instance, correspondive <see cref="Param1"/> and <see cref="Param2"/>
        /// </summary>
        public Pair<T1, T2> Pair1 => _pair1;
        /// <summary>
        /// An instance of <see cref="Pair{T}"/> which contains other two parameters of the instance, correspondive <see cref="Param3"/> and <see cref="Param4"/>
        /// </summary>
        public Pair<T3> Pair2 => _pair2;

        public static implicit operator Quadra<T1, T2, T3>(
                                         Tuple<T1, T2, T3, T3> value)
        {
            return new Quadra<T1, T2, T3>(value);
        }

        public static implicit operator Quadra<T1, T2, T3>(
                                              (T1, T2, T3, T3) value)
        {
            return new Quadra<T1, T2, T3>(value);
        }

        public static implicit operator Quadra<T1, T2, T3>(
                                         Tuple<T1, T3, T3, T2> value)
        {
            return new Quadra<T1, T2, T3>(value);
        }

        public static implicit operator Quadra<T1, T2, T3>(
                                              (T1, T3, T3, T2) value)
        {
            return new Quadra<T1, T2, T3>(value);
        } 

        public static implicit operator Quadra<T1, T2, T3>(
                                         Tuple<T3, T3, T1, T2> value)
        {
            return new Quadra<T1, T2, T3>(value);
        }

        public static implicit operator Quadra<T1, T2, T3>(
                                              (T3, T3, T1, T2) value)
        {
            return new Quadra<T1, T2, T3>(value);
        }

        public static bool operator ==(Quadra<T1, T2, T3>? quadra1,
                                       Quadra<T1, T2, T3>? quadra2)
        {
            if (ReferenceEquals(quadra1,
                                quadra2))
                return true;

            if (quadra1 is null && quadra2 is null)
                return true;
            if (quadra1 is null || quadra2 is null)
                return false;

            return EqualityComparer<T1>.Default.Equals(quadra1.Param1, quadra2.Param1) &&
                   EqualityComparer<T2>.Default.Equals(quadra1.Param2, quadra2.Param2) &&
                   EqualityComparer<T3>.Default.Equals(quadra1.Param3, quadra2.Param3) &&
                   EqualityComparer<T3>.Default.Equals(quadra1.Param4, quadra2.Param4);
        }

        public static bool operator !=(Quadra<T1, T2, T3>? quadra1,
                                       Quadra<T1, T2, T3>? quadra2)
        {
            return !(quadra1 == quadra2);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Quadra<T1, T2, T3> another)
            {
                return this == another;
            }

            return false;
        }

        public bool Equals(Quadra<T1, T2, T3>? other)
        {
            if(other is null)
                return false;

            return this == other;
        }

        public bool Equals(Quadra<T1, T2, T3>? quadra1,
                           Quadra<T1, T2, T3>? quadra2)
        {
            if (quadra1 == null && quadra2 == null) return true;
            if (quadra1 == null || quadra2 == null) return false;

            return quadra1 == quadra2;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (Param1?.GetHashCode() ?? 0);
                hash = hash * 23 + (Param2?.GetHashCode() ?? 0);
                hash = hash * 23 + (Param3?.GetHashCode() ?? 0);
                hash = hash * 23 + (Param4?.GetHashCode() ?? 0);
                return hash;
            }
        }

        public int GetHashCode(Quadra<T1, T2, T3>? other)
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (Param1?.GetHashCode() ?? 0);
                hash = hash * 23 + (Param2?.GetHashCode() ?? 0);
                hash = hash * 23 + (Param3?.GetHashCode() ?? 0);
                hash = hash * 23 + (Param4?.GetHashCode() ?? 0);
                return hash;
            }
        }
    }

    /// <summary>
    /// A class which represents a non-static container for four values
    /// </summary>
    /// <typeparam name="T1">
    /// A generic type which defines type of value which container will storage
    /// </typeparam>
    /// <typeparam name="T2">
    /// A generic type which defines type of value which container will storage
    /// </typeparam>
    /// <typeparam name="T3">
    /// A generic type which defines type of value which container will storage
    /// </typeparam>
    /// <typeparam name="T4">
    /// A generic type which defines type of pair of values which container will storage
    /// </typeparam>
#pragma warning disable S4035
    public class Quadra<T1, T2, T3, T4> : IData, IEquatable<Quadra<T1, T2, T3, T4>>,
#pragma warning restore S4035
                                          IEqualityComparer<Quadra<T1, T2, T3, T4>>
    {
        /// <summary>
        /// A generic type <typeparamref name="T1"/> value representing one of parameters in the data type
        /// </summary>
        public T1? Param1 { get; set; } = default;
        /// <summary>
        /// A generic type <typeparamref name="T1"/> value representing one of parameters in the data type
        /// </summary>
        public T2? Param2 { get; set; } = default;
        /// <summary>
        /// A generic type <typeparamref name="T3"/> value representing one of parameters in the data type
        /// </summary>
        public T3? Param3 { get; set; } = default;
        /// <summary>
        /// A generic type <typeparamref name="T4"/> value representing one of parameters in the data type
        /// </summary>
        public T4? Param4 { get; set; } = default;

        /// <summary>
        /// An instance of <see cref="Pair{T1, T2}"/> which contains first two parameters of the instance, correspondive <see cref="Param1"/> and <see cref="Param2"/>
        /// </summary>
        private Pair<T1, T2> _pair1 = new();
        /// <summary>
        /// An instance of <see cref="Pair{T1, T2}"/> which contains other two parameters of the instance, correspondive <see cref="Param3"/> and <see cref="Param4"/>
        /// </summary>
        private Pair<T3, T4> _pair2 = new();

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        public Quadra() { }

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
        /// <param name="param4">
        /// A generic type <typeparamref name="T4"/> value representing one of parameters in the data type
        /// </param>
        public Quadra(T1? param1,
                      T2? param2,
                      T3? param3,
                      T4? param4)
        {
            Param1 = param1;
            Param2 = param2;
            Param3 = param3;
            Param4 = param4;

            _pair1 = new Pair<T1, T2>(param1, param2);
            _pair2 = new Pair<T3, T4>(param3, param4);
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
        /// <param name="singleton4">
        /// An instance of <see cref="Singleton{T}"/> which contains generic type <typeparamref name="T4"/> value representing one of parameters in the data type
        /// </param>
        public Quadra(Singleton<T1> singleton1,
                      Singleton<T2> singleton2,
                      Singleton<T3> singleton3,
                      Singleton<T4> singleton4)
        {
            Param1 = singleton1.Param;
            Param2 = singleton2.Param;
            Param3 = singleton3.Param;
            Param4 = singleton4.Param;

            _pair1 = new Pair<T1, T2>(singleton1, singleton2);
            _pair2 = new Pair<T3, T4>(singleton3, singleton4);
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="pair1">
        /// An instance of <see cref="Pair{T1, T2}"/> which contains pair of generic type <typeparamref name="T1"/> and <typeparamref name="T2"/> values for current instance of data type
        /// </param>
        /// <param name="pair2">
        /// An instance of <see cref="Pair{T1, T2}"/> which contains pair of generic type <typeparamref name="T3"/> and <typeparamref name="T4"/> values for current instance of data type
        /// </param>
        public Quadra(Pair<T1, T2> pair1,
                      Pair<T3, T4> pair2)
        {
            Param1 = pair1.Param1;
            Param2 = pair1.Param2;
            Param3 = pair2.Param1;
            Param4 = pair2.Param2;

            _pair1 = new Pair<T1, T2>(pair1.Param1, pair1.Param2);
            _pair2 = new Pair<T3, T4>(pair2.Param1, pair2.Param2);
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="pair1">
        /// An instance of <see cref="Pair{T1, T2}"/> which contains pair of generic type <typeparamref name="T1"/> and <typeparamref name="T3"/> values for current instance of data type
        /// </param>
        /// <param name="pair2">
        /// An instance of <see cref="Pair{T1, T2}"/> which contains pair of generic type <typeparamref name="T2"/> and <typeparamref name="T4"/> values for current instance of data type
        /// </param>
        public Quadra(Pair<T1, T3> pair1,
                      Pair<T2, T4> pair2)
        {
            Param1 = pair1.Param1;
            Param2 = pair2.Param1;
            Param3 = pair1.Param2;
            Param4 = pair2.Param2;

            _pair1 = new Pair<T1, T2>(pair1.Param1, pair2.Param1);
            _pair2 = new Pair<T3, T4>(pair1.Param2, pair2.Param2);
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="pair1">
        /// An instance of <see cref="Pair{T1, T2}"/> which contains pair of generic type <typeparamref name="T1"/> and <typeparamref name="T4"/> values for current instance of data type
        /// </param>
        /// <param name="pair2">
        /// An instance of <see cref="Pair{T1, T2}"/> which contains pair of generic type <typeparamref name="T2"/> and <typeparamref name="T3"/> values for current instance of data type
        /// </param>
        public Quadra(Pair<T1, T4> pair1,
                      Pair<T2, T3> pair2)
        {
            Param1 = pair1.Param1;
            Param2 = pair2.Param1;
            Param3 = pair2.Param2;
            Param4 = pair1.Param2;

            _pair1 = new Pair<T1, T2>(pair1.Param1, pair2.Param1);
            _pair2 = new Pair<T3, T4>(pair2.Param2, pair1.Param2);
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="other">
        /// An instance of <see cref="Quadra{T1, T2, T3, T4}"/> from which current one will be constructed
        /// </param>
        public Quadra(Quadra<T1, T2, T3, T4> other)
        {
            Param1 = other.Param1;
            Param2 = other.Param2;
            Param3 = other.Param3;
            Param4 = other.Param4;

            _pair1 = other.Pair1;
            _pair2 = other.Pair2;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="tuple">
        /// An instance of <see cref="Tuple{T1, T2, T3, T4}"/> which contains correspondive number of values for current instance
        /// </param>
        public Quadra(Tuple<T1, T2, T3, T4> tuple)
        {
            Param1 = tuple.Item1;
            Param2 = tuple.Item2;
            Param3 = tuple.Item3;
            Param4 = tuple.Item4;

            _pair1 = new Pair<T1, T2>(tuple.Item1, tuple.Item2);
            _pair2 = new Pair<T3, T4>(tuple.Item3, tuple.Item4);
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="triad">
        /// An instance of <see cref="Triad{T1, T2, T3}"/> which contains three values for current instance
        /// </param>
        /// <param name="param">
        /// A generic type <typeparamref name="T4"/> value representing one of parameters in the data type
        /// </param>
        public Quadra(Triad<T1, T2, T3> triad, T4? param)
        {
            Param1 = triad.Param1;
            Param2 = triad.Param2;
            Param3 = triad.Param3;
            Param4 = param;

            _pair1 = new Pair<T1, T2>(triad.Param1, triad.Param2);
            _pair2 = new Pair<T3, T4>(triad.Param3, param);
        }

        /// <summary>
        /// Method which swaps two pairs of values inside the current instance
        /// </summary>
        public void Swap()
        {
            var converted_param1 = (T3?)Convert.ChangeType(Param1, typeof(T3));
            var converted_param2 = (T4?)Convert.ChangeType(Param2, typeof(T4));
            var converted_param3 = (T1?)Convert.ChangeType(Param3, typeof(T1));
            var converted_param4 = (T2?)Convert.ChangeType(Param4, typeof(T2));

            (Param1, Param2, Param3, Param4) = (converted_param3, converted_param4, converted_param1, converted_param2);

            (_pair1, _pair2) = (new Pair<T1, T2>(converted_param3, converted_param4),
                                new Pair<T3, T4>(converted_param1, converted_param2));
        }

        /// <summary>
        /// Method which replaces the value of one value with the value of the next one inside the current instance, also applied to inner pairs
        /// </summary>
        public void Move()
        {
            var converted_param1 = (T2?)Convert.ChangeType(Param1, typeof(T2));
            var converted_param2 = (T3?)Convert.ChangeType(Param2, typeof(T3));
            var converted_param3 = (T4?)Convert.ChangeType(Param3, typeof(T4));
            var converted_param4 = (T1?)Convert.ChangeType(Param4, typeof(T1));

            /* Converting fourth parameter in another type for moving pairs operation. */
            var converted_param1_other = (T3?)Convert.ChangeType(Param1, typeof(T3));
            var converted_param2_other = (T4?)Convert.ChangeType(Param4, typeof(T4));
            var converted_param3_other = (T1?)Convert.ChangeType(Param3, typeof(T1));
            var converted_param4_other = (T2?)Convert.ChangeType(Param4, typeof(T2));
            (Param1, Param2, Param3, Param4) = (converted_param4, converted_param1, converted_param2, converted_param3);

            (_pair1, _pair2) = (new Pair<T1, T2>(converted_param3_other, converted_param4_other),
                                new Pair<T3, T4>(converted_param1_other, converted_param2_other));
        }

        /// <summary>
        /// Method which redefines every value with their default type value inside the data type
        /// </summary>
        public void Nullify()
        {
            Param1 = default;
            Param2 = default;
            Param3 = default;
            Param4 = default;

            _pair1 = new Pair<T1, T2>();
            _pair2 = new Pair<T3, T4>();
        }

        /// <summary>
        /// An instance of <see cref="Pair{T}"/> which contains first two parameters of the instance, correspondive <see cref="Param1"/> and <see cref="Param2"/>
        /// </summary>
        public Pair<T1, T2> Pair1 => _pair1;
        /// <summary>
        /// An instance of <see cref="Pair{T}"/> which contains other two parameters of the instance, correspondive <see cref="Param3"/> and <see cref="Param4"/>
        /// </summary>
        public Pair<T3, T4> Pair2 => _pair2;

        public static implicit operator Quadra<T1, T2, T3, T4>(
                                         Tuple<T1, T2, T3, T4> value)
        {
            return new Quadra<T1, T2, T3, T4>(value);
        }

        public static implicit operator Quadra<T1, T2, T3, T4>(
                                              (T1, T2, T3, T4) value)
        {
            return new Quadra<T1, T2, T3, T4>(value);
        }

        public static bool operator ==(Quadra<T1, T2, T3, T4>? quadra1,
                                       Quadra<T1, T2, T3, T4>? quadra2)
        {
            if (ReferenceEquals(quadra1,
                                quadra2))
                return true;

            if (quadra1 is null && quadra2 is null)
                return true;
            if (quadra1 is null || quadra2 is null)
                return false;

            return EqualityComparer<T1>.Default.Equals(quadra1.Param1, quadra2.Param1) &&
                   EqualityComparer<T2>.Default.Equals(quadra1.Param2, quadra2.Param2) &&
                   EqualityComparer<T3>.Default.Equals(quadra1.Param3, quadra2.Param3) &&
                   EqualityComparer<T4>.Default.Equals(quadra1.Param4, quadra2.Param4);
        }

        public static bool operator !=(Quadra<T1, T2, T3, T4>? quadra1,
                                       Quadra<T1, T2, T3, T4>? quadra2)
        {
            return !(quadra1 == quadra2);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Quadra<T1, T2, T3, T4> another)
            {
                return this == another;
            }

            return false;
        }

        public bool Equals(Quadra<T1, T2, T3, T4>? other)
        {
            if(other is null)
                return false;

            return this == other;
        }

        public bool Equals(Quadra<T1, T2, T3, T4>? quadra1,
                           Quadra<T1, T2, T3, T4>? quadra2)
        {
            if (quadra1 == null && quadra2 == null) return true;
            if (quadra1 == null || quadra2 == null) return false;

            return quadra1 == quadra2;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (Param1?.GetHashCode() ?? 0);
                hash = hash * 23 + (Param2?.GetHashCode() ?? 0);
                hash = hash * 23 + (Param3?.GetHashCode() ?? 0);
                hash = hash * 23 + (Param4?.GetHashCode() ?? 0);
                return hash;
            }
        }

        public int GetHashCode(Quadra<T1, T2, T3, T4>? other)
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (other?.Param1?.GetHashCode() ?? 0);
                hash = hash * 23 + (other?.Param2?.GetHashCode() ?? 0);
                hash = hash * 23 + (other?.Param3?.GetHashCode() ?? 0);
                hash = hash * 23 + (other?.Param4?.GetHashCode() ?? 0);
                return hash;
            }
        }
    }
}
