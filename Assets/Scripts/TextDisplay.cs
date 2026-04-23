using UnityEngine;
using System.Collections;
using TMPro;
using System;

public class TextDisplay : MonoBehaviour
{
    [Header("テキスト表示設定")]
    [Tooltip("テキスト")]
    public TextMeshProUGUI targetText;
    [Tooltip("表示開始までの待機時間")]
    public float delayBeforeShow = 1.0f;
    [Tooltip("フェードイン時間")]
    public float fadeInDuration = 1.0f;
    [Tooltip("表示時間")]
    public float displayDuration = 1.0f;
    [Tooltip("フェードアウト時間")]
    public float fadeOutDuration = 1.0f;
    [Tooltip("自動開始")]
    public bool AutStart = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (targetText != null)
        {
            SetAlpha(0);
            if (AutStart)
            {
                DisplayText();
            }
        }
        
    }

    public void DisplayText(Action onComplete = null)
    {
        StartCoroutine(ProcessFade(onComplete));
    }

    IEnumerator ProcessFade(Action onComplete)
    {
        yield return new WaitForSeconds(delayBeforeShow);
        yield return Fade(0f,1f,fadeInDuration);
        yield return new WaitForSeconds(displayDuration);
        yield return Fade(1f,0f,fadeOutDuration);
        onComplete?.Invoke();
    }
    IEnumerator Fade(float startAlpha,float endAlpha,float duration)
    {
        float time = 0f;
        while (time<duration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha,endAlpha,time/duration);
            SetAlpha(alpha);
            yield return null;
        }
        SetAlpha(endAlpha);
    }

    void SetAlpha(float alpha)
    {
        if (targetText != null)
        {
            Color c = targetText.color;
            c.a = alpha;
            targetText.color = c;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
