using UnityEngine;
using UnityEngine.InputSystem;

public class CardClickJudge : MonoBehaviour
{
    [SerializeField] Sprite[] cardSprites;
    [SerializeField]CopyObject CopyObjectScript;
    bool canClick;
    GrowCard previousTarget;
    GrowCard target;
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
        CardClick();
    }
    public void CardClick()
    {
        if(canClick == true)
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

                // ★修正ポイント1：光線が何かに当たったか（空振りしていないか）をチェック！
                if (hit.collider != null)
                {
                    ChangeImage targetCard = hit.collider.GetComponent<ChangeImage>();
                    target = hit.collider.GetComponent<GrowCard>();
                    CardGrow(target);

                    // ★修正ポイント2：当たったものに「ChangeImage」が付いているかチェック！
                    if (targetCard != null)
                    {
                    

                    }
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
    }
}


