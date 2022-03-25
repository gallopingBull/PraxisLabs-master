using System;
using UnityEngine;

[Serializable]
public class Choice
{
    //[HideInInspector]
    [Tooltip("This will be button's title when user needs to make a selection.")]
    public string Choice_Title = ""; 
    
    // ID for node link
    private int _choice_ID = 0;

    [Tooltip("Enable this if this is the correct choice in the narrative.")]
    public bool isCorrectChoice = false;
    
    [Tooltip("This will be button's position relative to player in world space.")]
    public Vector3 ButtonLocation;


    [Tooltip("Outcome object with serialible fields to allow for custom outcomes based on choice.")]
    [SerializeField] Outcome _outcome;

    public Outcome Outcome { get => _outcome;}
}
