using UnityEngine;
using UnityEngine.UI;

public class ReplayScript : MonoBehaviour
{
    public Button button;
    public AudioSource audioSource;
    public AudioClip audioClip;

    private bool hasPlayed = false;

    void Start()
    {
        if (button != null)
            button.onClick.AddListener(PlayAudioOnce);
    }

    void PlayAudioOnce()
    {
        if (!hasPlayed)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
            hasPlayed = true;
        }
    }
}