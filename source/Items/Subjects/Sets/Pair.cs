using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zustandsmaschine.Items.Subjects.Sets
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="I"></typeparam>
    /// <typeparam name="J"></typeparam>
    public class Pair<I, J>
    {
        /// <summary>
        /// 
        /// </summary>
        public I? P1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public J? P2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Pair() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="P1"></param>
        /// <param name="P2"></param>
        public Pair(I P1, J P2)
        {
            this.P1 = P1;
            this.P2 = P2;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Pair<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public T? P1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public T? P2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Pair() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="P1"></param>
        /// <param name="P2"></param>
        public Pair(T P1, T P2)
        {
            this.P1 = P1;
            this.P2 = P2;
        }
    }
}
