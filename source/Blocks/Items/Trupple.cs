using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zustand.Blocks.Items
{
    #region Single generic trupple
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Trupple<T> : IBlock where T : notnull
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
        public T? Param3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Trupple() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        public Trupple(T? param1, T? param2, T? param3)
        {
            Param1 = param1; 
            Param2 = param2; 
            Param3 = param3;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="NotSupportedException"></exception>
#pragma warning disable S1133
        [Obsolete("Trupple doesn't support swapping method because of its objects count.", true)]
#pragma warning restore S1133
        public void Swap()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Move()
        {
            // 1 -> 2, 2 -> 3, 3 -> 1, SAVING: "1"
            var temp = Param1;

            Param1 = Param2;
            Param2 = Param3;
            Param3 = temp;
        }
    }
    #endregion
    #region Double generic trupple
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public class Trupple<T1, T2> : IBlock where T1 : notnull where T2 : notnull
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
        public T2? Param3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Trupple() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        public Trupple(T1? param1, T2? param2, T2? param3)
        {
            Param1 = param1;
            Param2 = param2;
            Param3 = param3;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Swap()
        {
            (Param2, Param3) = (Param3, Param2);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Move()
        {
            T2? parse_param1 = default;
            T1? parse_param3 = default;

            try
            {
                parse_param1 = (T2?)Convert.ChangeType(Param1, TypeCode.Object);
                parse_param3 = (T1?)Convert.ChangeType(Param2, TypeCode.Object);
            }
            finally
            {
                (Param1, Param2, Param3) = (parse_param3, parse_param1, Param2);
            }
        }
    }
    #endregion
    #region Tripple generic trupple
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    public class Trupple<T1, T2, T3> : IBlock where T1 : notnull where T2 : notnull where T3 : notnull
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
        public T3? Param3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Trupple() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        public Trupple(T1? param1, T2? param2, T3? param3)
        {
            Param1 = param1;
            Param2 = param2;
            Param3 = param3;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="NotSupportedException"></exception>
#pragma warning disable S1133
        [Obsolete("Trupple doesn't support swapping method because of its objects count.", true)]
#pragma warning restore S1133
        public void Swap()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Move()
        {
            T2? parse_param1 = default;
            T3? parse_param2 = default;
            T1? parse_param3 = default;

            try
            {
                parse_param1 = (T2?)Convert.ChangeType(Param1, TypeCode.Object);
                parse_param2 = (T3?)Convert.ChangeType(Param2, TypeCode.Object);
                parse_param3 = (T1?)Convert.ChangeType(Param2, TypeCode.Object);
            }
            finally
            {
                (Param1, Param2, Param3) = (parse_param3, parse_param1, parse_param2);
            }
        }
    }
    #endregion
}
