using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [HideInInspector]
    public static SoundManager Instance;
    public AudioSource SFXSource;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        InitSoundManager();
    }

    public void PlaySound(AudioClip sound)
    {
        if (SFXSource != null)
            SFXSource.PlayOneShot(sound);
    }
    private void InitSoundManager()
    {
        SFXSource = GetComponent<AudioSource>();
    }
}