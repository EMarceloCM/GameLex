using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class restartScript : MonoBehaviour
{
    public Button btnBack;

    void Start()
    {
        btnBack.onClick.AddListener(ComeBack);
    }

    public void ComeBack()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
