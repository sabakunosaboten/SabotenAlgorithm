using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultDisplay : MonoBehaviour
{
    [SerializeField] Canvas resultCanvas;
    [SerializeField] TextMeshProUGUI resultText;

    string[] sceneNames = {"101","102","200"};
    string nowScene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CanvasHide();
        nowScene = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayCanvas(string score)
    {
        if (nowScene == "200")
        {
            resultText.text = score;
        }
        else
        {
            resultText.text = "スコア：" + score;
        }
        resultCanvas.enabled = true;
    }

    public void CanvasDisplay()
    {
        resultCanvas.enabled = true;
    }
    
    void CanvasHide()
    {
        resultCanvas.enabled = false;
    }
}
