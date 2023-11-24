using System.Security.Cryptography;
using System.Security;
using System.Text;
using System;

namespace Zustand.Attributes
{
    using Zustand.Attributes.Interfaces;

    [AttributeUsage(AttributeTargets.Class |
                    AttributeTargets.Struct, AllowMultiple = true)]
    public class StateAttribute : Attribute, ISubflowAttribute
    {
        private byte[]? _data;

        public byte[]? Data => _data;

        public dynamic[]? Marker { get; set; }

        public int Sign { get; } = 0x7fffffff;

        public StateAttribute(dynamic[]? marker)
        {
            Marker = marker;

            var t = Marker?.ToString();

            _data = Compute(t);
        }

        public StateAttribute(ISubflowAttribute attr)
        {
            _attr = attr;
            _data = attr.Data;

            Marker = attr.Marker;
        }

        public void Rematch(ShiftAttribute attribute)
        {
            _attr = attribute;
            _data = attribute.Data;

            Marker = attribute.Marker;
        }

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

        public ISubflowAttribute? _attr { get; private set; }
    }
}
