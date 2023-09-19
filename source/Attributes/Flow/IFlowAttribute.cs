using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Zustand.Attributes.Flow
{
    /// <summary>
    /// 
    /// </summary>
    public interface IFlowAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        public const double CHAOS_DEGREE = 1E11;

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// 
        /// </summary>
        public byte[] Data { get; }

        /// <summary>
        /// 
        /// </summary>
        public int Weight { get; }
        /// <summary>
        /// 
        /// </summary>
        public bool Stable { get; }

        /// <summary>
        /// 
        /// </summary>
        public void Destable();
        /// <summary>
        /// 
        /// </summary>
        public void Escalate();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte[] GetSHA256()
        {
            var data = Encoding.UTF8.GetBytes(Name);

            return SHA256.HashData(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public byte[] GetSHA256(string name)
        {
            var data = Encoding.UTF8.GetBytes(name);

            return SHA256.HashData(data);
        }
    }
}
