using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zustand.Data.Types.Interfaces;

namespace Zustand.Data.Types
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> : IData
    {
        /// <summary>
        /// 
        /// </summary>
        public T? Param { get; set; } = default(T?);

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
        /// 
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
        /// 
        /// </summary>
        public void Nullify()
        {
            Param = default(T?);
        }
    }
}
