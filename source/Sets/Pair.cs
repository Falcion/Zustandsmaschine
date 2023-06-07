namespace Zustand.Sets
{
    internal interface IPair
    {
        public void Swap();
    }

    public class Pair<T1, T2> : IPair
    {
        public T1? First { get; set; }
        public T2? Second { get; set; }

        public Pair() { }

        public Pair(T1? first, T2? second)
        {
            First = first;
            Second = second;
        }

        public void Swap() => throw new NotImplementedException();
    }

    public class Pair<T>
    {
        public T? First { get; set; }
        public T? Second { get; set; }

        public Pair() { }

        public Pair(T? first, T? second)
        {
            First = first;
            Second = second;
        }

        public void Swap()
        {
            (Second, First) = (First, Second);
        }
    }
}