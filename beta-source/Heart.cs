using OctokittyDISCORD.Coroutines;
using OctokittyDISCORD.Machine;

public class Heart
{
    public static void Main(string[] args)
        => new Heart().Beat().GetAwaiter().GetResult();

    public async Task Beat()
    {
        await Task.Delay(Timeout.Infinite);
    }
}