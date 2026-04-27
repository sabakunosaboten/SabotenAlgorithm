using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CopyButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] Transform canvasTransform;
    [SerializeField] float distant = 5f;
    [Tooltip("Button")]
    public Button[] gameButton;
    void Start()
    {
        for(int i=0;i< gameButton.Length; i++)
        {
            GameObject buttonInstance = Instantiate(buttonPrefab,canvasTransform);

            RectTransform rect = GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(0,i*30);

            buttonInstance.transform.position = new Vector2(i*distant-5,0);

            TMP_Text buttonText = buttonInstance.GetComponentInChildren<TMP_Text>();
            buttonText.text = "Button"+(i+1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
