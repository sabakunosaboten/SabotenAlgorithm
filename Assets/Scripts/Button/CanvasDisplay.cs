using System;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CanvasDisplay : MonoBehaviour
{
    [SerializeField] Canvas chapterCanvas;
    [SerializeField] Canvas[] GameStageCanvas;

    [SerializeField] ScoreTextDisplay[] ScoreDisplayScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < GameStageCanvas.Length ; i++)
        {
            GameStageCanvas[i].enabled = false;
        }
    }
    public void ChaperButton(int index)
    {
        
        chapterCanvas.enabled = false;
        GameStageCanvas[index].enabled = true;
        //ScoreDisplayScript[index].ScorePreview(index);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
