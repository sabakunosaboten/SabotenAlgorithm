using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Score200 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    bool canClick;
    GrowCard previousTarget;
    void Start()
    {
        canClick = true;
    }

    // Update is called once per frame
    void Update()
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
                    GrowCard target = hit.collider.GetComponent<GrowCard>();
                    target.Grow();
                    if(previousTarget != null)previousTarget.Grow();
                    previousTarget = target;

                    // ★修正ポイント2：当たったものに「ChangeImage」が付いているかチェック！
                    if (targetCard != null)
                    {
                    

                    }
                }
            }
        }
    }
}
