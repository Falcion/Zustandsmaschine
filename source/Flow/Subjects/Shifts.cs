using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zustand.Attributes.Flow;

namespace Zustand.Flow.Subjects
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="Weight"></param>
    /// <param name="Stable"></param>
    public record Shifts(string Name, int Weight, bool Stable)
    {
        #region Singletons
        /// <summary>
        /// 
        /// </summary>
        /// 
        [Flow("Begin", 0, true)]
        public static Shifts BEGIN { get; } = new Shifts("Begin", 0, true);
        /// <summary>
        /// 
        /// </summary>
        /// 
        [Flow("Begin", 0, true)]
        public static Shifts PAUSE { get; } = new Shifts("Pause", 1, true);
        /// <summary>
        /// 
        /// </summary>
        /// 
        [Flow("Begin", 0, true)]
        public static Shifts RESUME { get; } = new Shifts("Resume", 2, true);
        /// <summary>
        /// 
        /// </summary>
        /// 
        [Flow("Begin", 0, true)]
        public static Shifts EXIT { get; } = new Shifts("Exit", 3, true);
        /// <summary>
        /// 
        /// </summary>
        /// 
        [Flow("Begin", 0, true)]
        public static Shifts STOP { get; } = new Shifts("Stop", 4, true);
        /// <summary>
        /// 
        /// </summary>
        /// 
        [Flow("Begin", 0, true)]
        public static Shifts SKIP { get; } = new Shifts("Skip", 5, true);
        /// <summary>
        /// 
        /// </summary>
        /// 
        [Flow("Begin", 0, true)]
        public static Shifts PHASE { get; } = new Shifts("Phase", 6, false);
        /// <summary>
        /// 
        /// </summary>
        /// 
        [Flow("Begin", 0, true)]
        public static Shifts STAGE { get; } = new Shifts("Stage", 7, false);
        /// <summary>
        /// 
        /// </summary>
        /// 
        [Flow("Momentum", 8, false)]
        public static Shifts MOMENTUM { get; } = new Shifts("Momentum", 8, false);
        /// <summary>
        /// 
        /// </summary>
        /// 
        [Flow("Rollback", 9, false)]
        public static Shifts ROLLBACK { get; } = new Shifts("Rollback", 9, false);
        /// <summary>
        /// 
        /// </summary>
        /// 
        [Flow("Timeout", 10, false)]
        public static Shifts TIMEOUT { get; } = new Shifts("Timeout", 10, false);
        /// <summary>
        /// 
        /// </summary>
        /// 
        [Flow("Sleep", 11, true)]
        public static Shifts SLEEP { get; } = new Shifts("Sleep", 11, true);
        /// <summary>
        /// 
        /// </summary>
        /// 
        [Flow("Awake", 12, true)]
        public static Shifts AWAKE { get; } = new Shifts("Awake", 12, true);
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public Shifts() : this(BEGIN.Name, BEGIN.Weight, BEGIN.Stable)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public Shifts(string name) : this(name, GetWeight(name), GetStable(name))
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="weight"></param>
        public Shifts(string name, int weight) : this(name, weight,
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
                throw new ArgumentNullException(nameof(name), "Record for shift can't contain null or empty name.");

            string upperName = name.ToUpper();

            return upperName switch
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
                "SLEEP" => SLEEP.Weight,
                "AWAKE" => AWAKE.Weight,
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
                throw new ArgumentNullException(nameof(name), "Record for shift can't contain null or empty name.");

            string upperName = name.ToUpper();

            return upperName switch
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
                "SLEEP" => SLEEP.Stable,
                "AWAKE" => AWAKE.Stable,
                _ => false
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (string.IsNullOrEmpty(this.Name))
                return string.Empty;
            else
                return $"{Name.ToUpper()[0]}{Name.ToLower()[1..]}";
        }
    }
}
