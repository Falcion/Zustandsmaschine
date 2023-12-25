using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zustand.Machine.Addons
{
    /// <summary>
    /// 
    /// </summary>
    public class Broker
    {
        /// <summary>
        /// 
        /// </summary>
        public Broker() { }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Broker<T> : Broker where T : notnull
    {
        /// <summary>
        /// 
        /// </summary>
        public T? Container { get; set; } = default;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        public Broker(T? container) : base()
        { this.Container = container; }

        /// <summary>
        /// 
        /// </summary>
        public void Renullify()
                => Container = default;
    }
}
