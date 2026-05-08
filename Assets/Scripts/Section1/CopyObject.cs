using System;
using UnityEditor.Rendering;
using UnityEngine;

public class CopyObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject card;
    [SerializeField] float distant = 5f;
    [SerializeField] float positionX = 0f;
    [SerializeField] float positionY = 0f;
    [SerializeField] int spriteNumbers;

    void Start()
    {
        for(int i=0;i< spriteNumbers; i++)
        {
            GameObject instance = Instantiate(card);
            instance.transform.position = new Vector2(positionX+i*distant,positionY);
            ChangeImage changeImageScript = instance.GetComponent<ChangeImage>();
            changeImageScript.mySpriteIndex = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
