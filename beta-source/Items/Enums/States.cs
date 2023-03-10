namespace OctokittyDISCORD.Items.Enums
{
    ///  <summary>
    ///  An public <see langword="enum"/> which represents state's ID inside of state-machine.
    /// </summary>
    /// 
    ///  <remarks>
    ///  <i>This type of data is a <see cref="SerializableAttribute">serializable</see>: it means it cannot be inherited and can be serialized.</i>
    /// </remarks>
    /// 

    [Serializable]
    public enum States
    {
        FAILED,
        SKIPPED,
        PROCESSING,
        SUCCESSFUL,
        UNKNOWN,
    }

    ///  <summary>
    ///  An public <see langword="enum"/> which represents state's shift ID inside of state-machine.
    /// </summary>
    /// 
    ///  <remarks>
    ///  <i>This type of data is a <see cref="SerializableAttribute">serializable</see>: it means it cannot be inherited and can be serialized.</i>
    /// </remarks>
    /// 

    [Serializable]
    public enum Shifts
    {
        BEGIN,
        PAUSE,
        RESUME,
        EXIT,
        STOP,
    }
}