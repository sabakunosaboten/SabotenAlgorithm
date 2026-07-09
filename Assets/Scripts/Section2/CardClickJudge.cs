using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class CardClickJudge : MonoBehaviour
{
    [SerializeField] Sprite[] cardSprites;
    [SerializeField]CopyObject CopyObjectScript;
    [SerializeField]Score200 ScoreScript;
    bool canClick;
    public bool reset = false;
    public int cardIndex{get;private set;} = -1;

    public void IndexReset()
    {
        cardIndex = -1;
    }
    GrowCard previousTarget;
    GrowCard target;
    public bool isClicking{get ;private set;} = false;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canClick = true;
        for(int i = 0; i < cardSprites.Length; i++)
        {
            SpriteRenderer cardSprite = CopyObjectScript.cardInstance[i].GetComponent<SpriteRenderer>();
            cardSprite.sprite = cardSprites[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            isClicking = true;
            CardClick();
        }
        else
        {
            isClicking = false;
        }
    }
    IEnumerator WaitClick()
    {
    // 左クリックされるまでここで一時停止
        yield return new WaitUntil(() => isClicking);
    }
    public void CardClick()
    {
        if(canClick == true)
        {
            if (isClicking)
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

                // ★修正ポイント1：光線が何かに当たったか（空振りしていないか）をチェック！
                if (hit.collider != null)
                {
                    ChangeImage targetCard = hit.collider.GetComponent<ChangeImage>();
                    target = hit.collider.GetComponent<GrowCard>();
                    CardGrow(target);
                    cardIndex = hit.collider.GetComponent<ObjectInformation>().GetIndex();
                }
            }
        }
    }

    void CardGrow(GrowCard target)
    {
        SpriteRenderer nowSprite = target.GetComponent<SpriteRenderer>();
        if(previousTarget != null)
                    {
                        previousTarget.Grow();
                        SpriteRenderer previousSprite = previousTarget.GetComponent<SpriteRenderer>();
                        Sprite kariSprite = previousSprite.sprite;
                        previousSprite.sprite = nowSprite.sprite;
                        nowSprite.sprite = kariSprite;
                        previousTarget = null;
                    }
                    else
                    {
                        target.Grow();
                        previousTarget = target;
                    }
    }
    public void GrowRset()
    {
        target.Grow();
        previousTarget = null;
        reset=true;
    }
}


