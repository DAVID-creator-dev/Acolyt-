using UnityEngine;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private bool _mouseButtonDown;
    [SerializeField] private Image hudImage;
    [SerializeField] private RectTransform hudParent;

    private Vector2 _startPosition;
    private Image currentLine; 

    void UpdateLine(RectTransform line, Vector2 pointA, Vector2 pointB)
    {
        Vector2 dir = pointB - pointA;
        float distance = dir.magnitude;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        line.anchoredPosition = pointA;
        line.sizeDelta = new Vector2(distance, line.sizeDelta.y);
        line.localRotation = Quaternion.Euler(0, 0, angle);
    }
}
