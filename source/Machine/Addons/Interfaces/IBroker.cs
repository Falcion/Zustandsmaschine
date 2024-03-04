using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Zustand.Data.Arrays;
using Zustand.Data.Types;
using Zustand.Machine.Addons.Traits;
using static System.Formats.Asn1.AsnWriter;

namespace Zustand.Machine.Addons.Interfaces
{
    public interface IBroker
    {
        public Type Instance { get; }

        public string Name { get; }

        public ulong ID { get; }

        public long Codes { get; }
        public long Scope { get; }

        public void Signature();

        public void Blur();
        public void Add(string message);
        public void Add(string message, long codes);
        public void Add(string message, long codes, long scope);

        public void Nullify();

        public void Exit(Operations operation_type);
    }
}
