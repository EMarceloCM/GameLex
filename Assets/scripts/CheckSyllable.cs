using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CheckSyllable : MonoBehaviour
{
    public InputField inputField;
    public AudioClip successClip;
    public AudioClip errorClip;
    public AudioSource audioSource;

    void Start()
    {
        inputField.onEndEdit.AddListener(OnEndEdit);
    }

    void OnEndEdit(string text)
    {
        if (text.Length > 0)
            StartCoroutine(BlinkPlayAndLoad(text));
    }

    IEnumerator BlinkPlayAndLoad(string text)
    {
        Color original = inputField.textComponent.color;
        bool isCorrect = text == "te";
        Color target = isCorrect ? Color.green : Color.red;
        AudioClip clip = isCorrect ? successClip : errorClip;

        audioSource.PlayOneShot(clip);

        for (int i = 0; i < 4; i++)
        {
            inputField.textComponent.color = target;
            yield return new WaitForSeconds(0.2f);
            inputField.textComponent.color = original;
            yield return new WaitForSeconds(0.2f);
        }

        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene(isCorrect ? 1 : 0);
    }
}