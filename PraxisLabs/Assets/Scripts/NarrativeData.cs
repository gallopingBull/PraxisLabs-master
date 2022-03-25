using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NarrativeData", menuName = "ScriptableObjects/Narrative Data", order = 1)]
[Serializable]
public class NarrativeData: ScriptableObject
{
    [SerializeField]
    private NarrativeScene[] _scenes;
    public NarrativeScene[] Scenes { get => _scenes;}
}
