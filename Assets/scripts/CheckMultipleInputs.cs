using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CheckMultipleInputs : MonoBehaviour
{
    public InputField[] inputFields;
    public string[] correctAnswers;

    public AudioClip successClip;
    public AudioClip errorClip;
    public AudioSource audioSource;

    private bool[] isCorrect;
    private bool gameEnded = false;

    void Start()
    {
        if (inputFields.Length != correctAnswers.Length)
        {
            Debug.LogError("Número de Inputs não corresponde ao número de respostas!");
            return;
        }

        isCorrect = new bool[inputFields.Length];

        for (int i = 0; i < inputFields.Length; i++)
        {
            int index = i; // Necessário para capturar corretamente no delegate
            inputFields[i].onEndEdit.AddListener(delegate { OnEndEdit(index, inputFields[index].text); });
        }
    }

    void OnEndEdit(int index, string text)
    {
        if (gameEnded || text.Length == 0)
            return;

        bool correct = text == correctAnswers[index];
        isCorrect[index] = correct;

        StartCoroutine(BlinkAndPlayFeedback(index, correct));

        if (!correct)
        {
            gameEnded = true;
            StartCoroutine(LoadSceneAfterDelay(false));
        }
        else if (AllCorrect())
        {
            gameEnded = true;
            StartCoroutine(LoadSceneAfterDelay(true));
        }
    }

    bool AllCorrect()
    {
        foreach (bool c in isCorrect)
        {
            if (!c) return false;
        }
        return true;
    }

    IEnumerator BlinkAndPlayFeedback(int index, bool correct)
    {
        Color original = inputFields[index].textComponent.color;
        Color target = correct ? Color.green : Color.red;
        AudioClip clip = correct ? successClip : errorClip;

        audioSource.PlayOneShot(clip);

        for (int i = 0; i < 4; i++)
        {
            inputFields[index].textComponent.color = target;
            yield return new WaitForSeconds(0.2f);
            inputFields[index].textComponent.color = original;
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator LoadSceneAfterDelay(bool success)
    {
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(success ? 2 : 3);
    }
}