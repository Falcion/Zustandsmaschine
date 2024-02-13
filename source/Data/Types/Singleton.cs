namespace Zustand.Data.Types
{
    using Zustand.Data.Types.Interfaces;

    /// <summary>
    /// A non-generic dynamic representation of <see cref="Singleton{T}"/> which holds <see cref="Object"/> as it's primary type
    /// </summary>
    public class Singleton : Singleton<object>
    {
        /* Not-implemented code. */
    }

    /// <summary>
    /// A class which represents a non-static container for one single value which avoids precompilation preparations
    /// </summary>
    /// <typeparam name="T">
    /// A generic type which defines type of value which container will storage
    /// </typeparam>
#pragma warning disable S4035
    public class Singleton<T> : IData, IEquatable<Singleton<T>>,
#pragma warning restore S4035
                                IEqualityComparer<Singleton<T>>
    {
        /// <summary>
        /// A generic type <typeparamref name="T"/> value representing one of parameters in the data type
        /// </summary>
        public T? Param { get; set; } = default;

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        public Singleton() { }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="param">
        /// A generic type <typeparamref name="T"/> value representing one of parameters in the data type
        /// </param>
        public Singleton(T? param)
        {
            Param = param;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="other">
        /// An instance of <see cref="Singleton{T}"/> from which current one will be constructed
        /// </param>
        public Singleton(Singleton<T> other)
        {
            Param = other.Param;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="tuple">
        /// An instance of <see cref="Tuple{T1}"/> which contains correspondive number of values for current instance
        /// </param>
        public Singleton(Tuple<T> tuple)
        {
            Param = tuple.Item1;
        }

        /// <summary>
        /// Method which swaps two indefinetely paired within values inside the data type
        /// </summary>
        /// <exception cref="NotSupportedException">
        /// Thrown via any form of usage of this method in this class.
        /// </exception>
#pragma warning disable S1133
        [Obsolete("Singleton instance can't support methods for more than one-parameter interactions.", true)]
#pragma warning restore S1133
        public void Swap()
        {
            throw new NotSupportedException("Singleton instance can't support methods for more than one-parameter interactions.");
        }

        /// <summary>
        /// Method which replaces the value of one value with the value of the next one inside the data type
        /// </summary>
        /// <exception cref="NotSupportedException">
        /// Thrown via any form of usage of this method in this class.
        /// </exception>
#pragma warning disable S1133
        [Obsolete("Singleton instance can't support methods for more than one-parameter interactions.", true)]
#pragma warning restore S1133
        public void Move()
        {
            throw new NotSupportedException("Singleton instance can't support methods for more than one-parameter interactions.");
        }

        /// <summary>
        /// Method which redefines every value with their default type value inside the data type
        /// </summary>
        public void Nullify()
        {
            Param = default;
        }

        public static implicit operator Singleton<T>(
                                            Tuple<T> value)
        {
            return new Singleton<T>(value);
        }

        public static implicit operator Singleton<T>(
                                                  T value)
        {
            return new Singleton<T>(value);
        }

        public static bool operator ==(Singleton<T>? singleton1, 
                                       Singleton<T>? singleton2)
        {
            if (ReferenceEquals(singleton1,
                                singleton2))
                return true;

            if (singleton1 is null && singleton2 is null)
                return true;
            if (singleton1 is null || singleton2 is null)
                return false;

            return EqualityComparer<T>.Default.Equals(singleton1.Param,
                                                      singleton2.Param);
        }

        public static bool operator !=(Singleton<T>? singleton1, 
                                       Singleton<T>? singleton2)
        {
            return !(singleton1 == singleton2);
        }

        public override bool Equals(object? obj)
        {
            if(obj is Singleton<T> another) 
            {
                return this == another;
            }

            return false;
        }

        public bool Equals(Singleton<T>? other)
        {
            if(other is null)
                return false;

            return this == other;
        }

        public bool Equals(Singleton<T>? singleton1, 
                           Singleton<T>? singleton2)
        {
            if (singleton1 == null && singleton2 == null) return true;
            if (singleton1 == null || singleton2 == null) return false;

            return singleton1 == singleton2;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (Param?.GetHashCode() ?? 0);
                return hash;
            }
        }

        public int GetHashCode(Singleton<T>? other)
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (other?.Param?.GetHashCode() ?? 0);
                return hash;
            }
        }
    }
}
