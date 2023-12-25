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
        /// A dynamic type object which represents the object marker for current instance of attribute
        /// </summary>
        public dynamic[]? Marker { get; set; }
    }
}
