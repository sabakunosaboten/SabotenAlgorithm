using System.Data;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreTextDisplay : MonoBehaviour
{ 
    SaveData loadData; 
    
    string[] Scores;
    [SerializeField] GameObject textPrefab;
    [SerializeField] Transform canvasTransform;
    [SerializeField] float distantV = 5f;
    [SerializeField] float distantH = 5f;
    [SerializeField] float x = 0;
    [SerializeField] float y = 0;
    [SerializeField] int chapter;
    [Tooltip("Text")]
    public TextMeshProUGUI[] copyedText;
    public UnityEvent<int> textIndex;
    public void CopyTextF(int i)
    {
            GameObject textInstance = Instantiate(textPrefab,canvasTransform);

            RectTransform rect = textInstance.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(x+i*distantH,y-i*distantV);

            TMP_Text scoreText = textInstance.GetComponentInChildren<TMP_Text>();
            scoreText.text = scoreText.text = "スコア"+Scores[i];

            textInstance.SetActive(true);

            int localIndex =i;
            textIndex.Invoke(localIndex);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScorePreview(chapter);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScorePreview(int cp)
    {
        loadData = SaveManager.GetAllSaveData();
        Scores=loadData.row[cp].col;
        UnityEngine.Debug.Log("text");
        for(int i = 0; i < Scores.Length; i++)
        {    
            CopyTextF(i);
        }
    }
}
