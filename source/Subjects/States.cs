using Zustand.Attributes.FlowAttributes;

namespace Zustand.Subjects
{
    public record States(string Name, int Weight, bool Stable)
    {
        [States("Unknown", true, 0)]
        public static States UNKNOWN { get; } = new States("Unknown", 0, true);
        [States("Skipped", true, 1)]
        public static States SKIPPED { get; } = new States("Skipped", 1, true);
        [States("Pending", true, 2)]
        public static States PENDING { get; } = new States("Pending", 2, true);
        [States("Failed", true, 3)]
        public static States FAILED { get; } = new States("Failed", 3, false);
        [States("Staged", true, 4)]
        public static States STAGED { get; } = new States("Staged", 4, false);
        [States("Iterating", false, 5)]
        public static States ITERATING { get; } = new States("Iterating", 5, false);
        [States("Processing", true, 6)]
        public static States PROCESSING { get; } = new States("Processing", 6, true);
        [States("Successful", true, 7)]
        public static States SUCCESSFUL { get; } = new States("Successful", 7, true);
        [States("Interrupted", true, 8)]
        public static States INTERRUPTED { get; } = new States("Interrupted", 8, false);

        public States() : this(UNKNOWN.Name,
                               UNKNOWN.Weight,
                               UNKNOWN.Stable)
        { }

        public States(string name) : this(name,
                                          GetWeight(name),
                                          GetStable(name))
        { }

        public static int GetWeight(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(string.Format("{0}: {1}", nameof(name), name),
                                                              "Can't find ant record data related to given string name.");

            string unf_name = name.ToUpper();

            return unf_name switch
            {
                "UNKNOWN" => UNKNOWN.Weight,
                "SKIPPED" => SKIPPED.Weight,
                "PENDING" => PENDING.Weight,
                "FAILED" => FAILED.Weight,
                "STAGED" => STAGED.Weight,
                "ITERATING" => ITERATING.Weight,
                "PROCESSING" => PROCESSING.Weight,
                "SUCCESSFUL" => SUCCESSFUL.Weight,
                "INTERRUPTED" => INTERRUPTED.Weight,
                _ => throw new ArgumentException("Can't get stable value of shift record with given string name.",
                                                  string.Format("{0}: {1}", nameof(name), name)),
            };
        }

        public static bool GetStable(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(string.Format("{0}: {1}", nameof(name), name),
                                                              "Can't find ant record data related to given string name.");

            string unf_name = name.ToUpper();

            return unf_name switch
            {
                "UNKNOWN" => UNKNOWN.Stable,
                "SKIPPED" => SKIPPED.Stable,
                "PENDING" => PENDING.Stable,
                "FAILED" => FAILED.Stable,
                "STAGED" => STAGED.Stable,
                "ITERATING" => ITERATING.Stable,
                "PROCESSING" => PROCESSING.Stable,
                "SUCCESSFUL" => SUCCESSFUL.Stable,
                "INTERRUPTED" => INTERRUPTED.Stable,
                _ => throw new ArgumentException("Can't get stable value of shift record with given string name.",
                                                  string.Format("{0}: {1}", nameof(name), name)),
            };
        }
    }
}
