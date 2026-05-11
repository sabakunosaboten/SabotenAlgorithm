using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class CopyButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] Transform canvasTransform;
    [SerializeField] ChangeScene stageSelectScript;
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

            int buttonIndex = i;

            Button btn = buttonInstance.GetComponent<Button>();

            btn.onClick.AddListener(() =>
            {
                stageSelectScript.StageSelectToGame_Button(buttonIndex);
            });
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
