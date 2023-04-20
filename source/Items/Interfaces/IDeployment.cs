using Zustandsmaschine.Items.Subjects.Sets;

namespace Zustandsmaschine.Items.Interfaces
{
    /// <summary>
    /// An interface which defines common instance of deployments
    /// </summary>
    public interface IDeployment
    {
        /// <summary>
        /// A 32-bit integer value representing an identification number for current deployment
        /// </summary>
        public int? ID { get; }
        /// <summary>
        /// A 32-bit integer value representing an identification hash of last interaction either append
        /// </summary>
        public int? Codes { get; }
        /// <summary>
        /// A 32-bit integer value representing an validation code and flag for stability check of deployment
        /// </summary>
        public int? Scope { get; }

        /// <summary>
        /// Dynamic dictionary of pairs of codes-strings by position representing an interactions history within deployment
        /// </summary>
        public Dictionary<int, Pair<string, int>> Interactions { get; set; }

        /// <summary>
        /// String value representing name of current deployment
        /// </summary>
        public string? Name { get; }

        /// <summary>
        /// Method clearing dynamic array of strings representing interactions history without updating scope and codes
        /// </summary>
        public void Clear();

        /// <summary>
        /// Method deleting first interaction from instance of deployment without reupdating it
        /// </summary>
        public void FirstDELETE();
        /// <summary>
        /// Method deleting front either last interaction from instance of deployment without reupdating it
        /// </summary>
        public void FrontDELETE();
    }
}
