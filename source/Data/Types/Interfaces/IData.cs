namespace Zustand.Data.Types.Interfaces
{
    /// <summary>
    /// An interface which represents universal types of data for infrastructure of state machine
    /// </summary>
    public interface IData
    {
        /// <summary>
        /// Method which swaps two indefinetely paired within values inside the data type
        /// </summary>
        public void Swap();
        /// <summary>
        /// Method which replaces the value of one value with the value of the next one inside the data type
        /// </summary>
        public void Move();

        /// <summary>
        /// Method which redefines every value with their default type value inside the data type
        /// </summary>
        public void Nullify();
    }
}
