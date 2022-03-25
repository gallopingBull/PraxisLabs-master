using System;
using UnityEngine;
[Serializable]
/// <summary>
/// Static action delegates for different narrative events.
/// </summary>
public class Outcome
{
    //[HideInInspector]
    public string OutcomeID = "Response"; //ID
    
    [Tooltip("Audio clip for narrator response dialof after use makes a choice.")]
    [SerializeField] AudioClip _responseClip;
    
    [TextArea]
    [Tooltip("Text that will be used for close captioning response dialog.")]
    [SerializeField] string _closedCaptionDialog = "";

    [Tooltip("Points earned from making this choice.")]
    [SerializeField] int _progressValue = 0;


    public void SelectDecision()
    {
        // hacky way to send clip length to narrative manager
        NarrativeManager.Instance.DelayTime = _responseClip.length;
        NarrativeManager.Instance.NewProgressValue = _progressValue;
        
        SoundManager.Instance.PlaySound(_responseClip);
        NarrativeEvents.OnSequenceEnd();
    }
}
