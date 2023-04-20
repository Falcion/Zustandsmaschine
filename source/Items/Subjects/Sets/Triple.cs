namespace Zustandsmaschine.Items.Subjects.Sets
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <typeparam name="U"></typeparam>
    public class Triple<K, V, U>
    {
        /// <summary>
        /// 
        /// </summary>
        public K? P1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public V? P2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public U? P3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Triple() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="P1"></param>
        /// <param name="P2"></param>
        /// <param name="P3"></param>
        public Triple(K P1, V P2, U P3)
        {
            this.P1 = P1;
            this.P2 = P2;
            this.P3 = P3;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Triple<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public T? P1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public T? P2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public T? P3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Triple() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="P1"></param>
        /// <param name="P2"></param>
        /// <param name="P3"></param>
        public Triple(T P1, T P2, T P3)
        {
            this.P1 = P1;
            this.P2 = P2;
            this.P3 = P3;
        }
    }
}
