using UnityEngine;
using UnityEngine.UI;

public class mapController : MonoBehaviour
{
    public Button btnPlay;
    public Button btnBack;
    public AudioSource audioSource;
    public AudioClip audioClip;

    void Start()
    {
        btnPlay.onClick.AddListener(LoadScene);
        btnBack.onClick.AddListener(ComeBack);
    }

    void LoadScene()
    {
        transform.parent.gameObject.SetActive(false);
        audioSource.clip = audioClip;
        audioSource.Play();
        ComeBack();
    }

    void ComeBack()
    {
        gameObject.SetActive(false);
    }
}