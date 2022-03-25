using System;
using UnityEditor;
using UnityEngine.Timeline;
using UnityEngine;


[Serializable]
public class NarrativeSequence 
{
    //[HideInInspector]
    public string _sequenceID = "Sequence"; //"Scene" + scene number + alpha 

    [SerializeField] AudioClip _narratorAudioClip;
    [TextArea]
    [Tooltip("Text that will be used for close captioning response dialog.")]
    public string _sequenceIntroCC = "";

    [Tooltip("Sequence level to load.")]
    public SceneAsset SequenceLevel;

    // these references to timeline clips will
    // cutscenes, post process FX, and camera fades.
    [SerializeField] TimelineAsset _someTimelineClips;

    public Choice[] Choices;
    public void BeginSequence()
    {
        // play some scene fade or FX
        // play some characther animation using 
        SoundManager.Instance.PlaySound(_narratorAudioClip);
    }
    public void EndSequence()
    {
        // play some scene fade or FX
        // play some characther animation using 
        SoundManager.Instance.PlaySound(_narratorAudioClip);
    }
 
}




    