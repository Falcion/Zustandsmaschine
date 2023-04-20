using System.Security;
using System.Security.Cryptography;
using System.Text;

using Zustandsmaschine.Items.Interfaces;

namespace Zustandsmaschine.Items.Attributes
{
    /// <summary>
    /// An attribute defining parameters for assigned enum-shift
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum
                    | AttributeTargets.Class
                    | AttributeTargets.Field)]
    public class ShiftAttribute : Attribute, IFlowAttribute
    {
        /// <summary>
        /// String value displaying current name for assigned shift
        /// </summary>
        private readonly string name;
        /// <summary>
        /// Array of byte data in MD5's format displaying direction of instablity for instance of shift
        /// </summary>
        private readonly byte[] data;

        /// <summary>
        /// Boolean parameter displaying is this attribute assigned to stable neither non-stable shift
        /// </summary>
        private bool stable;

        /// <summary>
        /// Constructor of instance for attribute
        /// </summary>
        /// <param name="name">
        /// String value displaying current name for assigned shift for current instance
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when instance constructor got empty or NULL string parameter for name of instance
        /// </exception>
        public ShiftAttribute(string name)
        {
            if (name == null || name == string.Empty)
                throw new ArgumentNullException(nameof(name), "Can't accept empty or NULL instance of string for shift's attribute.");

            this.name = name;

            this.data = MD5.HashData(Encoding.UTF8.GetBytes(name + "SUBshift CUT"));
        }

        /// <summary>
        /// Constructor of instance for attribute
        /// </summary>
        /// <param name="name">
        /// String value displaying current name for assigned shift for current instance
        /// </param>
        /// <param name="stable">
        /// Boolean parameter displaying is this attribute assigned to stable neither non-stable shift for current instance
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when instance constructor got empty or NULL string parameter for name of instance
        /// </exception>
        public ShiftAttribute(string name, bool stable) : this(name)
        {
            this.stable = stable;
        }

        /// <summary>
        /// String value displaying current name for assigned shift
        /// </summary>
        public virtual string Name { get { return name; } }
        /// <summary>
        /// Array of byte data in MD5's format displaying direction of instablity for instance of shift
        /// </summary>
        public virtual byte[] Data { get { return data; } }

        /// <summary>
        /// Boolean parameter displaying is this attribute assigned to stable neither non-stable shift
        /// </summary>
        public virtual bool Stable { get { return stable; } }

        /// <summary>
        /// Method randomizing instance's stable value and reupdating it
        /// </summary>
        public virtual void Diffuse()
        {
            var random = new Random().Next(-1, 1);

            if (random >= 0)
                this.stable = true;
            else
                this.stable = false;
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
