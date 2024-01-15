using System;

using System.Collections;
using System.Collections.Generic;

namespace Zustand.Data.Arrays 
{
    /// <summary>
    /// A non-generic dynamic representation of <see cref="Jenga{T}"/> which holds <see cref="Object"/> as it's primary type
    /// </summary>
    public class Jenga : Jenga<object> 
    { 
        /* Not-implemented code. */
    }

    /// <summary>
    /// A class which represents an unique array data structure reminiscent of the structure of the same name
    /// </summary>
    /// <typeparam name="T">
    /// A generic type which defines type of value which array structure will storage as it's values
    /// </typeparam>
    public class Jenga<T> : ICollection<T>, ICloneable
    {
        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        public Jenga() { }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="capacity">
        /// A signed 32-bit integer value which represents the initial specified capacity both for internal items and controllers collections
        /// </param>
        public Jenga(int capacity)
        {
            Controllers = new(capacity);
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="collection">
        /// An instance of <see cref="ICollection{T}"/> from which current constructor generate the new instance
        /// </param>
        public Jenga(ICollection<T> collection)
        {
            List<T> _data = new(collection);

            for (int i = 0; i < _data.Count; i++)
                Controllers[i]= _data[i];
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="instance">
        /// An instance of <see cref="Jenga{T}"/> which represents another instance from which this one would be built
        /// </param>
        public Jenga(Jenga<T> instance)
        {
            Controllers = instance.Controllers;
        }

        /// <summary>
        /// A signed 32-bit integer value which represents number of elements inside the <see cref="List{T}"/> of inner instance
        /// </summary>
        public int Count => Controllers.Values.Count;

        /// <summary>
        /// A signed 64-bit integer value which represents number of elements inside the <see cref="List{T}"/> of inner instance
        /// </summary>
#pragma warning disable CA1829
        public long LongCount => Controllers.Values.LongCount();
#pragma warning restore CA1829

        /// <summary>
        /// An instance of <see cref="List{T}"/> which represents values inside of the controllers
        /// </summary>
#pragma warning disable S2365
        public List<T> Items => Controllers.Values.ToList();
#pragma warning restore S2365

        /// <summary>
        /// An instance of <see cref="Dictionary{TKey, TValue}"/> which represents keys paired with values ressembling the identifiers of every value in current instance
        /// </summary>
        public Dictionary<Int64, T> Controllers { get; internal set; } = new();

        /// <summary>
        /// Method which pushes given item on top position of the current instance
        /// </summary>
        /// <param name="item">
        /// A generic type <typeparamref name="T"/> value representing input
        /// </param>
        public virtual void Push(T item)
        {
            Int64 index = Controllers.Values.Count;

            Controllers.Add(index, item);
        }

        /// <summary>
        /// Method which removes and returns the object at the top of the current instance
        /// </summary>
        /// <returns>
        /// An instance of <typeparamref name="T"/> which represents the object at the top of the current instance
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when current instance of inner <see cref="List{T}"/> doesn't have any items in it
        /// </exception>
        public virtual T? Pop()
        {
            if(Controllers.Values.Count == 0)
                throw new InvalidOperationException("Can't interact with the empty instance of jengas.");

            Int64 index = Controllers.Values.Count - 1;

            T item = Controllers[index];

            Controllers.Remove(index);

            return item;
        }

        /// <summary>
        /// Method which returns the object at the top of the current instance without removing it
        /// </summary>
        /// <returns>
        /// An instance of <typeparamref name="T"/> which represents the object at the top of the current instance
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when current instance of inner <see cref="List{T}"/> doesn't have any items in it
        /// </exception>
        public virtual T? Peek()
        {
            if(Controllers.Values.Count == 0)
                throw new InvalidOperationException("Can't interact with the empty instance of jengas.");

            Int64 index = Controllers.Values.Count - 1;

            return Controllers[index];
        }

        /// <summary>
        /// Boolean parameter which indicates whether access to the current instance is thread safe.
        /// </summary>
        public virtual bool IsSynchronized => false;

        /// <summary>
        /// An object which can be used to synchronize access to the current instance
        /// </summary>
        public object SyncRoot => new();

        /// <summary>
        /// Method which removes every item from the current instance
        /// </summary>
        public virtual void Clear()
        {
            Controllers.Clear();
        }

        /// <summary>
        /// Method which creates an object copy of current instance
        /// </summary>
        /// <returns>
        /// An instance of <see cref="Jenga{T}"/> which represents clone of the current instance
        /// </returns>
        public virtual object Clone()
        {
            return new Jenga<T>(this);
        }

        /// <summary>
        /// Method which determines whether an item is in the current instance
        /// </summary>
        /// <param name="item">
        /// A generic type <typeparamref name="T"/> value representing input
        /// </param>
        /// <returns>
        /// Boolean parameter which represents whether an item is in <see cref="Dictionary{TKey, TValue}"/> of inner instance
        /// </returns>
        public virtual bool Contains(T item)
        {
            return Controllers.ContainsValue(item);
        }

        /// <summary>
        /// Method which copies the current instance to an existing one-dimensional array of elements by specified index
        /// </summary>
        /// <param name="array">
        /// An one-dimensional <see cref="Array"/> of <typeparamref name="T"/> type values 
        /// </param>
        /// <param name="arrayIndex">
        /// A signed 32-bit integer value which represents starting array index to be copied to 
        /// </param>
        public virtual void CopyTo(T[] array, 
                                   int arrayIndex)
        {
            Controllers.Values.CopyTo(array, 
                                      arrayIndex);
        }

        /// <summary>
        /// Method which converts current instance to the synchronized, meaning thread safe, wrapper of the given instance
        /// </summary>
        /// <param name="instance">
        /// An instance of <see cref="Jenga{T}"/> which represents required to convert instance of collection
        /// </param>
        /// <returns>
        /// An instance of <see cref="Threadsafe.Jenga{T}"/> which represents synchronized wrapper of the given instance
        /// </returns>
        public static Threadsafe.Jenga<T> Synchronized(Jenga<T> instance)
#pragma warning disable IDE0090
               => new Threadsafe.Jenga<T>(instance);
#pragma warning restore IDE0090

        /// <summary>
        /// Unsupported by exception method which supposedly adds an item to the current instance
        /// </summary>
        /// <param name="item">
        /// A generic type <typeparamref name="T"/> value representing input
        /// </param>
        /// <exception cref="NotSupportedException">
        /// Thrown via impossible usage of this method
        /// </exception>
        [Obsolete("An instance of this collection type acts as collection, but not interacts as it, instead use custom provided functionality or analogs of it.", true)]
        public void Add(T item)
        {
            throw new NotSupportedException($"An instance of {nameof(Jenga<T>)} type acts as collection, but not interacts as it, instead use custom provided functionality or analogs of it.");
        }

        /// <summary>
        /// Unsupported by exception method which supposedly removes an item from the current instance
        /// </summary>
        /// <param name="item">
        /// A generic type <typeparamref name="T"/> value representing input
        /// </param>
        /// <returns>
        /// Boolean parameter which represents whether item was successfully deleted from instance or not
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// Thrown via impossible usage of this method
        /// </exception>
        [Obsolete("An instance of this collection type acts as collection, but not interacts as it, instead use custom provided functionality or analogs of it.", true)]
        public bool Remove(T item)
        {
            throw new NotSupportedException($"An instance of {nameof(Jenga<T>)} type acts as collection, but not interacts as it, instead use custom provided functionality or analogs of it.");
        }

        /// <summary>
        /// Boolean parameter which indicates whether collection is read-only
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Method which returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An instance of <see cref="IEnumerator{T}"/> which can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<T> GetEnumerator() 
        => Controllers.Values.GetEnumerator();

        /// <summary>
        /// Method which returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An instance of <see cref="IEnumerator"/> which can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator() 
                             => GetEnumerator();

        /// <summary>
        /// Method which adds an item to the current instance
        /// </summary>
        /// <param name="item">
        /// A generic type <typeparamref name="T"/> value representing input
        /// </param>
        public virtual void Enter(T item)
        {
            Push(item);
        }

        /// <summary>
        /// Method which appends the current instance by position-key
        /// </summary>
        /// <param name="position">
        /// A signed 64-bit integer value which represents the position-key of input into the current instance of inner part
        /// </param>
        [Obsolete("Entering default for generic type value cause exceptions in case of custom collection, usage of this method can cause exceptions.")]
        public virtual void Enter(Int64 position)
        {
#pragma warning disable CS8604
            Enter(position, default);
#pragma warning restore CS8604
        }

        /// <summary>
        /// Method which adds an item to the current instance by position-key
        /// </summary>
        /// <param name="position">
        /// A signed 64-bit integer value which represents the position-key of input into the current instance of inner part
        /// </param>
        /// <param name="item">
        /// A generic type <typeparamref name="T"/> value representing input
        /// </param>
        /// <exception cref="IndexOutOfRangeException">
        /// Thrown via incorrect usage or input of indexes for <see cref="List{T}"/> either <see cref="Dictionary{TKey, TValue}"/>
        /// </exception>
        public virtual void Enter(Int64 position, T item)
        {
            /* If instance doesn't have any item in it yet. */
            if(Controllers.Keys.Count < 1)
            {
                if (position > Controllers.EnsureCapacity((int) position))
#pragma warning disable S112 
                    throw new IndexOutOfRangeException("Tried to enter the value out of capacity of inner instance of jenga.");
#pragma warning restore S112
                
                Controllers[position]= item;
            }
            else
            {
                if (position < 0 && 
                    position >= Controllers.Values.Count)
#pragma warning disable S112
                    throw new IndexOutOfRangeException("Invalid position specified.");
#pragma warning restore S112

                /* Move the existing item at the specified position to the top 
                 * n' insert the new item at the specified position. */

                var existing_item = Controllers[position];

                Push(existing_item);

                Controllers[position]= item;
            }
        }

        /// <summary>
        /// Method which removes given item from current instance
        /// </summary>
        /// <param name="item">
        /// A generic type <typeparamref name="T"/> value representing input
        /// </param>
        /// <returns>
        /// Boolean parameter which indicates whether item was successfully removed from innner instance or not
        /// </returns>
        public virtual bool Exit(T item)
        {
            if (!Contains(item)) return false;

            Int64 supposed_key = Controllers.FirstOrDefault(K => EqualityComparer<T>.Default.Equals(K.Value, item)).Key;

            Controllers.Remove(supposed_key);

            return true;
        }

        /// <summary>
        /// Method which removes given item from current instance by it's position-key
        /// </summary>
        /// <param name="position">
        /// A signed 64-bit integer value which represents the position-key of input into the current instance of inner part
        /// </param>
        /// <returns>
        /// Boolean parameter which indicates whether item was successfully removed from innner instance or not
        /// </returns>
        public virtual bool Exit(Int64 position)
        {
            /* Item does not exist in current instance, so return false as result. */
            if(!Controllers.ContainsKey(position)) return false;

            Controllers.Remove(position); 
            
            return true;
        }

        /// <summary>
        /// Method which removes given item from current instance and by it's position-key
        /// </summary>
        /// <param name="position">
        /// A signed 32-bit integer value which represents the position-key of input into the current instance of inner part
        /// </param>
        /// <param name="item">
        /// A generic type <typeparamref name="T"/> value representing input
        /// </param>
        /// <returns>
        /// Boolean parameter which indicates whether item was successfully removed from innner instance or not
        /// </returns>
        public virtual bool Exit(Int64 position, T item)
        {
            if (position < 0 || 
                position >= Controllers.Values.Count) return false;

            /* Check if the item at the specified position matches the provided item */
            if (!EqualityComparer<T>.Default.Equals(Controllers[position], item)) return false;

            Controllers.Remove(position);

            return true;
        }

        /// <summary>
        /// Index accessor for get-set pair of functions for this instance of a collection
        /// </summary>
        /// <param name="position">
        /// A signed 32-bit integer value which represents the position-key of input into the current instance of inner part
        /// </param>
        /// <returns>
        /// A generic type <typeparamref name="T"/> value representing parameter from inner instance
        /// </returns>
        public virtual T this[Int64 position]
        {
            get
            {
                return Controllers[position];
            }

            set
            {
                T item = Controllers[position];

                /* Add the overridden item to the top and 
                 * assign the new value at the specified position */

                Push(item);

                Controllers[position] = value;
            }
        } 
    }

    /*
     * Creating non-generic dynamic representation for <see cref="Jenga{TKey, TValue} is not presented in theory, and
     * the only way of using something close to it, is just constructing instance with both key and value as objects.
     */

    /// <summary>
    /// A class which represents an unique array data structure reminiscent of the structure of the same name
    /// </summary>
    /// <typeparam name="TKey">
    /// A generic type which defines type of keys with which by array structure will contain generic values of it
    /// </typeparam>
    /// <typeparam name="TValue">
    /// A generic type which defines type of value which array structure will storage as it's values
    /// </typeparam>
    public class Jenga<TKey, TValue> : IDictionary<TKey, TValue>, ICloneable where TKey : notnull 
    {
        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        public Jenga() { }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="capacity">
        /// A signed 32-bit integer value which represents the initial specified capacity both for internal items and controllers collections
        /// </param>
        public Jenga(int capacity)
        {
            Controllers = new(capacity);
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="dictionary">
        /// An instance of <see cref="IDictionary{TKey, TValue}"/> which represents an base of any <see cref="Dictionary{TKey, TValue}"/>
        /// </param>
        public Jenga(IDictionary<TKey, TValue> dictionary)
        {
            Controllers = new(dictionary);
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="dictionary">
        /// An instance of <see cref="IEnumerable{T}"/> where generic type is represented by <see cref="KeyValuePair{TKey, TValue}"/> which represents an base of any <see cref="Dictionary{TKey, TValue}"/>
        /// </param>
        public Jenga(IEnumerable<KeyValuePair<TKey, TValue>> dictionary)
        {

            Controllers = new(dictionary);
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="instance">
        /// An instance of <see cref="Jenga{TKey, TValue}"/> which represents another instance from which this one would be built
        /// </param>
        public Jenga(Jenga<TKey, TValue> instance)
        {
            Controllers = instance.Controllers;
        }

        /// <summary>
        /// A signed 32-bit integer value which represents number of elements inside the <see cref="Dictionary{TKey, TValue}"/> of inner instance
        /// </summary>
        public int Count => Controllers.Values.Count;

        /// <summary>
        /// A signed 64-bit integer value which represents number of elements inside the <see cref="Dictionary{TKey, TValue}"/> of inner instance
        /// </summary>
#pragma warning disable CA1829
        public long LongCount => Controllers.Values.LongCount();
#pragma warning restore CA1829

        /// <summary>
        /// An instance of <see cref="List{TValue}"/> which represents values inside of the controllers
        /// </summary>
#pragma warning disable S2365
        public List<TValue> Items => Controllers.Values.ToList();
#pragma warning restore S2365

        /// <summary>
        /// An instance of <see cref="Dictionary{TKey, TValue}"/> which represents keys paired with values ressembling the identifiers of every value in current instance
        /// </summary>
        public Dictionary<TKey, TValue> Controllers { get; internal set; } = new();

        /// <summary>
        /// Method which pushes given item on given key position of the current instance
        /// </summary>
        /// <param name="key">
        /// A generic type <typeparamref name="TKey"/> value representing key position in the <see cref="Dictionary{TKey, TValue}"/> of instance
        /// </param>
        /// <param name="value">
        /// A generic type <typeparamref name="TValue"/> value representing item value as input
        /// </param>
        public virtual void Push(TKey key, TValue value)
        {
            Controllers.Add(key, value);
        }

        /// <summary>
        /// Method which removes and returns the object at the top of the current instance
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
        public virtual TValue? Pop()
        {
            if(Controllers.Values.Count == 0)
                throw new InvalidOperationException("Can't interact with the empty instance of jengas.");

            var key = Controllers.Keys.LastOrDefault();

            if(key is null)
                throw new ArgumentOutOfRangeException(nameof(key), new InvalidOperationException("Can't interact with the empty instance of jengas."));

            var value = Controllers[key];

            Controllers.Remove(key);

            return value;
        }

        /// <summary>
        /// Method which returns the object at the top of the current instance without removing it
        /// </summary>
        /// <returns>
        /// An instance of <typeparamref name="TValue"/> which represents the object at the top of the current instance
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when current instance of inner <see cref="Dictionary{TKey, TValue}"/> doesn't have any items in it
        /// </exception>
        public virtual TValue? Peek()
        {
            if (Controllers.Values.Count == 0)
                throw new InvalidOperationException("Can't interact with the empty instance of jengas.");

            return Controllers.Values.LastOrDefault();
        }

        /// <summary>
        /// Boolean parameter which indicates whether access to the current instance is thread safe.
        /// </summary>
        public virtual bool IsSynchronized => false;

        /// <summary>
        /// An object which can be used to synchronize access to the current instance
        /// </summary>
        public object SyncRoot => new();

        /// <summary>
        /// Method which removes every item from the current instance
        /// </summary>
        public virtual void Clear()
        {
            Controllers.Clear();
        }

        /// <summary>
        /// Method which creates an object copy of current instance
        /// </summary>
        /// <returns>
        /// An instance of <see cref="Jenga{TKey, TValue}"/> which represents clone of the current instance
        /// </returns>
        public virtual object Clone()
        {
            return new Jenga<TKey, TValue>(this);
        }

        /// <summary>
        /// Method which determines whether an item is in the current instance
        /// </summary>
        /// <param name="item">
        /// A generic type <see cref="KeyValuePair{TKey, TValue}"/> value representing input
        /// </param>
        /// <returns>
        /// Boolean parameter which represents whether an item is in <see cref="Dictionary{TKey, TValue}"/> of inner instance
        /// </returns>
        public virtual bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return Controllers.Contains(item);
        }

        /// <summary>
        /// Method which determines whether the key is in the current instance
        /// </summary>
        /// <param name="key">
        /// A generic type <typeparamref name="TKey"/> value representing key position in the <see cref="Dictionary{TKey, TValue}"/> of instance
        /// </param>
        /// <returns>
        /// Boolean parameter which represents whether the key is in <see cref="Dictionary{TKey, TValue}"/> of inner instance
        /// </returns>
        public virtual bool ContainsKey(TKey key)
        {
            return Controllers.ContainsKey(key);
        }

        /// <summary>
        /// Method which determines whether the value is in the current instance
        /// </summary>
        /// <param name="value">
        /// A generic type <typeparamref name="TValue"/> value representing item value as input
        /// </param>
        /// <returns>
        /// Boolean parameter which represents whether the key is in <see cref="Dictionary{TKey, TValue}"/> of inner instance
        /// </returns>
        public virtual bool ContainsValue(TValue value)
        {
            return Controllers.ContainsValue(value);
        }

        /// <summary>
        /// Method which tries to get specified value associated with given key
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
        public virtual bool TryGetValue(TKey key, out TValue value)
        {
#pragma warning disable CS8601
            return Controllers.TryGetValue(key, out value);
#pragma warning restore CS8601
        }

        /// <summary>
        /// Method which copies the current instance to an existing one-dimensional array of elements by specified index
        /// </summary>
        /// <param name="array">
        /// An one-dimensional <see cref="Array"/> of <typeparamref name="TValue"/> type values 
        /// </param>
        /// <param name="arrayIndex">
        /// A signed 32-bit integer value which represents starting array index to be copied to 
        /// </param>
        public virtual void CopyTo(TValue[] array,
                                        int arrayIndex)
        {
            Controllers.Values.CopyTo(array,
                                      arrayIndex);
        }

        /// <summary>
        /// Method which copies the current instance to an existing one-dimensional array of elements by specified index
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
        public virtual void CopyTo(KeyValuePair<TKey, TValue>[] array,
                                                            int arrayIndex)
        {
            if (arrayIndex < 0 || 
                arrayIndex >= array.Length)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), $"Invalid start index in copying method of {nameof(Jenga<TKey, TValue>)} instance");

            if (array.Length - 
                arrayIndex < Controllers.Count)
                throw new ArgumentException($"Not enough space in the array to accommodate all elements starting from the specified index from instance of {nameof(Jenga<TKey, TValue>)}");

            int J = arrayIndex;

            foreach(var K in Controllers)
            {
                array[J] = K;
                J++;
            }
        }

        /// <summary>
        /// Method which converts current instance to the synchronized, meaning thread safe, wrapper of the given instance
        /// </summary>
        /// <param name="instance">
        /// An instance of <see cref="Jenga{TKey, TValue}"/> which represents required to convert instance of collection
        /// </param>
        /// <returns>
        /// An instance of <see cref="Threadsafe.Jenga{TKey, TValue}"/> which represents synchronized wrapper of the given instance
        /// </returns>
        public static Threadsafe.Jenga<TKey, TValue> Synchronized(Jenga<TKey, TValue> instance)
#pragma warning disable IDE0090
               => new Threadsafe.Jenga<TKey, TValue>(instance);
#pragma warning restore IDE0090

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
        [Obsolete("An instance of this collection type acts as dictionary, but not interacts as it, instead use custom provided functionality or analogs of it.", true)]
        public void Add(TKey key, TValue value)
        {
            throw new NotSupportedException($"An instance of {nameof(Jenga<TKey, TValue>)} type acts as dictionary, but not interacts as it, instead use custom provided functionality or analogs of it.");
        }

        /// <summary>
        /// Unsupported by exception method which supposedly adds an item to the current instance
        /// </summary>
        /// <param name="item">
        /// An instance value of <see cref="KeyValuePair{TKey, TValue}"/> which represents input
        /// </param>
        /// <exception cref="NotSupportedException">
        /// Thrown via impossible usage of this method
        /// </exception>
        [Obsolete("An instance of this collection type acts as dictionary, but not interacts as it, instead use custom provided functionality or analogs of it.", true)]
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotSupportedException($"An instance of {nameof(Jenga<TKey, TValue>)} type acts as dictionary, but not interacts as it, instead use custom provided functionality or analogs of it.");
        }

        /// <summary>
        /// Unsupported by exception method which supposedly removes an item from the current instance
        /// </summary>
        /// <param name="key">
        /// A generic type <typeparamref name="TKey"/> value representing key position in the <see cref="Dictionary{TKey, TValue}"/> of instance
        /// </param>
        /// <returns>
        /// Boolean parameter which represents whether item was successfully deleted from instance or not
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// Thrown via impossible usage of this method
        /// </exception>
        [Obsolete("An instance of this collection type acts as dictionary, but not interacts as it, instead use custom provided functionality or analogs of it.", true)]
        public bool Remove(TKey key)
        {
            throw new NotSupportedException($"An instance of {nameof(Jenga<TKey, TValue>)} type acts as dictionary, but not interacts as it, instead use custom provided functionality or analogs of it.");
        }

        /// <summary>
        /// Unsupported by exception method which supposedly removes an item from the current instance
        /// </summary>
        /// <param name="item">
        /// An instance value of <see cref="KeyValuePair{TKey, TValue}"/> which represents input
        /// </param>
        /// <returns>
        /// Boolean parameter which represents whether item was successfully deleted from instance or not
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// Thrown via impossible usage of this method
        /// </exception>
        [Obsolete("An instance of this collection type acts as dictionary, but not interacts as it, instead use custom provided functionality or analogs of it.", true)]
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotSupportedException($"An instance of {nameof(Jenga<TKey, TValue>)} type acts as dictionary, but not interacts as it, instead use custom provided functionality or analogs of it.");
        }

        /// <summary>
        /// Method which adds an item to the current instance
        /// </summary>
        /// <param name="key">
        /// A generic type <typeparamref name="TKey"/> value representing key position in the <see cref="Dictionary{TKey, TValue}"/> of instance
        /// </param>
        /// <param name="value">
        /// A generic type <typeparamref name="TValue"/> value representing item value as input
        /// </param>
        public virtual void Enter(TKey key, TValue value)
        {
            Push(key, value);
        }

        /// <summary>
        /// Method which adds an item to the current instance
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
        /// <exception cref="ArgumentException">
        /// Thrown when appending key is already occupied by another value and is not equal to default instance of the type
        /// </exception>
        public virtual void Enter(TKey key, TValue value, TKey append_key)
        {
            if(!Controllers.ContainsKey(key))
                Enter(key, value);
            else
            {
                if(Controllers.ContainsKey(append_key) && !EqualityComparer<TValue>.Default.Equals(Controllers[append_key], default))
                    throw new ArgumentException("Can't set existing in current instance of jenga key as append key for case of updating existing key situation.", 
                                                                                                 nameof(append_key));

                var temp = Controllers[key];

                Controllers[key] = value;

                /* Using infinite appendable tower logic for current instance of jenga. */
                Enter(append_key, temp);
            }
        }

        /// <summary>
        /// Method which adds an item to the current instance
        /// </summary>
        /// <param name="item">
        /// An instance value of <see cref="KeyValuePair{TKey, TValue}"/> which represents input
        /// </param>
        public virtual void Enter(KeyValuePair<TKey, TValue> item)
        {
            Push(item.Key,
                 item.Value);
        }

        /// <summary>
        /// Method which adds an item to the current instance
        /// </summary>
        /// <param name="item">
        /// An instance value of <see cref="KeyValuePair{TKey, TValue}"/> which represents input
        /// </param>
        /// <param name="append_key">
        /// A generic type <typeparamref name="TKey"/> value representing appending position in the <see cref="Dictionary{TKey, TValue}"/> of instance in which old <typeparamref name="TValue"/> of old <typeparamref name="TKey"/> would be added as new value
        /// </param>
        public virtual void Enter(KeyValuePair<TKey, TValue> item, TKey append_key)
        {
            Enter(item.Key,
                  item.Value, append_key);
        }

        /// <summary>
        /// Method which adds an item to the current instance
        /// </summary>
        /// <param name="key">
        /// A generic type <typeparamref name="TKey"/> value representing key position in the <see cref="Dictionary{TKey, TValue}"/> of instance
        /// </param>
        [Obsolete("Entering default for generic type value cause exceptions in case of custom dictionary, usage of this method can cause exceptions.")]
        public virtual void Enter(TKey key)
        {
#pragma warning disable CS8604 
            Enter(key, default);
#pragma warning restore CS8604
        }

        /// <summary>
        /// Method which removes given item from current instance
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
        public virtual bool Exit(TKey key, TValue value)
        {
            /* Check if the item at the specified position matches the provided item */
            if (!EqualityComparer<TValue>.Default.Equals(Controllers[key], value)) return false;

            var RST = Controllers.Remove(key);

            return RST;
        }

        /// <summary>
        /// Method which removes given item from current instance
        /// </summary>
        /// <param name="item">
        /// An instance value of <see cref="KeyValuePair{TKey, TValue}"/> which represents input
        /// </param>
        /// <returns>
        /// Boolean parameter which indicates whether item was successfully removed from innner instance or not
        /// </returns>
        public virtual bool Exit(KeyValuePair<TKey, TValue> item)
        {
            var RST = Exit(item.Key, 
                           item.Value);

            return RST;
        }

        /// <summary>
        /// Method which removes given item from current instance
        /// </summary>
        /// <param name="key">
        /// A generic type <typeparamref name="TKey"/> value representing key position in the <see cref="Dictionary{TKey, TValue}"/> of instance
        /// </param>
        /// <returns>
        /// Boolean parameter which indicates whether item was successfully removed from innner instance or not
        /// </returns>
        public virtual bool Exit(TKey key)
        {
            /* Item does not exist in current instance, so return false as result. */
            if (!Controllers.ContainsKey(key)) return false;

            var RST = Controllers.Remove(key);

            return RST;
        }

        /// <summary>
        /// Boolean parameter which indicates whether collection is read-only
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Method which returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An instance of <see cref="IEnumerator{T}"/> which can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
                                        => Controllers.GetEnumerator();

        /// <summary>
        /// Method which returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An instance of <see cref="IEnumerator"/> which can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
                             => GetEnumerator();

        /// <summary>
        /// An instance of <see cref="ICollection{T}"/> which represents array of keys of <see cref="Dictionary{TKey, TValue}"/> of the inner instance
        /// </summary>
        public ICollection<TKey> Keys => Controllers.Keys;

        /// <summary>
        /// An instance of <see cref="ICollection{T}"/> which represents array of values of <see cref="Dictionary{TKey, TValue}"/> of the inner instance
        /// </summary>
        public ICollection<TValue> Values => Controllers.Values;

        /// <summary>
        /// Index accessor for get-set pair of functions for this instance of a dictionary
        /// </summary>
        /// <param name="key">
        /// A generic type <typeparamref name="TKey"/> value representing key position in the <see cref="Dictionary{TKey, TValue}"/> of instance
        /// </param>
        /// <returns>
        /// A generic type <typeparamref name="TValue"/> value representing parameter from inner instance
        /// </returns>
        public virtual TValue this[TKey key]
        {
            get
            {
                return Controllers[key];
            }
            set
            {
                Controllers[key] = value;
            }
        }
    }
}
