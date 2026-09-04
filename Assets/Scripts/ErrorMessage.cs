using System.Collections;
using UnityEngine;
using TMPro;

public class ErrorMessage : MonoBehaviour
{
    static ErrorMessage instance;

    [SerializeField] TMP_Text label;
    Coroutine hideRoutine;

    void Awake()
    {
        instance = this;
        gameObject.SetActive(false);
    }

    public static void Show(string message, float duration = 2f)
        => instance.ShowInternal(message, duration);

    void ShowInternal(string message, float duration)
    {
        label.text = message;
        gameObject.SetActive(true);

        if (hideRoutine != null)
            StopCoroutine(hideRoutine);
        hideRoutine = StartCoroutine(HideAfter(duration));
    }

    IEnumerator HideAfter(float duration)
    {
        yield return new WaitForSeconds(duration);
        gameObject.SetActive(false);
    }
}
