using System.Data;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreTextDisplay : MonoBehaviour
{ 
    SaveData loadData; 
    
    int[] Score;
    [SerializeField] GameObject textPrefab;
    [SerializeField] Transform canvasTransform;
    [SerializeField] float distantV = 5f;
    [SerializeField] float distantH = 5f;
    [SerializeField] float x = 0;
    [SerializeField] float y = 0;
    [Tooltip("Text")]
    public TextMeshProUGUI[] copyedText;
    public UnityEvent<int> textIndex;
    public void CopyTextF(int i)
    {
            GameObject textInstance = Instantiate(textPrefab,canvasTransform);

            RectTransform rect = textInstance.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(x+i*distantH,y-i*distantV);

            TMP_Text scoreText = textInstance.GetComponentInChildren<TMP_Text>();
            scoreText.text = scoreText.text = "スコア"+Score[i];

            textInstance.SetActive(true);

            int localINdex =i;
            textIndex.Invoke(localINdex);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScorePreview(int chapterIndex)
    {
        loadData = SaveManager.GetAllSaveData();
        int[][] chapterScores={loadData.finalScore100,loadData.finalScore200};
        UnityEngine.Debug.Log("text");
        Score=chapterScores[chapterIndex];
        for(int i = 0; i < copyedText.Length; i++)
        {
            CopyTextF(i);
        }
    }
}
