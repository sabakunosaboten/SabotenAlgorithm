using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine.Events;

public class CopyButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] Transform canvasTransform;
    [SerializeField] float distantV = 5f;
    [SerializeField] float distantH = 5f;
    [SerializeField] float x = 0;
    [SerializeField] float y = 0;
    [Tooltip("Button")]
    public Button[] clickButton;
    public UnityEvent<int> ButtonIndex;
    public void CopyButtonF()
    {
        for(int i=0;i< clickButton.Length; i++)
        {
            GameObject buttonInstance = Instantiate(buttonPrefab,canvasTransform);

            RectTransform rect = buttonInstance.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(x+i*distantH,y-i*distantV);

            TMP_Text buttonText = buttonInstance.GetComponentInChildren<TMP_Text>();
            buttonText.text = "Button"+(i+1);

            buttonInstance.SetActive(true);

            int localIndex =i;
            Button btn = buttonInstance.GetComponent<Button>();
            btn.onClick.AddListener(() =>
            {
                ButtonIndex.Invoke(localIndex);
            });
        }
    }

    void Start()
    {
        CopyButtonF();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
