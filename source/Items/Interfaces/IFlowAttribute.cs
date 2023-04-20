namespace Zustandsmaschine.Items.Interfaces
{
    /// <summary>
    /// An interface which defines common instance for flow's attributes
    /// </summary>
    public interface IFlowAttribute
    {
        /// <summary>
        /// String value displaying current name for assigned flow
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Array of byte data in specified format displaying direction of instablity for instance of flow
        /// </summary>
        public byte[] Data { get; }

        /// <summary>
        /// Boolean parameter displaying is this attribute assigned to stable neither non-stable flow
        /// </summary>
        public bool Stable { get; }

        /// <summary>
        /// Method working with stable param of current flow's instance
        /// </summary>
        public void Diffuse();

        /// <summary>
        /// Function rechecking code and current instance common stability
        /// </summary>
        public bool Unphase();
    }
}
