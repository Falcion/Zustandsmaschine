using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zustand.Data.Types.Interfaces;

namespace Zustand.Data.Types
{
    public class Trupple<T> : IData
    {
        public T? Param1 { get; set; } = default(T?);
        public T? Param2 { get; set; } = default(T?);
        public T? Param3 { get; set; } = default(T?);

        public Trupple(T? param1, T? param2, T? param3)
        {
            Param1 = param1;
            Param2 = param2;
            Param3 = param3;
        }

        public void Swap()
        {
            (Param1, Param3) = (Param3, Param1);
        }

        public void Move()
        {
            (Param1, Param2, Param3) = (Param2, Param3, Param1);
        }

        public void Nullify()
        {
            Param1 = default(T?);
            Param2 = default(T?);
            Param3 = default(T?);
        }
    }

    public class Trupple<K, V> : IData
    {
        public K? Param1 { get; set; } = default(K?);
        public V? Param2 { get; set; } = default(V?);
        public V? Param3 { get; set; } = default(V?);

        public Trupple(K? param1, V? param2, V? param3)
        {
            Param1 = param1;
            Param2 = param2;
            Param3 = param3;
        }

        public void Swap()
        {
            var convert_param1 = (K?)Convert.ChangeType(Param3, typeof(K));
            var convert_param3 = (V?)Convert.ChangeType(Param1, typeof(V));

            (Param1, Param3) = (convert_param1, convert_param3);
        }

        public void Move()
        {
            var convert_param1 = (K?)Convert.ChangeType(Param2, typeof(K));
            var convert_param3 = (V?)Convert.ChangeType(Param1, typeof(V));

            (Param1, Param2, Param3) = (convert_param1, Param3, convert_param3);
        }

        public void Nullify()
        {
            Param1 = default(K?);
            Param2 = default(V?);
            Param3 = default(V?);
        }
    }

    public class Trupple<K, V, U> : IData
    {
        public K? Param1 { get; set; } = default(K?);
        public V? Param2 { get; set; } = default(V?);
        public U? Param3 { get; set; } = default(U?);

        public Trupple(K? param1, V? param2, U? param3)
        {
            Param1 = param1;
            Param2 = param2;
            Param3 = param3;
        }

        public void Swap()
        {
            var convert_param1 = (K?)Convert.ChangeType(Param3, typeof(K));
            var convert_param3 = (U?)Convert.ChangeType(Param1, typeof(U));

            (Param1, Param3) = (convert_param1, convert_param3);
        }

        public void Move()
        {
            var convert_param1 = (K?)Convert.ChangeType(Param2, typeof(K));
            var convert_param2 = (V?)Convert.ChangeType(Param3, typeof(V));
            var convert_param3 = (U?)Convert.ChangeType(Param1, typeof(U));

            (Param1, Param2, Param3) = (convert_param1, convert_param2, convert_param3);
        }

        public void Nullify()
        {
            Param1 = default(K?);
            Param2 = default(V?);
            Param3 = default(U?);
        }
    }
}
