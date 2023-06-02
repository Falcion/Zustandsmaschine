using System.Security.Cryptography;
using System.Text;
using Zustand.Sets;

namespace Zustand
{
    [Serializable]
    public class Deployment
    {
        private readonly string _name;
        private long _id;

        private long _codes = 0;
        private long _scope = 0;

        readonly Dictionary<int, Pair<long, string>> _interactions = new();

        public Deployment()
        {
            _name = GenerateRandomString();

            UpdateID();
        }

        public Deployment(string name)
        {
            _name = name;

            UpdateID();
        }

        public Deployment(string name, long id)
        {
            _name = name;
            _id = id;
        }

        public Deployment(string name, long id, long codes, long scope)
        {
            _name = name;
            _id = id;

            _codes = codes;
            _scope = scope;

            AddMessage($"[INIT] Initialized the deployment with custom scope and codes.");
        }

        public void DeleteLast()
        {
            _interactions.Remove(_interactions.Last().Key);
        }

        public void DeleteFirst()
        {
            _interactions.Remove(_interactions.First().Key);
        }

        public void AddMessage(string message)
        {
            var now = DateTime.UtcNow;

            var timestamp = (long)(now - new DateTime(1970, 1, 1)).TotalMilliseconds * 1000;

            var temp_codes = message.GetHashCode();

            _scope = _codes ^ timestamp ^ temp_codes;

            if (_scope == -1)
                _scope += _interactions.Count;

            _codes = temp_codes;

            _interactions.Add(_interactions.Count, new Pair<long, string>(_codes, message));

            Analyze();
        }

        public void AddMessage(string message, long codes)
        {
            var now = DateTime.UtcNow;

            var timestamp = (long)(now - new DateTime(1970, 1, 1)).TotalMilliseconds * 1000;

            _scope = _codes ^ timestamp ^ codes;

            if (_scope == -1)
                _scope += _interactions.Count;

            _codes = codes;

            _interactions.Add(_interactions.Count, new Pair<long, string>(_codes, message));
            _interactions.Add(_interactions.Count + 1,
                new Pair<long, string>(_codes, $"Event had been called with custom \"DIRECT APPROACH\" variable, its delegates are attached: {_scope}"));

            Analyze();
        }

        public void AddMessage(string message, long codes, long scope)
        {
            _codes = codes;
            _scope = scope;

            _interactions.Add(_interactions.Count, new Pair<long, string>(_codes, message));
            _interactions.Add(_interactions.Count + 1,
                new Pair<long, string>(_codes, $"Event had been called with custom \"DIRECT-DIRECT APPROACH\" variable, its delegates are attached: {_scope}"));

            Analyze();
        }

        public void ClearInteractions()
        {
            _interactions.Clear();

            AddMessage("[SYS] Deployment had been cleared!", -1, 0);
        }

        public void Analyze()
        {
            if (_codes == -1)
                AddMessage("[SYS] Deployment has caught instability value!");

            if (_scope == -1)
                AddMessage($"Total checksum SCOPE of deployment caught in total instability and exception situtation! Misbehave concluded in {_codes}::{_interactions.Count}");
        }

        private void UpdateID()
        {
            _id = MD5.HashData(Encoding.UTF8.GetBytes(_name)).GetLongLength(0);
        }

        private static string GenerateRandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            Random random = new();

            int size = random.Next(1, 65); // Generate a random size between 1 and 64

            StringBuilder sb = new(size);
            for (int i = 0; i < size; i++)
            {
                sb.Append(chars[random.Next(chars.Length)]);
            }

            return sb.ToString();
        }

        public string Name => _name;
        public long Id => _id;

        public long Codes => _codes;
        public long Scope => _scope;

        public Dictionary<int, Pair<long, string>> Interactions => _interactions;

    }
}
