using System.Security.Cryptography;
using System.Security;
using System.Text;
using System;

namespace Zustand.Attributes
{
    using Zustand.Attributes.Interfaces;

    /// <summary>
    /// A class which represents an attribute for state of a stateflow
    /// </summary>
    [AttributeUsage(AttributeTargets.Class |
                    AttributeTargets.Struct, AllowMultiple = true)]
    public sealed class StateAttribute : Attribute, ISubflowAttribute
    {
        /// <summary>
        /// An array of byte data which represents the inner data which attribute holds
        /// </summary>
        private byte[]? _data;

        /// <summary>
        /// An array of byte data which represents the inner data which attribute holds
        /// </summary>
        public byte[]? Data => _data;

        /// <summary>
        /// A dynamic type object which represents the object marker for current instance of attribute
        /// </summary>
        public dynamic[]? Marker { get; set; }

        /// <summary>
        /// A signed 32-bit integer value representing the logical sign of an attribute
        /// </summary>
        public int Sign { get; } = 0x7fffffff;

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="marker">
        /// A dynamic type object which represents the object marker for current instance of attribute
        /// </param>
        public StateAttribute(dynamic[]? marker)
        {
            Marker = marker;

            var t = Marker?.ToString();

            _data = Compute(t);
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="attr">
        /// An inner instance of interface for subflow attribute as common instance
        /// </param>
        public StateAttribute(ISubflowAttribute attr)
        {
            _attr = attr;
            _data = attr.Data;

            Marker = attr.Marker;
        }

        /// <summary>
        /// Method which updates the current instance from given instance of another one
        /// </summary>
        /// <param name="attribute">
        /// An instance of <see cref="StateAttribute"/> from which current instance would be updated
        /// </param>
        public void Rematch(StateAttribute attribute)
        {
            _attr = attribute;
            _data = attribute.Data;

            Marker = attribute.Marker;
        }

        /// <summary>
        /// Private static method for computing MD5 hash for current instance
        /// </summary>
        /// <param name="data">
        /// A string value which would be parsed into the array of byte data
        /// </param>
        /// <returns>
        /// An array of byte data which represents the inner data which attribute holds
        /// </returns>
        private static byte[] Compute(string? data)
        {
            if (string.IsNullOrEmpty(data))
                return Array.Empty<byte>();

            using (MD5 _MD5 = MD5.Create())
            {
                _MD5.Initialize();

                byte[] hash = _MD5.ComputeHash(Encoding.UTF8.GetBytes(data));

                _MD5.Clear();

                return hash;
            }
        }

        /// <summary>
        /// An inner instance of interface for subflow attribute as common instance
        /// </summary>
        public ISubflowAttribute? _attr { get; private set; }
    }
}
