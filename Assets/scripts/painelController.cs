using UnityEngine;
using UnityEngine.UI;

public class painelController : MonoBehaviour
{
    public GameObject pnMap;
    public GameObject pbAbout;
    public Button btnPlay;
    public Button btnAbout;

    void Start()
    {
        btnPlay.onClick.AddListener(OnPlayClicked);
        btnAbout.onClick.AddListener(OnAboutClicked);

        pnMap.SetActive(false);
        pbAbout.SetActive(false);
    }

    void OnPlayClicked()
    {
        pnMap.SetActive(true);
        pbAbout.SetActive(false);
    }

    void OnAboutClicked()
    {
        pbAbout.SetActive(true);
        pnMap.SetActive(false);
    }
}