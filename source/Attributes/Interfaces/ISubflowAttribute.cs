namespace Zustand.Attributes.Interfaces
{
    /// <summary>
    /// An interface for subflow attributes
    /// </summary>
    public interface ISubflowAttribute
    {
        /// <summary>
        /// An array of byte data which represents the inner data which attribute holds
        /// </summary>
        public byte[]? Data { get; }

        /// <summary>
        /// A signed 32-bit integer value representing the logical sign of an attribute
        /// </summary>
        public int Sign { get; }

        public string Name { get; }

        public uint Weight { get; }
        public bool Stable { get; }
    }
}
