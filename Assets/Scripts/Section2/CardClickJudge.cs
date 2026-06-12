using UnityEngine;

public class CardClickJudge : MonoBehaviour
{
    [SerializeField] Sprite[] cardSprites;
    [SerializeField]CopyObject CopyObjectScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < cardSprites.Length; i++)
        {
            SpriteRenderer cardSprite = CopyObjectScript.cardInstance[i].GetComponent<SpriteRenderer>();
            cardSprite.sprite = cardSprites[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
