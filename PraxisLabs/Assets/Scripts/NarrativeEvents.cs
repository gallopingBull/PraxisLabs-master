using System;
/// <summary>
/// Static action delegates for different narrative events.
/// </summary>
public class NarrativeEvents
{
    public static Action OnSceneBegin;
    public static Action OnSceneEnd;

    public static Action OnSequenceBegin;
    public static Action OnSequenceEnd;

 
    public static void UnSuscribeEventListners()
    {
        OnSceneBegin = null;
        OnSceneEnd = null;
        OnSequenceBegin = null;
        OnSequenceEnd = null;
    }

}
