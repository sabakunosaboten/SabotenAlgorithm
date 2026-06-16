using System;
using JetBrains.Annotations;
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
    public int mySpriteIndex=-1;

    public GameObject[] cardInstance{get;private set;}

    void Awake()
    {
        cardInstance = new GameObject[spriteNumbers];
        for(int i=0;i< spriteNumbers; i++)
        {
            GameObject instance = Instantiate(card);
            instance.transform.position = new Vector2(positionX+i*distant,positionY);
            mySpriteIndex = i;
            cardInstance[i] = instance;
            int localindex=i;
            instance.GetComponent<ObjectInformation>().Setup(localindex);
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
