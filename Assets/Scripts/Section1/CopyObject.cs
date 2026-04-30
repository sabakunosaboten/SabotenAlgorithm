using System;
using UnityEngine;

public class CopyObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject card;
    [SerializeField] float distant = 5f;
    [SerializeField] float positionX = 0f;
    [SerializeField] float positionY = 0f;
    [Tooltip("Sprites")]
    public Sprite[] cardSprites;
    void Start()
    {
        for(int i=0;i< cardSprites.Length; i++)
        {
            GameObject instance = Instantiate(card);
            instance.transform.position = new Vector2(positionX+i*distant,positionY);
            SpriteRenderer sr = instance.GetComponent<SpriteRenderer>();
            sr.sprite = cardSprites[i];
            ChangeImage changeImageScript = instance.GetComponent<ChangeImage>();
            
            if (changeImageScript != null)
            {
                // 今のループの番号(i)を、ChangeImageの変数に代入して覚えさせる！
                changeImageScript.mySpriteIndex = i;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
