using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zustand.Machine.Addons
{
    public class Deployment
    {
        public Deployment() { }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Deployment<T> : Deployment where T : notnull
    {
        /// <summary>
        /// 
        /// </summary>
        public T? Container { get; set; } = default;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        public Deployment(T? container) : base()
        { this.Container = container; }

        /// <summary>
        /// 
        /// </summary>
        public void Renullify()
                => Container = default;
    }
}
