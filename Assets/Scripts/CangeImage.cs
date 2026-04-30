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


    public int mySpriteIndex =-1;

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
        SpriteRenderer nowSprite = GetComponent<SpriteRenderer>();
        nowSprite.sprite = DefoltSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if(hit.collider != null && hit.collider.gameObject == this.gameObject)
            {
                ImageChange(mySpriteIndex);
                
            }

        }
    }
}
