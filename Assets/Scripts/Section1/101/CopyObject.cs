using System;
using UnityEngine;

public class CopyObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject card;
    [SerializeField] float distant = 5f;
    [Tooltip("Sprites")]
    public Sprite[] cardSprites;
    void Start()
    {
        for(int i=0;i< cardSprites.Length; i++)
        {
            GameObject instance = Instantiate(card);
            instance.transform.position = new Vector2(i*distant-5,0);
            SpriteRenderer sr = instance.GetComponent<SpriteRenderer>();
            sr.sprite = cardSprites[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
