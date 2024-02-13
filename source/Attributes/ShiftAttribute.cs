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
    [AttributeUsage(AttributeTargets.Property |
                    AttributeTargets.Class |
                    AttributeTargets.Field |
                    AttributeTargets.Struct, AllowMultiple = true)]
    public sealed class ShiftAttribute : Attribute, ISubflowAttribute
    {
        /// <summary>
        /// An array of byte data which represents the inner data which attribute holds
        /// </summary>
        private byte[]? _data;

        /// <summary>
        /// <inheritdoc cref="_data"/>
        /// </summary>
        public byte[]? Data => _data;

        private string _name = string.Empty;

        private uint _weight = default;
        private bool _stable = default;

        /// <summary>
        /// A signed 32-bit integer value representing the logical sign of an attribute
        /// </summary>
        public int Sign { get; } = unchecked((int)0x80000000);

        private ShiftAttribute() { }

        public ShiftAttribute(string name)
        {
            _name = name;

            _data = Compute(name);

            Attr = this;
        }

        public ShiftAttribute(string name,
                              uint weight,
                              bool stable) : this(name)
        {
            _weight = weight;
            _stable = stable;
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

            _name = attr.Name;

            _weight = attr.Weight;
            _stable = attr.Stable;
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

            _name = attribute.Name;

            _weight = attribute.Weight;
            _stable = attribute.Stable;
        }

        /// <summary>
        /// Private static method for computing MD5 hash for current instance
        /// </summary>
        /// <param name="input">
        /// A string value which would be parsed into the array of byte data
        /// </param>
        /// <returns>
        /// An array of byte data which represents the inner data which attribute holds
        /// </returns>
        private static byte[] Compute(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentNullException(nameof(input), "Can't compute hash from empty or null string.");

#pragma warning disable IDE0063
            using (MD5 _MD5 = MD5.Create())
            {
                _MD5.Initialize();

                byte[] hash = _MD5.ComputeHash(Encoding.UTF8.GetBytes(input));

                _MD5.Clear();

                return hash;
            }
#pragma warning restore IDE0063
        }


        /// <summary>
        /// An inner instance of interface for subflow attribute as common instance
        /// </summary>
        public ISubflowAttribute? Attr { get; private set; }

        public string Name => _name;

        public uint Weight => _weight;
        public bool Stable => _stable;

        public static class Extensions
        {
            private static readonly Type TYPEOF = typeof(ShiftAttribute);

            public static ShiftAttribute GetAttribute(Type type)
            {
                ShiftAttribute? attribute = (ShiftAttribute?) Attribute.GetCustomAttribute(type, TYPEOF);

                if (attribute == null)
#pragma warning disable S3928
                    throw new ArgumentNullException(nameof(attribute), "Can't parse required attribute from given instance of value.");
#pragma warning restore S3928 

                return attribute;
            }

            public static ShiftAttribute GetAttribute<T>(T data)
            {
                if (data == null)
                    throw new ArgumentNullException(nameof(data), "Can't parse required attribute from null instance.");
                
                var type = data.GetType();

                return GetAttribute(type);
            }

            public static byte[]? GetData(Type type) => GetAttribute(type).Data;

            public static byte[]? GetData<T>(T data) => GetAttribute(data).Data;

            public static int? GetSign(Type type) => GetAttribute(type).Sign;

            public static int? GetSign<T>(T data) => GetAttribute(data).Sign;

            public static string? GetName(Type type) => GetAttribute(type).Name;

            public static string? GetName<T>(T data) => GetAttribute(data).Name;

            public static uint? GetWeight(Type type) => GetAttribute(type).Weight;

            public static uint? GetWeight<T>(T data) => GetAttribute(data).Weight;

            public static bool? GetStable(Type type) => GetAttribute(type).Stable;

            public static bool? GetStable<T>(T data) => GetAttribute(data).Stable;
        }
    }
}
