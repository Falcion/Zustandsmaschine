namespace Zustand.Machine.Addons
{
    using Zustand.Data;
    using Zustand.Data.Types;
    using Zustand.Data.Arrays;

    public class Broker
    {
        private string _name { get; } = string.Empty;

        private Int64 _id { get; } = 0;

        private Int64 _codes=0;
        private Int64 _scope=0;

        private Jenga<string> _activity { get; } = new();

        private bool is_disposed = false;

        public Broker() { }

        public Broker(string name)
        {
            _name = name;
        }

        public Broker(string name, long id)
        {
            _name = name;

            _id = id;
        }

        public Broker(string name, long id, long codes,
                                            long scope) : this(name, id)
        {
            _codes = codes;
            _scope = scope;

            /*! TO-DO: write here an advertisment about using DIRECT-DIRECT APPROACH */
        }

        private void Reconfigure(Pair<Int64> codepair)
        {
            _codes = codepair.Param1;
            _scope = codepair.Param2;
        }

        private void Reconfigure(Pair<Int64> codepair, bool is_disposed)
        {
            Reconfigure(codepair);

            this.is_disposed = is_disposed;
        }

        public string Name => _name;

        public Int64 ID => _id;

        public Int64 Codes => _codes;
        public Int64 Scope => _scope;

        public Jenga<string> Activity => _activity;

        public bool Disposed => is_disposed;
    }

    public class Broker<T> : Broker where T : notnull
    {

        public T? Container { get; set; }

        public Broker(T? container) : base()
           { Container = container; }

        public void Renullify()
                => Container = default;
    }
}
