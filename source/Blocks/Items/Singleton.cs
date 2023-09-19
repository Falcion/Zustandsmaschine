using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zustand.Blocks.Items
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> : IBlock where T : notnull 
    {
        /// <summary>
        /// 
        /// </summary>
        public T? Param;

        /// <summary>
        /// 
        /// </summary>
        public Singleton() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public Singleton(T? param)
        {
            Param = param;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="NotSupportedException"></exception>
#pragma warning disable S1133
        [Obsolete("Block-interface implementation is not supported in singleton object because of its behaviour.", true)]

        public void Swap()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="NotSupportedException"></exception>
        [Obsolete("Block-interface implementation is not supported in singleton object because of its behaviour.", true)]
#pragma warning restore S1133
        public void Move()
        {
            throw new NotSupportedException();
        }
    }
}
