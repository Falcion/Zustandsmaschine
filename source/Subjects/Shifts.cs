using Zustand.Attributes.FlowAttributes;

namespace Zustand.Subjects
{
    public record Shifts(string Name, int Weight, bool Stable)
    {
        [Shifts("Begin", true, 0)]
        public static Shifts BEGIN { get; } = new Shifts("Begin", 0, true);
        [Shifts("Pause", true, 1)]
        public static Shifts PAUSE { get; } = new Shifts("Pause", 1, true);
        [Shifts("Resume", true, 2)]
        public static Shifts RESUME { get; } = new Shifts("Resume", 2, true);
        [Shifts("Exit", true, 3)]
        public static Shifts EXIT { get; } = new Shifts("Exit", 3, true);
        [Shifts("Stop", true, 4)]
        public static Shifts STOP { get; } = new Shifts("Stop", 4, true);
        [Shifts("Skip", true, 5)]
        public static Shifts SKIP { get; } = new Shifts("Skip", 5, true);
        [Shifts("Phase", false, 6)]
        public static Shifts PHASE { get; } = new Shifts("Phase", 6, false);
        [Shifts("Stage", false, 7)]
        public static Shifts STAGE { get; } = new Shifts("Stage", 7, false);
        [Shifts("Momentum", false, 8)]
        public static Shifts MOMENTUM { get; } = new Shifts("Momentum", 8, false);
        [Shifts("Rollback", false, 9)]
        public static Shifts ROLLBACK { get; } = new Shifts("Rollback", 9, false);
        [Shifts("Timeout", false, 10)]
        public static Shifts TIMEOUT { get; } = new Shifts("Timeout", 10, false);

        public Shifts() : this(BEGIN.Name,
                               BEGIN.Weight,
                               BEGIN.Stable)
        { }

        public Shifts(string name) : this(name,
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
                "BEGIN" => BEGIN.Weight,
                "PAUSE" => PAUSE.Weight,
                "RESUME" => RESUME.Weight,
                "EXIT" => EXIT.Weight,
                "STOP" => STOP.Weight,
                "SKIP" => SKIP.Weight,
                "PHASE" => PHASE.Weight,
                "STAGE" => STAGE.Weight,
                "MOMENTUM" => MOMENTUM.Weight,
                "ROLLBACK" => ROLLBACK.Weight,
                "TIMEOUT" => TIMEOUT.Weight,
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
                "BEGIN" => BEGIN.Stable,
                "PAUSE" => PAUSE.Stable,
                "RESUME" => RESUME.Stable,
                "EXIT" => EXIT.Stable,
                "STOP" => STOP.Stable,
                "SKIP" => SKIP.Stable,
                "PHASE" => PHASE.Stable,
                "STAGE" => STAGE.Stable,
                "MOMENTUM" => MOMENTUM.Stable,
                "ROLLBACK" => ROLLBACK.Stable,
                "TIMEOUT" => TIMEOUT.Stable,
                _ => throw new ArgumentException("Can't get stable value of shift record with given string name.",
                                                  string.Format("{0}: {1}", nameof(name), name)),
            };
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Weight: {1}, Stable: {2}", Name,
                                                                        Weight,
                                                                        Stable);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;

                hash *= 31 + Weight;

                return hash;
            }
        }
    }
}
