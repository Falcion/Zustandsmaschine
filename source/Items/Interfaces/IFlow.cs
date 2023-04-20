using Zustandsmaschine.Enums;

namespace Zustandsmaschine.Items.Interfaces
{
    /// <summary>
    /// An interface which defines common instance for stateflows
    /// </summary>
    public interface IFlow
    {
        /// <summary>
        /// Enum classified value representing state of current flow
        /// </summary>
        public States? State { get; }
        /// <summary>
        /// Enum classified value representing shift of current flow
        /// </summary>
        public Shifts? Shift { get; }

        /// <summary>
        /// A 32-bit integer value representing integer hash of given instance and degree of current unsync and instability of the flow
        /// </summary>
        public int? Code { get; }

        /// <summary>
        /// Method clearing current params of instance
        /// </summary>
        public void Flush();
    }
}
