using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zustand.Blocks.Items
{
    #region Single generic pair
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Pair<T> : IBlock where T : notnull
    {
        /// <summary>
        /// 
        /// </summary>
        public T? Param1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public T? Param2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Pair() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        public Pair(T? param1, T? param2)
        {
            Param1 = param1;
            Param2 = param2;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Swap()
        {
            (Param1, Param2) = (Param2, Param1);
        }

        /// <summary>
        /// 
        /// </summary>
#pragma warning disable S1133
        [Obsolete("Method does the same thing as swap in case of pairs.")]
#pragma warning restore S1133
        public void Move()
        {
            Swap();
        }
    }
    #endregion
    #region Double generic pair
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public class Pair<T1, T2> : IBlock where T1 : notnull where T2 : notnull
    {
        /// <summary>
        /// 
        /// </summary>
        public T1? Param1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public T2? Param2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Pair() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        public Pair(T1? param1, T2? param2)
        {
            Param1 = param1;
            Param2 = param2;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Swap()
        {
            T2? parse_param1 = default;
            T1? parse_param2 = default;

            try
            {
                parse_param1 = (T2?)Convert.ChangeType(Param1, TypeCode.Object);
                parse_param2 = (T1?)Convert.ChangeType(Param2, TypeCode.Object);

            }
            finally
            {
                (Param1, Param2) = (parse_param2, parse_param1);
            }
        }

        /// <summary>
        /// 
        /// </summary>
#pragma warning disable S1133
        [Obsolete("Method does the same thing as swap in case of pairs.")]
#pragma warning restore S1133
        public void Move()
        {
            Swap();
        }
    }
    #endregion
}
