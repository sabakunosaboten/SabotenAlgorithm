using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;


public class Score300 : MonoBehaviour
{
    bool canClick = true;
    int[] rightList = {3,2,1,2,3,4,4,-1,0,1,2,-1,5,-1,1,-1,3,4,-1,3,2,3,4,-1,5,4,-1,-1,5,6,6,5,6,7,6,-1};
    int nowPoints = 0;
    int canGetPoint = 0;

    [SerializeField] Button finishButton;

    [SerializeField] ResultDisplay RDcs;
    [SerializeField] TextMeshProUGUI nowPointText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
                    int cardIndex = hit.collider.GetComponent<ObjectInformation>().GetIndex();

                    Debug.Log("awfhe9useoj");
                    // ★修正ポイント2：当たったものに「ChangeImage」が付いているかチェック！
                    if (targetCard != null)
                    {
                        targetCard.ImageChange(cardIndex);
                        Score(cardIndex);

                        finishButton.onClick.AddListener(() => RDcs.DisplayCanvas(nowPoints.ToString()));
                    }
                }
            }
        }
    }

    void Score(int index)
    {
        if(canGetPoint <= rightList[index])
        {
            nowPoints += rightList[index];
            canGetPoint = rightList[index];
            rightList[index] = -1;
            nowPointText.text = nowPoints.ToString();
        }
        Debug.Log(nowPoints);
    }
}
