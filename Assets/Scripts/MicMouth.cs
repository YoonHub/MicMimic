using UnityEngine;

public class MicMouth : MonoBehaviour
{
    public RectTransform upperLip;
    public RectTransform lowerLip;
    public float maxMove = 30f;

    private Vector2 upperInitial;
    private Vector2 lowerInitial;

    void Start()
    {
        upperInitial = upperLip.anchoredPosition;
        lowerInitial = lowerLip.anchoredPosition;
    }

    void FixedUpdate()
    {
        float amount = Mathf.Clamp01(MicrophoneInput.Volume * 50f);
        float offset = amount * maxMove;

        upperLip.anchoredPosition = upperInitial + Vector2.up * offset;
        lowerLip.anchoredPosition = lowerInitial + Vector2.down * offset;
    }
}
