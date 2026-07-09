using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Collections;

public class ChangeImage : MonoBehaviour
{
    [Tooltip("変更後画像")]
    public Sprite[] nextSprite;

    [SerializeField] Sprite DefoltSprite;
    [SerializeField] int duration;

    public void ImageChange(int number, Action onComplete = null)
    {
        StartCoroutine(Wait(number,onComplete));
    }

    IEnumerator Wait(int number, Action onComplete)
    {
        SpriteRenderer nowSprite = GetComponent<SpriteRenderer>();
        nowSprite.sprite = nextSprite[number];
        yield return new WaitForSeconds(duration);
        nowSprite.sprite = DefoltSprite;
        onComplete?.Invoke();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject scoreObject = GameObject.Find("CreateObject");
        //clickJudge = scoreObject.GetComponent<Score>();

        SpriteRenderer nowSprite = GetComponent<SpriteRenderer>();
        nowSprite.sprite = DefoltSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
