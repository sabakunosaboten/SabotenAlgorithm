using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultDisplay : MonoBehaviour
{
    [SerializeField] Canvas resultCanvas;
    [SerializeField] TextMeshProUGUI resultText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CanvasHide();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayCanvas(int score)
    {
        resultText.text = "スコア：" + score;
        resultCanvas.enabled = true;
    }
    
    void CanvasHide()
    {
        resultCanvas.enabled = false;
    }
}
