using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.Timeline;
using UnityEngine;

[Serializable]
public class NarrativeScene
{
    //[HideInInspector]
    public string _sceneID = "Scene"; // "Scene" + current index in array

    [Tooltip("Audio clip for narrator introduction.")]
    [SerializeField] AudioClip _narratorAudioClip;

    [Tooltip("Text that will be used for close captioning response dialog.")]
    public string _sequenceIntroCC = "";

    // these references to timeline clips will
    // cutscenes, post process FX, and camera fades.
    [SerializeField] TimelineAsset _someTimelineClips;
    [Tooltip("Scene level to load.")]
    public SceneAsset IntroSceneLevel;

    public NarrativeSequence[] _sequences;

    public void BeginScene() 
    {
        // play some scene fade
        SoundManager.Instance.PlaySound(_narratorAudioClip);
    }

    public void EndSequence()
    {
        // play some scene fade or FX
        // play some characther animation using 
        SoundManager.Instance.PlaySound(_narratorAudioClip);
    }
}
