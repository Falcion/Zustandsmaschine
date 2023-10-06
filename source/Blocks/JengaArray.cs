using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Zustand.Blocks
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
#pragma warning disable S3925
    public class JengaArray<T> : ISerializable, ICollection<T>
#pragma warning restore S3925
    {
        /// <summary>
        /// 
        /// </summary>
        /// 
        [NonSerialized]
        private readonly List<T> _stackList = new();
        /// <summary>
        /// 
        /// </summary>
        /// 
        [NonSerialized]
        private readonly Dictionary<int, T> _elementDict = new();

        /// <summary>
        /// 
        /// </summary>
        public JengaArray() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="capacity"></param>
        public JengaArray(int capacity)
        {
            _stackList = new List<T>(capacity);
            _elementDict = new Dictionary<int, T>(capacity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        public JengaArray(ICollection<T> collection)
        {
            _stackList = new List<T>(collection);

            for(int i = 0; i < _stackList.Count; i++)
            {
                _elementDict[i] = _stackList[i];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public JengaArray(SerializationInfo info, StreamingContext context)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public int Count => _stackList.Count;

        /// <summary>
        /// 
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// 
        /// </summary>
        public List<T> StackList => _stackList;
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<int, T> ElementDict => _elementDict;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        public void Push(T element)
        {
            int index = _stackList.Count;
            _stackList.Add(element);
            ElementDict[index] = element;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T? Pop()
        {
            if (_stackList.Count == 0)
                return default;

            int index = _stackList.Count - 1;
            T element = _stackList[index];
            _stackList.RemoveAt(index);
            ElementDict.Remove(index);
            return element;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T? Peek()
        {
            if (_stackList.Count == 0)
                return default;

            int index = _stackList.Count - 1;
            return _stackList[index];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T? GetElementByIndex(int index)
        {
            if (!ElementDict.ContainsKey(index))
                return default;

            return ElementDict[index];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Count", Count);
            info.AddValue("IsReadOnly", IsReadOnly);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            Push(item);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            _stackList.Clear();
            ElementDict.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            return _stackList.Contains(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            _stackList.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            int index = _stackList.LastIndexOf(item);
            if (index >= 0)
            {
                _stackList.RemoveAt(index);
                ElementDict.Remove(index);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return _stackList.GetEnumerator();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Join(", ", _stackList);
        }
    }
}
