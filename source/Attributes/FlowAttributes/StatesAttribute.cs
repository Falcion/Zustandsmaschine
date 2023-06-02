using System.Security.Cryptography;
using System.Text;

namespace Zustand.Attributes.FlowAttributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class StatesAttribute : Attribute, IFlowAttributes
    {
        private readonly string _name;
        private readonly byte[] _data;

        public StatesAttribute(string name)
        {
            _name = name;

            _data = SHA256.HashData(Encoding.UTF8.GetBytes(name));
        }

        public StatesAttribute(string name, bool stable)
        {
            _name = name;

            Stable = stable;

            var temp_data = SHA256.HashData(BitConverter.GetBytes(stable));

            _data = SHA256.HashData(Encoding.UTF8.GetBytes(name)).Concat(temp_data).ToArray();
        }

        public StatesAttribute(string name, bool stable, int weight)
        {
            _name = name;

            Stable = stable;
            Weight = weight;

            var temp_data = SHA256.HashData(BitConverter.GetBytes(weight)
                .Concat(BitConverter.GetBytes(stable)).ToArray());

            _data = SHA256.HashData(Encoding.UTF8.GetBytes(name)).Concat(temp_data).ToArray();
        }

        public string Name => _name;
        public byte[] Data => _data;

        public bool Stable { get; set; } = false;

        public int Weight { get; set; } = 0;

        public bool Unphase()
        {
            return (Stable || (_data != null && _data == SHA256.HashData(Encoding.UTF8.GetBytes(_name))));
        }

        public void Unchaos()
        {
            int curr_degree = Math.Abs(Weight * IFlowAttributes.DEGREE_OF_CHAOS);

            if (curr_degree >= int.MaxValue)
                curr_degree = int.MaxValue - IFlowAttributes.DEGREE_OF_CHAOS;

            Random rd = new();

            int ft_weight = rd.Next(-curr_degree, curr_degree);

            Weight = ft_weight;

            if (ft_weight >= 0)
                Stable = true;
            else
                Stable = false;
        }

        public void Diffuse()
        {
            Stable = !Stable;
        }
    }
}