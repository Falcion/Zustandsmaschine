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
        /// 
        /// </summary>
        public Jenga() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="capacity"></param>
        public Jenga(int capacity)
        {
            Items = new(capacity);

            Controllers = new(capacity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        public Jenga(ICollection<T> collection)
        {
            Items = new(collection);

            for (int i = 0; i < Items.Count; i++)
                Controllers[i]= Items[i];
        }

        /// <summary>
        /// 
        /// </summary>
        public int Count => Items.Count;

        /// <summary>
        /// 
        /// </summary>
        public List<T> Items { get; } = new();

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<int, T> Controllers { get; } = new();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            int index = Items.Count;

            Items.Add(item);

            Controllers.Add(index, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
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
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public T? Peek()
        {
            if(Items.Count == 0)
                throw new InvalidOperationException("Can't interact with the empty instance of jengas.");

            int index = Items.Count - 1;

            return Items[index];
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
