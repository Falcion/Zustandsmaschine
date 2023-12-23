using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zustand.Data.Types.Interfaces;

namespace Zustand.Data.Types
{
    public class Tupple<T> : IData
    {
        public T? Param1 { get; set; } = default(T?);
        public T? Param2 { get; set; } = default(T?);

        public Tupple(T? param1, T? param2)
        {
            Param1 = param1;
            Param2 = param2;
        }

        public void Swap()
        {
            (Param1, Param2) = (Param2, Param1);
        }

        public void Move()
        {
            Swap();
        }

        public void Nullify()
        {
            Param1 = default(T?);
            Param2 = default(T?);
        }
    }

    public class Tupple<K, V> : IData
    {
        public K? Param1 { get; set; } = default(K?);
        public V? Param2 { get; set; } = default(V?);

        public Tupple(K? param1, V? param2)
        {
            Param1 = param1;
            Param2 = param2;
        }

        public void Swap()
        {
            var convert_param1 = (V?)Convert.ChangeType(Param1, typeof(V));
            var convert_param2 = (K?)Convert.ChangeType(Param2, typeof(K));

            Param1 = convert_param2;
            Param2 = convert_param1;
        }

        public void Move()
        {
            Swap();
        }

        public void Nullify()
        {
            Param1 = default(K?);
            Param2 = default(V?);
        }
    }
}
