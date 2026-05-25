using UnityEngine;
using System.Collections;
using TMPro;
using System;
using Unity.VisualScripting;

public class TextDisplay : MonoBehaviour
{
    [Header("テキスト表示設定")]
    [Tooltip("テキスト")]
    public TextMeshProUGUI[] targetText;
    [Tooltip("表示開始までの待機時間")]
    public float[] delayBeforeShow ;
    [Tooltip("フェードイン時間")]
    public float[] fadeInDuration ;
    [Tooltip("表示時間")]
    public float[] displayDuration ;
    [Tooltip("フェードアウト時間")]
    public float[] fadeOutDuration ;
    [Tooltip("自動開始")]
    public bool AutStart = false;

    int n;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (targetText != null)
        {
            n=targetText.Length;
            for(int i = 0; i < targetText.Length; i++)
            {
                SetAlpha(0,i);
            }
            if (AutStart)
            {
                DisplayText(n);
            }
        }
        
    }

    public void DisplayText(int n,Action onComplete = null)
    {
        for(int i = 0; i < n; i++)
        {
            StartCoroutine(ProcessFade(onComplete,i));   
        }
    }

    IEnumerator ProcessFade(Action onComplete,int i)
    {
        yield return new WaitForSeconds(delayBeforeShow[i]);
        yield return Fade(0f,1f,fadeInDuration[i],i);
        yield return new WaitForSeconds(displayDuration[i]);
        yield return Fade(1f,0f,fadeOutDuration[i],i);
        onComplete?.Invoke();
    }
    IEnumerator Fade(float startAlpha,float endAlpha,float duration,int textIndex)
    {
        float time = 0f;
        while (time<duration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha,endAlpha,time/duration);
            SetAlpha(alpha,textIndex);
            yield return null;
        }
        SetAlpha(endAlpha,textIndex);
    }

    void SetAlpha(float alpha,int textIndex)
    {
        if (targetText != null)
        {
            Color c = targetText[textIndex].color;
            c.a = alpha;
            targetText[textIndex].color = c;

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
