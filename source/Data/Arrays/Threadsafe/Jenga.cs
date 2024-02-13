namespace Zustand.Data.Arrays.Threadsafe
{
    /// <summary>
    /// Thread-safe non-generic dynamic representation of <see cref="Jenga{T}"/> which holds <see cref="Object"/> as it's primary type
    /// </summary>
    public class Jenga : Jenga<object>
    {
        /// <summary>
        /// Thread-safe instance constructor for the class
        /// </summary>
        /// <param name="instance">
        /// An instance of <see cref="Arrays.Jenga"/> which represents another instance from which this one would be built
        /// </param>
        public Jenga(Arrays.Jenga instance) : base(instance)
        {
            lock(SyncRoot)
            {
                Controllers = instance.Controllers;
            }
        }
    }

    /// <summary>
    /// Thread-safe representation of <see cref="Arrays.Jenga{T}"/>
    /// </summary>
    /// <typeparam name="T">
    /// A generic type which defines type of value which array structure will storage as it's values
    /// </typeparam>
    public class Jenga<T> : Arrays.Jenga<T>
    {
        /// <summary>
        /// Thread-safe instance constructor for the class
        /// </summary>
        /// <param name="instance">
        /// An instance of <see cref="Arrays.Jenga{T}"/> which represents another instance from which this one would be built
        /// </param>
        public Jenga(Arrays.Jenga<T> instance)
        {
            lock (SyncRoot)
            {
                Controllers = instance.Controllers;
            }
        }

        /// <summary>
        /// Thread-safe method which pushes given item on top position of the current instance
        /// </summary>
        /// <param name="item">
        /// A generic type <see href="T"/> value representing input
        /// </param>
        public override void Push(T item)
        {
            lock (SyncRoot)
            {
                base.Push(item);
            }
        }

        /// <summary>
        /// Thread-safe method which removes and returns the object at the top of the current instance
        /// </summary>
        /// <returns>
        /// An instance of <see href="T"/> which represents the object at the top of the current instance
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when current instance of inner <see cref="List{T}"/> doesn't have any items in it
        /// </exception>
        public override T? Pop()
        {
            lock (SyncRoot)
            {
                return base.Pop();
            }
        }

        /// <summary>
        /// Thread-safe method which returns the object at the top of the current instance without removing it
        /// </summary>
        /// <returns>
        /// An instance of <see href="T"/> which represents the object at the top of the current instance
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when current instance of inner <see cref="List{T}"/> doesn't have any items in it
        /// </exception>
        public override T? Peek()
        {
            lock (SyncRoot)
            {
                return base.Peek();
            }
        }

        /// <summary>
        /// Boolean parameter which indicates whether access to the current instance is thread safe.
        /// </summary>
        public override bool IsSynchronized => true;

        /// <summary>
        /// Thread-safe method which removes every item from the current instance
        /// </summary>
        public override void Clear()
        {
            lock (SyncRoot)
            {
                base.Clear();
            }
        }

        /// <summary>
        /// Thread-safe method which creates an object copy of current instance
        /// </summary>
        /// <returns>
        /// An instance of <see cref="Jenga{T}"/> which represents clone of the current instance
        /// </returns>
        public override object Clone()
        {
            lock (SyncRoot)
            {
                return base.Clone();
            }
        }

        /// <summary>
        /// Thread-safe method which determines whether an item is in the current instance
        /// </summary>
        /// <param name="item">
        /// A generic type <see href="T"/> value representing input
        /// </param>
        /// <returns>
        /// Boolean parameter which represents whether an item is in <see cref="List{T}"/> and <see cref="Dictionary{TKey, TValue}"/> of inner instance
        /// </returns>
        public override bool Contains(T item)
        {
            lock (SyncRoot)
            {
                return base.Contains(item);
            }
        }

        /// <summary>
        /// Thread-safe method which copies the current instance to an existing one-dimensional array of elements by specified index
        /// </summary>
        /// <param name="array">
        /// An one-dimensional <see cref="Array"/> of <see href="T"/> type values 
        /// </param>
        /// <param name="arrayIndex">
        /// A signed 32-bit integer value which represents starting array index to be copied to 
        /// </param>
        public override void CopyTo(T[] array, int arrayIndex)
        {
            lock (SyncRoot)
            {
                base.CopyTo(array, arrayIndex);
            }
        }

        /// <summary>
        /// Thread-safe method which adds an item to the current instance
        /// </summary>
        /// <param name="item">
        /// A generic type <see href="T"/> value representing input
        /// </param>
        public override void Enter(T item)
        {
            lock (SyncRoot)
            {
                base.Enter(item);
            }
        }

        /// <summary>
        /// Thread-safe method which appends the current instance by position-key
        /// </summary>
        /// <param name="position">
        /// A signed 64-bit integer value which represents the position-key of input into the current instance of inner part
        /// </param>
#pragma warning disable S1133
        [Obsolete("Entering default for generic type value cause exceptions in case of custom collection, usage of this method can cause exceptions.")]
#pragma warning restore S1133
        public override void Enter(Int64 position)
        {
            lock (SyncRoot)
            {
                base.Enter(position);
            }
        }

        /// <summary>
        /// Thread-safe method which adds an item to the current instance by position-key
        /// </summary>
        /// <param name="position">
        /// A signed 64-bit integer value which represents the position-key of input into the current instance of inner part
        /// </param>
        /// <param name="item">
        /// A generic type <see href="T"/> value representing input
        /// </param>
        /// <exception cref="IndexOutOfRangeException">
        /// Thrown via incorrect usage or input of indexes for <see cref="List{T}"/> either <see cref="Dictionary{TKey, TValue}"/>
        /// </exception>
        public override void Enter(Int64 position, T item)
        {
            lock (SyncRoot)
            {
                base.Enter(position, item);
            }
        }

        /// <summary>
        /// Thread-safe method which removes given item from current instance
        /// </summary>
        /// <param name="item">
        /// A generic type <see href="T"/> value representing input
        /// </param>
        /// <returns>
        /// Boolean parameter which indicates whether item was successfully removed from innner instance or not
        /// </returns>
        public override bool Exit(T item)
        {
            lock (SyncRoot)
            {
                return base.Exit(item);
            }
        }

        /// <summary>
        /// Thread-safe method which removes given item from current instance by it's position-key
        /// </summary>
        /// <param name="position">
        /// A signed 64-bit integer value which represents the position-key of input into the current instance of inner part
        /// </param>
        /// <returns>
        /// Boolean parameter which indicates whether item was successfully removed from innner instance or not
        /// </returns>
        public override bool Exit(Int64 position)
        {
            lock (SyncRoot)
            {
                return base.Exit(position);
            }
        }

        /// <summary>
        /// Thread-safe method which removes given item from current instance and by it's position-key
        /// </summary>
        /// <param name="position">
        /// A signed 64-bit integer value which represents the position-key of input into the current instance of inner part
        /// </param>
        /// <param name="item">
        /// A generic type <see href="T"/> value representing input
        /// </param>
        /// <returns>
        /// Boolean parameter which indicates whether item was successfully removed from innner instance or not
        /// </returns>
        public override bool Exit(Int64 position, T item)
        {
            lock (SyncRoot)
            {
                return base.Exit(position, item);
            }
        }

        /// <summary>
        /// Thread-safe index accessor for get-set pair of functions for this instance of a collection
        /// </summary>
        /// <param name="position">
        /// A signed 64-bit integer value which represents the position-key of input into the current instance of inner part
        /// </param>
        /// <returns>
        /// A generic type <see href="T"/> value representing parameter from inner instance
        /// </returns>
        public override T this[Int64 position]
        {
            get
            {
                lock (SyncRoot)
                {
                    return base[position];
                }
            }
            set
            {
                lock (SyncRoot)
                {
                    base[position] = value;
                }
            }
        }
    }

    /// <summary>
    /// Thread-safe representation of <see cref="Arrays.Jenga{TKey, TValue}"/>
    /// </summary>
    /// <typeparam name="TKey">
    /// A generic type which defines type of keys with which by array structure will contain generic values of it
    /// </typeparam>
    /// <typeparam name="TValue">
    /// A generic type which defines type of value which array structure will storage as it's values
    /// </typeparam>
    public class Jenga<TKey, TValue> : Arrays.Jenga<TKey, TValue> where TKey : notnull
    {
        /// <summary>
        /// Thread-safe instance constructor for the class
        /// </summary>
        /// <param name="instance">
        /// An instance of <see cref="Arrays.Jenga{TKey, TValue}"/> which represents another instance from which this one would be built
        /// </param>
        public Jenga(Arrays.Jenga<TKey, TValue> instance)
        {
            lock (SyncRoot)
            {
                Controllers = instance.Controllers;
            }
        }

        /// <summary>
        /// Thread-safe method which pushes given item on given key position of the current instance
        /// </summary>
        /// <param name="key">
        /// A generic type <typeparamref name="TKey"/> value representing key position in the <see cref="Dictionary{TKey, TValue}"/> of instance
        /// </param>
        /// <param name="value">
        /// A generic type <typeparamref name="TValue"/> value representing item value as input
        /// </param>
        public override void Push(TKey key, TValue value)
        {
            lock (SyncRoot)
            {
                base.Push(key, value);
            }
        }

        /// <summary>
        /// Thread-safe method which removes and returns the object at the top of the current instance
        /// </summary>
        /// <returns>
        /// An instance of <typeparamref name="TValue"/> which represents the object at the top of the current instance
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when current instance of inner <see cref="Dictionary{TKey, TValue}"/> doesn't have any items in it
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when current instance does not have any top or referecning as last or default item
        /// </exception>
        public override TValue? Pop()
        {
            lock (SyncRoot)
            {
                return base.Pop();
            }
        }

        /// <summary>
        /// Thread-safe method which returns the object at the top of the current instance without removing it
        /// </summary>
        /// <returns>
        /// An instance of <typeparamref name="TValue"/> which represents the object at the top of the current instance
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when current instance of inner <see cref="Dictionary{TKey, TValue}"/> doesn't have any items in it
        /// </exception>
        public override TValue? Peek()
        {
            lock (SyncRoot)
            {
                return base.Peek();
            }
        }

        /// <summary>
        /// Boolean parameter which indicates whether access to the current instance is thread safe.
        /// </summary>
        public override bool IsSynchronized => true;

        /// <summary>
        /// Thread-safe which removes every item from the current instance
        /// </summary>
        public override void Clear()
        {
            lock (SyncRoot)
            {
                base.Clear();
            }
        }

        /// <summary>
        /// Thread-safe which creates an object copy of current instance
        /// </summary>
        /// <returns>
        /// An instance of <see cref="Jenga{TKey, TValue}"/> which represents clone of the current instance
        /// </returns>
        public override object Clone()
        {
            lock (SyncRoot)
            {
                return base.Clone();
            }
        }

        /// <summary>
        /// Thread-safe method which determines whether an item is in the current instance
        /// </summary>
        /// <param name="item">
        /// A generic type <see cref="KeyValuePair{TKey, TValue}"/> value representing input
        /// </param>
        /// <returns>
        /// Boolean parameter which represents whether an item is in <see cref="Dictionary{TKey, TValue}"/> of inner instance
        /// </returns>
        public override bool Contains(KeyValuePair<TKey, TValue> item)
        {
            lock (SyncRoot)
            {
                return base.Contains(item);
            }
        }

        /// <summary>
        /// Thread-safe method which determines whether the key is in the current instance
        /// </summary>
        /// <param name="key">
        /// A generic type <typeparamref name="TKey"/> value representing key position in the <see cref="Dictionary{TKey, TValue}"/> of instance
        /// </param>
        /// <returns>
        /// Boolean parameter which represents whether the key is in <see cref="Dictionary{TKey, TValue}"/> of inner instance
        /// </returns>
        public override bool ContainsKey(TKey key)
        {
            lock (SyncRoot)
            {
                return base.ContainsKey(key);
            }
        }

        /// <summary>
        /// Thread-safe method which determines whether the value is in the current instance
        /// </summary>
        /// <param name="value">
        /// A generic type <typeparamref name="TValue"/> value representing item value as input
        /// </param>
        /// <returns>
        /// Boolean parameter which represents whether the key is in <see cref="Dictionary{TKey, TValue}"/> of inner instance
        /// </returns>
        public override bool ContainsValue(TValue value)
        {
            lock (SyncRoot)
            {
                return base.ContainsValue(value);
            }
        }

        /// <summary>
        /// Thread-safe method which tries to get specified value associated with given key
        /// </summary>
        /// <param name="key">
        /// A generic type <typeparamref name="TKey"/> value representing key position in the <see cref="Dictionary{TKey, TValue}"/> of instance
        /// </param>
        /// <param name="value">
        /// A generic type <typeparamref name="TValue"/> value representing item value as input
        /// </param>
        /// <returns>
        /// Boolean parameter which represents whether inner instance contains given value with associated given key or not
        /// </returns>
        public override bool TryGetValue(TKey key, out TValue value)
        {
            lock (SyncRoot)
            {
                return base.TryGetValue(key, out value);
            }
        }

        /// <summary>
        /// Thread-safe method which copies the current instance to an existing one-dimensional array of elements by specified index
        /// </summary>
        /// <param name="array">
        /// An one-dimensional <see cref="Array"/> of <typeparamref name="TValue"/> type values 
        /// </param>
        /// <param name="arrayIndex">
        /// A signed 32-bit integer value which represents starting array index to be copied to 
        /// </param>
        public override void CopyTo(TValue[] array,
                                         int arrayIndex)
        {
            lock (SyncRoot)
            {
                base.CopyTo(array, arrayIndex);
            }
        }

        /// <summary>
        /// Thread-safe method which copies the current instance to an existing one-dimensional array of elements by specified index
        /// </summary>
        /// <param name="array">
        /// An one-dimensional <see cref="Array"/> of <see cref="KeyValuePair{TKey, TValue}"/> type values 
        /// </param>
        /// <param name="arrayIndex">
        /// A signed 32-bit integer value which represents starting array index to be copied to 
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when given index is not in valid ranges of array's capacity
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when given array is not valid because of it's maximum capacity
        /// </exception>
        public override void CopyTo(KeyValuePair<TKey, TValue>[] array,
                                                             int arrayIndex)
        {
            lock (SyncRoot)
            {
                base.CopyTo(array, arrayIndex);
            }
        }

        /// <summary>
        /// Unsupported by exception method which supposedly adds an item to the current instance
        /// </summary>
        /// <param name="key">
        /// A generic type <typeparamref name="TKey"/> value representing key position in the <see cref="Dictionary{TKey, TValue}"/> of instance
        /// </param>
        /// <param name="value">
        /// A generic type <typeparamref name="TValue"/> value representing item value as input
        /// </param>
        /// <exception cref="NotSupportedException">
        /// Thrown via impossible usage of this method
        /// </exception>
        public override void Enter(TKey key, TValue value)
        {
            lock (SyncRoot)
            {
                base.Enter(key, value);
            }
        }

        /// <summary>
        /// Thread-safe method which adds an item to the current instance
        /// </summary>
        /// <param name="key">
        /// A generic type <typeparamref name="TKey"/> value representing key position in the <see cref="Dictionary{TKey, TValue}"/> of instance
        /// </param>
        /// <param name="value">
        /// A generic type <typeparamref name="TValue"/> value representing item value as input
        /// </param>
        /// <param name="append_key">
        /// A generic type <typeparamref name="TKey"/> value representing appending position in the <see cref="Dictionary{TKey, TValue}"/> of instance in which old <typeparamref name="TValue"/> of old <typeparamref name="TKey"/> would be added as new value
        /// </param>
        public override void Enter(TKey key, TValue value, TKey append_key)
        {
            lock (SyncRoot)
            {
                base.Enter(key, value, append_key);
            }
        }

        /// <summary>
        /// Thread-safe method which adds an item to the current instance
        /// </summary>
        /// <param name="item">
        /// An instance value of <see cref="KeyValuePair{TKey, TValue}"/> which represents input
        /// </param>
        public override void Enter(KeyValuePair<TKey, TValue> item)
        {
            lock (SyncRoot)
            {
                base.Enter(item);
            }
        }

        /// <summary>
        /// Thread-safe method which adds an item to the current instance
        /// </summary>
        /// <param name="item">
        /// An instance value of <see cref="KeyValuePair{TKey, TValue}"/> which represents input
        /// </param>
        /// <param name="append_key">
        /// A generic type <typeparamref name="TKey"/> value representing appending position in the <see cref="Dictionary{TKey, TValue}"/> of instance in which old <typeparamref name="TValue"/> of old <typeparamref name="TKey"/> would be added as new value
        /// </param>
        public override void Enter(KeyValuePair<TKey, TValue> item, TKey append_key)
        {
            lock (SyncRoot)
            {
                base.Enter(item, append_key);
            }
        }

        /// <summary>
        /// Thread-safe method which adds an item to the current instance
        /// </summary>
        /// <param name="key">
        /// A generic type <typeparamref name="TKey"/> value representing key position in the <see cref="Dictionary{TKey, TValue}"/> of instance
        /// </param>
#pragma warning disable S1133
        [Obsolete("Entering default for generic type value cause exceptions in case of custom dictionary, usage of this method can cause exceptions.")]
#pragma warning restore S1133
        public override void Enter(TKey key)
        {
            lock (SyncRoot)
            {
                base.Enter(key);
            }
        }

        /// <summary>
        /// Thread-safe which removes given item from current instance
        /// </summary>
        /// <param name="key">
        /// A generic type <typeparamref name="TKey"/> value representing key position in the <see cref="Dictionary{TKey, TValue}"/> of instance
        /// </param>
        /// <param name="value">
        /// A generic type <typeparamref name="TValue"/> value representing item value as input
        /// </param>
        /// <returns>
        /// Boolean parameter which indicates whether item was successfully removed from innner instance or not
        /// </returns>
        public override bool Exit(TKey key, TValue value)
        {
            lock (SyncRoot)
            {
                return base.Exit(key, value);
            }
        }

        /// <summary>
        /// Thread-safe which removes given item from current instance
        /// </summary>
        /// <param name="item">
        /// An instance value of <see cref="KeyValuePair{TKey, TValue}"/> which represents input
        /// </param>
        /// <returns>
        /// Boolean parameter which indicates whether item was successfully removed from innner instance or not
        /// </returns>
        public override bool Exit(KeyValuePair<TKey, TValue> item)
        {
            lock (SyncRoot)
            {
                return base.Exit(item);
            }
        }

        /// <summary>
        /// Thread-safe which removes given item from current instance
        /// </summary>
        /// <param name="key">
        /// A generic type <typeparamref name="TKey"/> value representing key position in the <see cref="Dictionary{TKey, TValue}"/> of instance
        /// </param>
        /// <returns>
        /// Boolean parameter which indicates whether item was successfully removed from innner instance or not
        /// </returns>
        public override bool Exit(TKey key)
        {
            lock (SyncRoot)
            {
                return base.Exit(key);
            }
        }

        /// <summary>
        /// Thread-safe index accessor for get-set pair of functions for this instance of a dictionary
        /// </summary>
        /// <param name="key">
        /// A generic type <typeparamref name="TKey"/> value representing key position in the <see cref="Dictionary{TKey, TValue}"/> of instance
        /// </param>
        /// <returns>
        /// A generic type <typeparamref name="TValue"/> value representing parameter from inner instance
        /// </returns>
        public override TValue this[TKey key]
        {
            get
            {
                lock (SyncRoot)
                {
                    return base[key];
                }
            }
            set
            {
                lock (SyncRoot)
                {
                    base[key] = value;
                }
            }
        }
    }
}
