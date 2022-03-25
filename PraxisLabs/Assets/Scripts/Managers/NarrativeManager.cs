using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class NarrativeManager : MonoBehaviour
{
    private static NarrativeManager _instance;
    private float _delayTime = 0;

    private string currentSceneID = ""; // current scene/sequence user is in

    #region testing
    public NarrativeData NarrativeData;
    [SerializeField]
    public Dictionary<string, NarrativeData> _narrativeLibrary = new Dictionary<string, NarrativeData>();
    #endregion

    [SerializeField] AudioClip _progressPingClip;
    private Transform _UITransform;
    [SerializeField] GameObject _buttonGO; 
    [SerializeField] GameObject _progressBarGO;
    private Image _fillBar;
    private List<GameObject> _buttonList = new List<GameObject>();


    #region fill bar fields
    private float _fillSpeed = 1f;
    private float _targetFill = 0;
    private float _newProgressValue = 0;
    #endregion

    public static NarrativeManager Instance { get => _instance;}
    public float DelayTime { set => _delayTime = value; }
    public float NewProgressValue { set => _newProgressValue = value; }


    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        _UITransform = GameObject.Find("Panel_Choices").transform;
        _progressBarGO = GameObject.Find("ProgressBar");
        _fillBar = _progressBarGO.GetComponentInChildren<Image>();
        _progressBarGO.SetActive(false);

        #region get user data
        /*
         * check if there's saved data for current user
         * amd load last scene they played. if new user, load from first scene.
         * ex) _narrativeLibrary = GetSceneLibrary();
        */
        #endregion

        if (NarrativeData != null)
            PlayScene(NarrativeData, 0/*"2A"*/);
        else
            PlayScene(NarrativeData, 0/*User.CurrentUser.CurrentSequence*/);

    }

    private void Update()
    {
        Debug.Log(_targetFill);
        if (_fillBar.fillAmount < _targetFill)
            _fillBar.fillAmount += _fillSpeed * Time.deltaTime;

    }
    private void PlayScene(NarrativeData narrative, int sceneId)
    {
        // unsuscribe to delegate events for this scene
        NarrativeEvents.UnSuscribeEventListners();
        LoadScene(NarrativeData, sceneId);
    }

    private void LoadScene(NarrativeData narrative, int sceneId)
    {
        // load level scene
        InitSequence(NarrativeData, sceneId);
    }

    private void InitSequence(NarrativeData narrative, int id/*string sceneId*/)
    {
        int choicesCount = narrative.Scenes[0]._sequences[id].Choices.Length;
        if (choicesCount > 0)
        {
            for (int i = 0; i < choicesCount; i++)
            {
                var but =
                    Instantiate(_buttonGO, _UITransform.localPosition, _UITransform.rotation, _UITransform);
                but.GetComponent<ButtonTemplate>().InitButton(narrative.Scenes[0]._sequences[0].Choices[i],
                    but.GetComponent<ButtonTemplate>());
                _buttonList.Add(but);
            }
        }
        NarrativeEvents.OnSequenceBegin += narrative.Scenes[0]._sequences[id].BeginSequence;
        NarrativeEvents.OnSequenceEnd += EvaluateSequence;
        NarrativeEvents.OnSequenceBegin();
    }

    // utility method to call evalauate sequence with small delay
    private void EvaluateSequence()
    {
        StartCoroutine("EvaluateSequenceDelay");
    }

    private IEnumerator EvaluateSequenceDelay()
    {
        yield return new WaitForSeconds(_delayTime);
        _progressBarGO.SetActive(true);
        SoundManager.Instance.PlaySound(_progressPingClip);

        IncrementProgress(_newProgressValue);

        yield return new WaitForSeconds(3);
        PlayScene(NarrativeData, 1);
        // play next sequence
        StopCoroutine("EvaluateSequenceDelay");
    }
    private void IncrementProgress(float value)
    {
        _targetFill = _fillBar.fillAmount + (value);
        //User.CurrentUser.ProgressScore += value;
        //User.CurrentUser.CurrentSequence = next sequence
        // save user data 

    }

    private Dictionary<string, ScriptableObject> GetSceneLibraryFromServer() { return null;}
    private Dictionary<string, ScriptableObject> GetSceneLibrary() { return null;}
}
