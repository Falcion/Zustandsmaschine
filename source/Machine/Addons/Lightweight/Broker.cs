using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zustand.Data.Arrays;
using Zustand.Data.Types;
using Zustand.Machine.Addons.Interfaces;
using Zustand.Machine.Addons.Traits;

namespace Zustand.Machine.Addons.Lightweight;
{
    public class Broker : IBroker
    {
        public Type Instance => typeof(this);

        private readonly string _name = string.Empty;

        private readonly ulong _id = 0;

        private Int64 _codes = -1;
        private Int64 _scope = +1;

        private readonly Jenga<Triad<long, long, string>> _interactions = new();

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        public Broker() { }

        public Broker(string name)
        {
            _name = name;

            _id = 0;
        }

        public Broker(string name, ulong id) : this(name)
        {
            _id = id;
        }

        public Broker(string name, ulong id, long codes,
                                             long scope) : this(name, id)
        {
            _codes = codes;
            _scope = scope;
            
        
            //TO-DO: Signature(Phases.STATIC);
        }

        /// <summary>
        /// An inner class which represents localized for current instance version of analytics machine via instance of <see cref="Sender"/>
        /// </summary>
        private static class Interim
        {
            public static void Indiffer(Broker instance)
            {

            }
        }
        public string Name => _name;

        public ulong ID => _id;

        public long Codes => _codes;
        public long Scope => _scope;

        public Jenga<Triad<long, long, string>> Interactions => _interactions;

        public void Add(string message)
        {
            var timestamp = DateTime.Now.Millisecond;

            long p_codes = message.GetHashCode();
            long p_scope = p_codes ^ timestamp ^ this._codes;

            this._scope = p_codes ^ timestamp ^ this._codes;
            this._codes = p_codes;

            if (_scope == -1)
                _scope += _interactions.Count + 1;

            _interactions.Push(new Triad<long, long, string>(_scope, _codes, message));

            Interim.Indiffer(this);
        }

        public void Add(string message, Int64 codes)
        {
            var timestamp = DateTime.Now.Millisecond;

            long p_scope = codes ^ timestamp ^ this._codes;

            this._scope = codes ^ timestamp ^ this._codes;
            this._codes = codes;

            if (_scope == -1)
                _scope += _interactions.Count + 1;

            _interactions.Push(new Triad<long, long, string>(_scope, _codes, message));

            Interim.Indiffer(this);
        }

        public void Add(string message, Int64 codes,
                                        Int64 scope)
        {
            this._scope = scope;
            this._codes = codes;

            _interactions.Push(new Triad<long, long, string>(_scope, _codes, message));

            Interim.Indiffer(this);
        }

        public void Add(string message, Int64 codes,
                                        Int64 scope,
                                        Phases phase)
        {
            var p_phase = Interim.Phasing(codes,
                                         scope, this._codes,
                                                this._scope);
            Phase = phase;

            this._scope = scope;
            this._codes = codes;

            Push(_scope,
                 _codes, message, Phase);

            Last = Current;

            Current = Next = Approaches.TEMPOR;

            Interim.Differ(this);

            if (phase > p_phase)
                Signature(Phases.UPPER);
            else if (phase == p_phase)
                Signature(Phases.STATIC);
            else
                Signature(Phases.LOWER);

            Interim.Indiffer(this);
        }

        public void Nullify()
        {
            Interactions.Clear();

            _codes = 0;
            _scope = 0;

            Interim.Differ(this);

            Signature(Phases.NONE);

            Interim.Indiffer(this);
        }

        public void Exit(Operations operation_type = Operations.FIRST)
        {
            switch (operation_type)
            {
                case Operations.FIRST:
                    Interactions.Exit(0);
                    break;
                case Operations.FRONT:
                    var front_index = Interactions.Count - 1;

                    Interactions.Exit(front_index);
                    break;
                default:
                    throw new ArgumentException("Unknown operation type can't be entered.", nameof(operation_type));
            }
        }

        public Triad<Pair<Int64>, string, Phases> this[int index]
        {
            get => _interactions[index];
            set => _interactions[index] = value;
        }
    }

    /// <summary>
    /// A generic dynamic representation of <see cref="Broker"/> which holds generic value as it's primary type
    /// </summary>
    public class Broker<T> where T : notnull
    {
        public T? Container { get; set; } = default;

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        public Broker() { }

        /// <summary>
        /// An inner class which represents localized for current instance version of analytics machine via instance of <see cref="Sender"/>
        /// </summary>
        public class Interim : Sender
        {

        }

        public Phases Phase { get; set; } = Phases.STATIC;
    }
}
