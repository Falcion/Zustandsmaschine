namespace Zustand.Attributes.FlowAttributes
{
    public interface IFlowAttributes
    {
        public const int DEGREE_OF_CHAOS = 1000000;

        public string Name { get; }
        public byte[] Data { get; }
        public bool Stable { get; set; }

        public int Weight { get; set; }

        public bool Unphase();
        public void Unchaos();

        public void Diffuse();
    }
}