using Zustand.Attributes.Flow;

namespace Zustand.Flow.Subjects
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="Weight"></param>
    /// <param name="Stable"></param>
    public record States(string Name, int Weight, bool Stable)
    {
        #region Singletons
        /// <summary>
        /// 
        /// </summary>
        ///
        [Flow("Init", -1, true)]
        public static States INIT { get; } = new("Init", -1, true);
        /// <summary>
        /// 
        /// </summary>
        /// 
        [Flow("Unknown", 0, true)]
        public static States UNKNOWN { get; } = new("Unknown", 0, true);
        /// <summary>
        /// 
        /// </summary>
        /// 
        [Flow("Skipped", 1, true)]
        public static States SKIPPED { get; } = new("Skipped", 1, true);
        /// <summary>
        /// 
        /// </summary>
        /// 
        [Flow("Pending", 2, true)]
        public static States PENDING { get; } = new("Pending", 2, true);
        /// <summary>
        /// 
        /// </summary>
        /// 
        [Flow("Failed", 3, false)]
        public static States FAILED { get; } = new("Failed", 3, false);
        /// <summary>
        /// 
        /// </summary>
        /// 
        [Flow("Staged", 4, false)]
        public static States STAGED { get; } = new("Staged", 4, false);
        /// <summary>
        /// 
        /// </summary>
        /// 
        [Flow("Iterating", 5, false)]
        public static States ITERATING { get; } = new("Iterating", 5, false);
        /// <summary>
        /// 
        /// </summary>
        /// 
        [Flow("Processing", 6, true)]
        public static States PROCESSING { get; } = new("Processing", 6, true);
        /// <summary>
        /// 
        /// </summary>
        /// 
        [Flow("Successful", 7, true)]
        public static States SUCCESSFUL { get; } = new("Successful", 7, true);
        /// <summary>
        /// 
        /// </summary>
        /// 
        [Flow("Interrupted", 8, false)]
        public static States INTERRUPTED { get; } = new("Interrupted", 8, false);
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public States() : this(UNKNOWN.Name, UNKNOWN.Weight, UNKNOWN.Stable)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public States(string name) : this(name, GetWeight(name), GetStable(name))
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="weight"></param>
        public States(string name, int weight) : this(name, weight, 
                                                Convert.ToBoolean(new Random().Next(0, 1)))
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static int GetWeight(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name), "Record for state can't contain null or empty name.");

            string upperName = name.ToUpper();

            return upperName switch
            {
                "INIT" => INIT.Weight,
                "UNKNOWN" => UNKNOWN.Weight,
                "SKIPPED" => SKIPPED.Weight,
                "PENDING" => PENDING.Weight,
                "FAILED" => FAILED.Weight,
                "STAGED" => STAGED.Weight,
                "ITERATING" => ITERATING.Weight,
                "PROCESSING" => PROCESSING.Weight,
                "SUCCESSFUL" => SUCCESSFUL.Weight,
                "INTERRUPTED" => INTERRUPTED.Weight,
                _ => 0
            };
        } 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool GetStable(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name), "Record for state can't contain null or empty name.");

            string upperName = name.ToUpper();

            return upperName switch
            {
                "INIT" => INIT.Stable,
                "UNKNOWN" => UNKNOWN.Stable,
                "SKIPPED" => SKIPPED.Stable,
                "PENDING" => PENDING.Stable,
                "FAILED" => FAILED.Stable,
                "STAGED" => STAGED.Stable,
                "ITERATING" => ITERATING.Stable,
                "PROCESSING" => PROCESSING.Stable,
                "SUCCESSFUL" => SUCCESSFUL.Stable,
                "INTERRUPTED" => INTERRUPTED.Stable,
                _ => false
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if(string.IsNullOrEmpty(this.Name))
                return string.Empty;
            else
                return $"{Name.ToUpper()[0]}{Name.ToLower()[1..]}";
        }
    }
}