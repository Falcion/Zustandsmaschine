using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zustand.Attributes.Flow
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class FlowAttribute : Attribute, IFlowAttribute
    {
        private readonly IFlowAttribute _instance;

        /// <summary>
        /// 
        /// </summary>
        private readonly string _name;
        /// <summary>
        /// 
        /// </summary>
        private readonly byte[] _data;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public FlowAttribute(string name)
        {
            _name = name;

            _instance = this;

            _data = _instance.GetSHA256(name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="weight"></param>
        public FlowAttribute(string name, int weight) : this(name)
        {
            Weight = weight;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="weight"></param>
        /// <param name="stable"></param>
        public FlowAttribute(string name, int weight, bool stable) : this(name, weight)
        {
            Stable = stable;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name => _name;

        /// <summary>
        /// 
        /// </summary>
        public byte[] Data => _data;

        /// <summary>
        /// 
        /// </summary>
        public int Weight { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        public bool Stable { get; set; } = false;

        /// <summary>
        /// 
        /// </summary>
        public void Destable()
        {
            Stable = !Stable;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Escalate()
        {
            var weight_degree = Weight * IFlowAttribute.CHAOS_DEGREE;

            double rand_phase = new Random().NextDouble() * weight_degree;

            byte[] buffer = new byte[32];

            new Random().NextBytes(buffer);

            if (buffer.Count(x => x == 0) >= buffer.Count(x => x == 1))
                rand_phase *= -1;

            Weight = Convert.ToInt32(Math.Ceiling(rand_phase / int.MaxValue));
        }

        /// <summary>
        /// 
        /// </summary>
        public IFlowAttribute Instance => _instance;
    }
}
