namespace Zustand.Machine.Addons
{
    using System;

    using Zustand.Data.Arrays;
    using Zustand.Data.Types;
    using Zustand.Data.Types.Interfaces;
    using Zustand.Machine.Addons.Traits;

    /// <summary>
    /// A class which represents an instance of messaging broker for assemblies of state machine
    /// </summary>
    public class Broker
    {
        public Approaches Last { get; set; } = Approaches.UNDEFINED;
        public Approaches Next { get; set; } = Approaches.UNDEFINED;
        public Approaches Current { get; set; } = Approaches.DEFAULT;

        private readonly string _name = string.Empty;

        private readonly ulong _id = 0;

        private Int64 _codes = -1;
        private Int64 _scope = +1;

        private readonly Jenga<Triad<Pair<Int64>, string, Phases>> _interactions = new();

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

            Signature(Phases.STATIC);
        }

        /// <summary>
        /// An inner class which represents localized for current instance version of analytics machine via instance of <see cref="Sender"/>
        /// </summary>
        private static sealed class Interim 
        {
            public static void Differ(Broker instance)
            {
                /* */
            }

            public static void Indiffer(Broker instance)
            {
                /* */
            }

            public static Phases Phasing(long p_codes, 
                                         long p_scope, long codes, 
                                                       long scope)
            {
                if(p_codes > codes)
                {
                    if(p_scope > scope)
                        return Phases.UPPER;
                    else if(p_scope == scope)
                        return Phases.UP;
                    else
                        return Phases.STATIC;
                }
                else if(p_codes == codes)
                {
                    if (p_scope > scope)
                        return Phases.UP;
                    else if (p_scope == scope)
                        return Phases.STATIC;
                    else
                        return Phases.LOW;
                }
                else
                {
                    if (p_scope > scope)
                        return Phases.STATIC;
                    else if (p_scope == scope)
                        return Phases.LOW;
                    else
                        return Phases.LOWER;
                }
            }
        }

        public void Signature(Phases phase = Phases.BLUR)
        {
            var message = $"[SIGN]: Causing signature differ; changing phases: {Phase}->{phase}; ID: {_interactions.Count - 1};";

            Push(_scope,
                 _codes, message, phase);
            
            /* 
             * We are changing current phase, because we are inserting an interaction into the instance.
             * Since, this is a system interaction, it doesn't trigger inner sender, but broker needs to mark this interaction as unique,
             * and because this system interaction is by it nature unknown, we're using phase BLUR which defines inner irruption of this.
             * 
             * More about it:
             * https://github.com/Falcion/Zustandsmaschine/wiki/
             * 
             * Next iteration would save this phase and change to another one.
             */

            _codes = -1;
            _scope = +1;

            Last = Current;

            Current = Approaches.SIGNATURED;

            Next = Current;

            Phase = phase;

            Interim.Differ(this);
        }

        public Phases Phase { get; set; } = Phases.NONE;

        public string Name => _name;

        public ulong ID => _id;

        public long Codes => _codes;
        public long Scope => _scope;

        public Jenga<Triad<Pair<Int64>, string, Phases>> Interactions => _interactions;

        public void Blur()
        {
            Signature(Phases.BLUR);
        }

        private void Push(long scope, 
                          long codes, string message, Phases phase)
        {
            _interactions.Push(new Triad<Pair<Int64>, string, Phases>(new Pair<long>(scope,
                                                                                     codes),
                                                                      message,
                                                                      phase));
        }

        public void Add(string message)
        {
            var timestamp = DateTime.Now.Millisecond;

            long p_codes = message.GetHashCode();
            long p_scope = p_codes ^ timestamp ^ this._codes;

            var p_phase = Interim.Phasing(p_codes, 
                                         p_scope, this._codes, 
                                                  this._scope);

            Phase = p_phase;
            
            this._scope = p_codes ^ timestamp ^ this._codes;
            this._codes = p_codes;

            if (_scope == -1)
                _scope += _interactions.Count + 1;

            Push(_scope,
                 _codes, message, Phase);

            Last = Current;
            Current = Next;

            Next = Approaches.UNDEFINED;

            Interim.Indiffer(this);
        }

        public void Add(string message, Int64 codes)
        {
            var timestamp = DateTime.Now.Millisecond;

            long p_scope = codes ^ timestamp ^ this._codes;

            var p_phase = Interim.Phasing(codes,
                                         p_scope, this._codes,
                                                  this._scope);
            Phase = p_phase;

            this._scope = codes ^ timestamp ^ this._codes;
            this._codes = codes;

            if (_scope == -1)
                _scope += _interactions.Count + 1;

            Push(_scope,
                 _codes, message, Phase);

            Last = Current;

            Current = Next = Approaches.DIRECT;
        }

        public void Add(string message, Int64 codes,
                                        Int64 scope)
        {
            var p_phase = Interim.Phasing(codes,
                                         scope, this._codes,
                                                this._scope);
            Phase = p_phase;

            this._scope = scope;
            this._codes = codes;

            Push(_scope,
                 _codes, message, Phase);

            Last = Current;

            Current = Next = Approaches.GLOBAL;
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

            if(phase > p_phase)
                Signature(Phases.UPPER);
            else if(phase == p_phase)
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
            switch(operation_type)
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
            set => _interactions[index]= value;
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
