using System.Security;
using System.Security.Cryptography;
using System.Text;

using Zustandsmaschine.Items.Interfaces;
using Zustandsmaschine.Items.Subjects.Sets;

namespace Zustandsmaschine.Items.Subjects
{
    /// <summary>
    /// A class which represents deployment and its basic instance
    /// </summary>
    public class Deployment : IDeployment
    {
        /// <summary>
        /// A 32-bit integer value representing an identification number for current deployment
        /// </summary>
        private readonly int? id;
        /// <summary>
        /// A 32-bit integer value representing an identification hash of last interaction either append
        /// </summary>
        private int? codes;
        /// <summary>
        /// A 32-bit integer value representing an validation code and flag for stability check of deployment
        /// </summary>
        private int? scope;

        /// <summary>
        /// Dynamic dictionary of pairs of codes-strings by position representing an interactions history within deployment
        /// </summary>
        public Dictionary<int, Pair<string, int>> interactions = new();

        /// <summary>
        /// String value representing name of current deployment
        /// </summary>
        private readonly string? name;

        /// <summary>
        /// Constructor of instance for deployment
        /// </summary>
        /// <param name="name">
        /// String value representing name of current deployment for current instance
        /// </param>
        public Deployment(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Constructor of instance for deployment
        /// </summary>
        /// <param name="name">
        /// String value representing name of current deployment for current instance
        /// </param>
        /// <param name="id">
        /// A 32-bit integer value representing an identification number for current instance
        /// </param>
        public Deployment(string name, int id) : this(name)
        {
            this.id = id;
        }

        /// <summary>
        /// Constructor of instance for deployment
        /// </summary>
        /// <param name="name">
        /// String value representing name of current deployment for current instance
        /// </param>
        /// <param name="id">
        /// A 32-bit integer value representing an identification number for current instance
        /// </param>
        /// <param name="codes">
        /// A 32-bit integer value representing an identification hash of last interaction either append for current instance
        /// </param>
        /// <param name="scope">
        /// A 32-bit integer value representing an validation code and flag for stability check of deployment for current instance
        /// </param>
        public Deployment(string name, int id, int? codes, int? scope) : this(name)
        {
            this.id = id;

            this.codes = codes;
            this.scope = scope;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">
        /// String value representing message which would be added to interactions history
        /// </param>
        public void Add(string message)
        {
            int code = message.GetHashCode();

            int count = interactions.Count;

            if (count == 0)
                this.scope = code;
            else
                this.scope = int.MaxValue - code - (31 * count);

            if (interactions.ContainsKey(count))
            {
                interactions[count] = new Pair<string, int>(message, code);

                int adjuster = count;

                while(interactions.ContainsKey(adjuster))
                    adjuster++;


                interactions.Add(adjuster,
                                      new Pair<string, int>($"Hard-reset of position before: {count}", -1));
            }
            else
                interactions.Add(count, 
                                      new Pair<string, int>(message, code));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public void Add(string message, params object[] args) 
        {
            string argsMSG = string.Join(", ", args);

            
        }

        public void Add(string message, int codes)
        {
            this.codes = codes;

            // Message: DIRECT APPROACH TO CODES
        }

        public void Add(string message, int codes, int scope)
        {
            this.codes = codes;
            this.scope = scope;

            // MESSAGE: DIRECT-DIRECT APPROACH TO SCOPE
        }

        public void Add(string message, int codes, int scope, params object[] args)
        {
            string argsMSG = string.Join(", ", args);

            this.codes = codes;
            this.scope = scope;

            // MESSAGE: DIRECT-DIRECT APPROACH TO SCOPE
        }

        /// <summary>
        /// Method clearing dynamic array of strings representing interactions history without updating scope and codes
        /// </summary>
        public void Clear()
        {
            this.interactions = new();
        }

        /// <summary>
        /// Method deleting first interaction from instance of deployment without reupdating it
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown when first interaction of dynamic array doesn't exist, meaning the interactions are nullable
        /// </exception>
        public void FirstDELETE()
        {
            if (interactions.First().Value != null)
                interactions.Remove(interactions.First().Key);
            else
#pragma warning disable S3928
                throw new InvalidOperationException("First interaction in deployment doesn't exist!", new ArgumentNullException(nameof(interactions)));
        }


        /// <summary>
        /// Method deleting front either last interaction from instance of deployment without reupdating it
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown when front either last interaction of dynamic array doesn't exist, meaning the interactions are nullable
        /// </exception>
        public void FrontDELETE()
        {
            if (interactions.Last().Value != null)
                interactions.Remove(interactions.Last().Key);
            else
                throw new InvalidOperationException("Front interaction in deployment doesn't exist!", new ArgumentNullException(nameof(interactions)));
#pragma warning restore S3928
        }

        /// <summary>
        /// A 32-bit integer value representing an identification number for current deployment
        /// </summary>
        public int? ID { get { return this.id; } }
        /// <summary>
        /// A 32-bit integer value representing an identification hash of last interaction either append
        /// </summary>
        public int? Codes { get { return this.codes; } }
        /// <summary>
        /// A 32-bit integer value representing an validation code and flag for stability check of deployment
        /// </summary>
        public int? Scope { get { return this.scope; } }

        /// <summary>
        /// Dynamic dictionary of pairs of codes-strings by position representing an interactions history within deployment
        /// </summary>
#pragma warning disable S2292
        public Dictionary<int, Pair<string, int>> Interactions { get { return this.interactions; } set { this.interactions = value; } }
#pragma warning restore S2292

        /// <summary>
        /// String value representing name of current deployment
        /// </summary>
        public string? Name { get { return this.name; } }
    }
}
