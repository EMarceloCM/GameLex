using UnityEngine;
using UnityEngine.UI;

public class aboutController : MonoBehaviour
{
    public Button btnBack;

    void Start()
    {
        btnBack.onClick.AddListener(ComeBack);
    }

    void ComeBack()
    {
        gameObject.SetActive(false);
    }
}