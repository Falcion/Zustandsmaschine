using System;
using System.Collections;

namespace Zustand.Data.Arrays 
{
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
            Items = new(capacity);

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
            Items = new(collection);

            for (int i = 0; i < Items.Count; i++)
                Controllers[i]= Items[i];
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="instance">
        /// An instance of <see cref="Jenga{T}"/> which represents another instance from which this one would be built
        /// </param>
        public Jenga(Jenga<T> instance)
        {
            Items = instance.Items;

            Controllers = instance.Controllers;
        }

        /// <summary>
        /// A signed 32-bit integer value which represents number of elements inside the <see cref="List{T}"/> of inner instance
        /// </summary>
        public int Count => Items.Count;

        /// <summary>
        /// An instance of <see cref="List{T}"/> which represents values which current instance holds
        /// </summary>
        public List<T> Items { get; } = new();

        /// <summary>
        /// An instance of <see cref="Dictionary{TKey, TValue}"/> which represents keys paired with values ressembling the identifiers of every value in current instance
        /// </summary>
        public Dictionary<int, T> Controllers { get; } = new();

        /// <summary>
        /// Method which pushes given item on top position of the current instance
        /// </summary>
        /// <param name="item">
        /// A generic type <see href="T"/> value representing input
        /// </param>
        public void Push(T item)
        {
            int index = Items.Count;

            Items.Add(item);

            Controllers.Add(index, item);
        }

        /// <summary>
        /// Method which removes and returns the object at the top of the current instance
        /// </summary>
        /// <returns>
        /// An instance of <see href="T"/> which represents the object at the top of the current instance
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when current instance of inner <see cref="List{T}"/> doesn't have any items in it
        /// </exception>
        public T? Pop()
        {
            if(Items.Count == 0)
                throw new InvalidOperationException("Can't interact with the empty instance of jengas.");

            int index = Items.Count - 1;

            T item = Items[index];

            Items.RemoveAt(index);

            Controllers.Remove(index);

            return item;
        }

        /// <summary>
        /// Method which returns the object at the top of the current instance without removing it
        /// </summary>
        /// <returns>
        /// An instance of <see href="T"/> which represents the object at the top of the current instance
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when current instance of inner <see cref="List{T}"/> doesn't have any items in it
        /// </exception>
        public T? Peek()
        {
            if(Items.Count == 0)
                throw new InvalidOperationException("Can't interact with the empty instance of jengas.");

            int index = Items.Count - 1;

            return Items[index];
        }

        /// <summary>
        /// Boolean parameter which indicates whether access to the current instance is thread safe.
        /// </summary>
        public bool IsSynchronized => false;

        /// <summary>
        /// An object which can be used to synchronize access to the current instance
        /// </summary>
        public object SyncRoot => new();

        /// <summary>
        /// Method which removes every item from the current instance
        /// </summary>
        public void Clear()
        {
            Items.Clear();

            Controllers.Clear();
        }

        /// <summary>
        /// Method which creates an object copy of current instance
        /// </summary>
        /// <returns>
        /// An instance of <see cref="Jenga{T}"/> which represents clone of the current instance
        /// </returns>
        public object Clone()
        {
            return new Jenga<T>(this);
        }

        /// <summary>
        /// Method which determines whether an item is in the current instance
        /// </summary>
        /// <param name="item">
        /// A generic type <see href="T"/> value representing input
        /// </param>
        /// <returns>
        /// Boolean parameter which represents whether an item is in <see cref="List{T}"/> and <see cref="Dictionary{TKey, TValue}"/> of inner instance
        /// </returns>
        public bool Contains(T item)
        {
            return (Items.Contains(item) && Controllers.ContainsValue(item));
        }

        /// <summary>
        /// Method which copies the current instance to an existing one-dimensional array of elements by specified index
        /// </summary>
        /// <param name="array">
        /// An one-dimensional <see cref="Array"/> of <see href="T"/> type values 
        /// </param>
        /// <param name="arrayIndex">
        /// A signed 32-bit integer value which represents starting array index to be copied to 
        /// </param>
        public void CopyTo(T[] array, 
                           int arrayIndex)
        {
            Items.CopyTo(array, 
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
        /// A generic type <see href="T"/> value representing input
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
        /// A generic type <see href="T"/> value representing input
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
                     => Items.GetEnumerator();

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
        /// A generic type <see href="T"/> value representing input
        /// </param>
        public void Enter(T item)
        {
            Push(item);
        }

        /// <summary>
        /// Method which appends the current instance by position-key
        /// </summary>
        /// <param name="position">
        /// A signed 32-bit integer value which represents the position-key of input into the current instance of inner part
        /// </param>
        [Obsolete("Entering default for generic type value cause exceptions in case of custom collection, usage of this method can cause exceptions.")]
        public void Enter(int position)
        {
#pragma warning disable CS8604
            Enter(position, default);
#pragma warning restore CS8604
        }

        /// <summary>
        /// Method which adds an item to the current instance by position-key
        /// </summary>
        /// <param name="position">
        /// A signed 32-bit integer value which represents the position-key of input into the current instance of inner part
        /// </param>
        /// <param name="item">
        /// A generic type <see href="T"/> value representing input
        /// </param>
        /// <exception cref="IndexOutOfRangeException">
        /// Thrown via incorrect usage or input of indexes for <see cref="List{T}"/> either <see cref="Dictionary{TKey, TValue}"/>
        /// </exception>
        public void Enter(int position, T item)
        {
            /* If instance doesn't have any item in it yet. */
            if(Controllers.Keys.Count < 1)
            {
                if (position > Items.Capacity)
#pragma warning disable S112 
                    throw new IndexOutOfRangeException("Tried to enter the value out of capacity of inner instance of jenga.");
#pragma warning restore S112
                
                Items.Insert(position, item);

                Controllers[position]= item;
            }
            else
            {
                if (position < 0 && 
                    position >= Items.Count)
#pragma warning disable S112
                    throw new IndexOutOfRangeException("Invalid position specified.");
#pragma warning restore S112

                /* Move the existing item at the specified position to the top 
                 * n' insert the new item at the specified position. */

                var existing_item = Items[position];

                Items.RemoveAt(position);

                Push(existing_item);

                Items.Insert(position, item);
                Controllers[position]= item;
            }
        }

        /// <summary>
        /// Method which removes given item from current instance
        /// </summary>
        /// <param name="item">
        /// A generic type <see href="T"/> value representing input
        /// </param>
        /// <returns>
        /// Boolean parameter which indicates whether item was successfully removed from innner instance or not
        /// </returns>
        public bool Exit(T item)
        {
            if (!Contains(item)) return false;

            Items.Remove(item);

            int supposed_key = Controllers.FirstOrDefault(K => EqualityComparer<T>.Default.Equals(K.Value, item)).Key;

            Controllers.Remove(supposed_key);

            return true;
        }

        /// <summary>
        /// Method which removes given item from current instance by it's position-key
        /// </summary>
        /// <param name="position">
        /// A signed 32-bit integer value which represents the position-key of input into the current instance of inner part
        /// </param>
        /// <returns>
        /// Boolean parameter which indicates whether item was successfully removed from innner instance or not
        /// </returns>
        public bool Exit(int position)
        {
            var item = Items.ElementAtOrDefault<T>(position);

            /* Item does not exist in current instance, so return false as result. */
            if(item == null) return false;

            Items.RemoveAt(position);

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
        /// A generic type <see href="T"/> value representing input
        /// </param>
        /// <returns>
        /// Boolean parameter which indicates whether item was successfully removed from innner instance or not
        /// </returns>
        public bool Exit(int position, T item)
        {
            if (position < 0 || 
                position >= Items.Count) return false;

            /* Check if the item at the specified position matches the provided item */
            if (!EqualityComparer<T>.Default.Equals(Items[position], item)) return false;

            Items.RemoveAt(position);

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
        /// A generic type <see href="T"/> value representing parameter from inner instance
        /// </returns>
        public T this[int position]
        {
            get
            {
                return Items[position];
            }

            set
            {
                T item = Items[position];

                Items.RemoveAt(position);

                /* Add the overridden item to the top and 
                 * assign the new value at the specified position */

                Push(item);

                Items[position] = value;
            }
        } 
    }

    /// <summary>
    /// A class which represents an unique array data structure reminiscent of the structure of the same name
    /// </summary>
    /// <typeparam name="K">
    /// A generic type which defines type of keys with which by array structure will contain generic values of it
    /// </typeparam>
    /// <typeparam name="T">
    /// A generic type which defines type of value which array structure will storage as it's values
    /// </typeparam>
    public class Jenga<K, T> : IDictionary<K, T>, ICloneable where K : notnull 
    {

    }
}
