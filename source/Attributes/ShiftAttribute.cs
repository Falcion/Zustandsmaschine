using System;
using System.Text;

using System.Security;
using System.Security.Cryptography;


namespace Zustand.Attributes
{
    using Zustand.Attributes.Interfaces;

    /// <summary>
    /// A class which represents an attribute for shift of a stateflow
    /// </summary>
    [AttributeUsage(AttributeTargets.Class |
                    AttributeTargets.Struct, AllowMultiple = true)]
    public sealed class ShiftAttribute : Attribute, ISubflowAttribute
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
        /// An <see cref="Object"/> type object which represents the object marker for current instance of attribute
        /// </summary>
        public object[]? Marker { get; set; }

        /// <summary>
        /// A signed 32-bit integer value representing the logical sign of an attribute
        /// </summary>
        public int Sign { get; } = unchecked((int)0x80000000);

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="marker">
        /// A dynamic type object which represents the object marker for current instance of attribute
        /// </param>
        public ShiftAttribute(object[]? marker)
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
        public ShiftAttribute(ISubflowAttribute attr)
        {
            Attr = attr;
            _data = attr.Data;

            Marker = attr.Marker;
        }

        /// <summary>
        /// Method which updates the current instance from given instance of another one
        /// </summary>
        /// <param name="attribute">
        /// An instance of <see cref="ShiftAttribute"/> from which current instance would be updated
        /// </param>
        public void Rematch(ShiftAttribute attribute)
        {
            Attr = attribute;
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

#pragma warning disable IDE0063
            using (MD5 _MD5 = MD5.Create())
            {
                _MD5.Initialize();

                byte[] hash =  _MD5.ComputeHash(Encoding.UTF8.GetBytes(data));

                _MD5.Clear();

                return hash;
            }
#pragma warning restore IDE0063
        }

        /// <summary>
        /// An inner instance of interface for subflow attribute as common instance
        /// </summary>
        public ISubflowAttribute? Attr { get; private set; }
    }
}
