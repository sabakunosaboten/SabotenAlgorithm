using UnityEngine;

public class Explanation101 : MonoBehaviour
{
    [SerializeField]Score scoreScript;
    [SerializeField]TextDisplay textDisplayScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int previousScore;
        int.TryParse(SaveManager.GetAllSaveData().saveScore[0,1],out previousScore);
        if(0 <= previousScore && previousScore < 100)
        {
            Debug.Log(SaveManager.filePath);
            scoreScript.canClick = false;
            textDisplayScript.DisplayText(textDisplayScript.targetText.Length,() =>
            {
                scoreScript.canClick = true;
            });

        }
        else
        {
            scoreScript.canClick = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
