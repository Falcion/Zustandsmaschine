namespace Zustand.Attributes.Interfaces
{
    public interface ISubflowAttribute
    {
        public byte[]? Data { get; }

        public dynamic[]? Marker { get; set; }
    }
}
