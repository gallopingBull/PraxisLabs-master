using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Custom button claass that inherits from Unity Button class. Initialized button 
/// to suscribe to narrative events and other general button UI behavior.
/// </summary>

public class ButtonTemplate : Button, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{

    private bool _isCorrect = false;
    private bool _interactable = false;
    [SerializeField]
    public AudioClip _correctInputClip, _incorrectInputClip, _buttonSelectedClip;

    public void InitButton(Choice choice, ButtonTemplate but)
    {
        // get button location
        but.GetComponent<RectTransform>().localPosition = choice.ButtonLocation;
        // get button name
        but.GetComponentInChildren<TextMeshProUGUI>().text = choice.Choice_Title;

        #region suscribe to narrative/button events
        // get and assign outcome event to button
        but.onClick.AddListener(choice.Outcome.SelectDecision);
        but.onClick.AddListener(PlayButtonSFX);
        //but.OnSelect = SoundManager.Instance.PlaySound(_correctInputClip);
        NarrativeEvents.OnSequenceBegin += DisplayButton;
        NarrativeEvents.OnSequenceEnd += HideButton;
        #endregion
        
        HideButton();
        _isCorrect = choice.isCorrectChoice; 
    }

    public override void OnSelect(BaseEventData eventData)
    {
        Debug.Log("Selected");
        SoundManager.Instance.PlaySound(_buttonSelectedClip);
    }
    private void DisplayButton() => gameObject.SetActive(true);

    private void HideButton() => gameObject.SetActive(false);

    public void PlayButtonSFX()
    {
        if (_isCorrect)
            SoundManager.Instance.PlaySound(_correctInputClip);
        else
            SoundManager.Instance.PlaySound(_incorrectInputClip);
    }
}
