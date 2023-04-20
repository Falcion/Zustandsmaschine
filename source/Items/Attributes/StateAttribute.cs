using System.Security;
using System.Security.Cryptography;
using System.Text;

using Zustandsmaschine.Items.Interfaces;

namespace Zustandsmaschine.Items.Attributes
{
    /// <summary>
    /// An attribute defining parameters for assigned enum-state
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum
                    | AttributeTargets.Class 
                    | AttributeTargets.Field)]
    public class StateAttribute : Attribute, IFlowAttribute
    {
        /// <summary>
        /// String value displaying current name for assigned state
        /// </summary>
        private readonly string name;
        /// <summary>
        /// Array of byte data in SHA256's format displaying direction of instablity for instance of state
        /// </summary>
        private readonly byte[] data;

        /// <summary>
        /// Boolean parameter displaying is this attribute assigned to stable neither non-stable state
        /// </summary>
        private bool stable;

        /// <summary>
        /// Constructor of instance for attribute
        /// </summary>
        /// <param name="name">
        /// String value displaying current name for assigned state for current instance
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when instance constructor got empty or NULL string parameter for name of instance
        /// </exception>
        public StateAttribute(string name)
        {
            if(name == null || name == string.Empty)
                throw new ArgumentNullException(nameof(name), "Can't accept empty or NULL instance of string for state's attribute.");

            this.name = name;

            this.data = SHA256.HashData(Encoding.UTF8.GetBytes(name));
        }

        /// <summary>
        /// Constructor of instance for attribute
        /// </summary>
        /// <param name="name">
        /// String value displaying current name for assigned state for current instance
        /// </param>
        /// <param name="stable">
        /// Boolean parameter displaying is this attribute assigned to stable neither non-stable state for current instance
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when instance constructor got empty or NULL string parameter for name of instance
        /// </exception>
        public StateAttribute(string name, bool stable) : this(name)
        {
            this.stable = stable;
        }

        /// <summary>
        /// String value displaying current name for assigned state
        /// </summary>
        public virtual string Name { get { return name; } }
        /// <summary>
        /// Array of byte data in SHA256's format displaying direction of instablity for instance of state
        /// </summary>
        public virtual byte[] Data { get { return data; } }

        /// <summary>
        /// Boolean parameter displaying is this attribute assigned to stable neither non-stable state
        /// </summary>
        public virtual bool Stable { get { return stable; } }

        /// <summary>
        /// String value displaying current name for assigned state from interface
        /// </summary>
        string IFlowAttribute.Name { get { return this.name; } }

        /// <summary>
        /// Array of byte data in SHA256's format displaying direction of instablity for instance of state from interface
        /// </summary>
        byte[] IFlowAttribute.Data { get { return this.data; } }

        /// <summary>
        /// Boolean parameter displaying is this attribute assigned to stable neither non-stable state from interface
        /// </summary>
        bool IFlowAttribute.Stable { get { return this.stable; } }

        /// <summary>
        /// Method reversing instance's stable value and reupdating it
        /// </summary>
        public virtual void Diffuse()
        {
            this.stable = (!stable);
        }

        /// <summary>
        /// Function rechecking code and current instance common stability of state attribute
        /// </summary>
        /// <returns>
        /// Boolean parameter displaying staging of and instance's stable value
        /// </returns>
        public virtual bool Unphase()
        {
            return (this.stable || (this.data != null || this.data == SHA256.HashData(Encoding.UTF8.GetBytes(name))));
        }
    }
}
