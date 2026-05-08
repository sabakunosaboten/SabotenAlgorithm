using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Score102 : MonoBehaviour
{
    int[] clickCount = new int[7];
    int clickedCount = 0;
    int[] score = new int[3];
    int currentStep = -1;
    int[] correctOrder = {3,1,2};
    int lastClickedIndex = -1;
    bool expectBiggerNext = true;
    bool canClick;
    public ResultDisplay displayScript;

    public int finalScore {get; private set;}

    void Start()
    {
        score[0] = 100;
        currentStep = 0;
        canClick = true;
        clickedCount = 0;
    }
    void Update()
    {
        if(canClick == true)
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                clickedCount+=1;
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

                // ★修正ポイント1：光線が何かに当たったか（空振りしていないか）をチェック！
                if (hit.collider != null)
                {
                    ChangeImage targetCard = hit.collider.GetComponent<ChangeImage>();

                    // ★修正ポイント2：当たったものに「ChangeImage」が付いているかチェック！
                    if (targetCard != null)
                    {
                        targetCard.ImageChange(targetCard.mySpriteIndex);
                        if ((clickedCount==1||clickedCount==2||clickedCount==3)&&targetCard.mySpriteIndex == correctOrder[currentStep])
                        {
                            currentStep +=1;
                            if (currentStep >= correctOrder.Length)
                            {
                                score[1]=100;
                                FinalScore();
                                displayScript.DisplayCanvas(finalScore);
                                canClick = false;
                            }
                        }

                        if (lastClickedIndex==-1&&targetCard.mySpriteIndex<2)
                        {
                            lastClickedIndex = targetCard.mySpriteIndex;
                            expectBiggerNext = true;

                        }
                        else if (lastClickedIndex == -1 && targetCard.mySpriteIndex > 2)
                        {
                            lastClickedIndex = targetCard.mySpriteIndex;
                            expectBiggerNext = false;
                        }
                        else if(lastClickedIndex == -1 && targetCard.mySpriteIndex == 2)
                        {
                            score[0]=95;
                            displayScript.DisplayCanvas(score[0]);
                            canClick = false;
                        }
                        else
                        {
                            if(expectBiggerNext == true && targetCard.mySpriteIndex > lastClickedIndex)
                            {
                                lastClickedIndex = targetCard.mySpriteIndex;
                                if (targetCard.mySpriteIndex < 2)
                                {
                                    expectBiggerNext = true;
                                }
                                else if (targetCard.mySpriteIndex == 2)
                                {
                                    score[0]=90;
                                    displayScript.DisplayCanvas(score[0]);
                                    canClick = false;
                                }
                                else
                                {
                                    expectBiggerNext = false;
                                }
                            }
                            else if(expectBiggerNext == false && targetCard.mySpriteIndex < lastClickedIndex)
                            {
                                lastClickedIndex = targetCard.mySpriteIndex;
                                if (targetCard.mySpriteIndex < 2)
                                {
                                    expectBiggerNext = true;
                                }
                                else if (targetCard.mySpriteIndex == 2)
                                {
                                    score[0]=90;
                                    displayScript.DisplayCanvas(score[0]);
                                    canClick = false;
                                }
                                else
                                {
                                    expectBiggerNext = false;
                                }
                            }
                            else
                            {
                                score[1]=80;
                            }
                            if (targetCard.mySpriteIndex == 2)
                            {
                                FinalScore();
                                displayScript.DisplayCanvas(finalScore);
                                canClick = false;
                            }
                        }
                    }
                }
            }
        }
    }

    public void FinalScore()
    {
        finalScore = score[0];
        if (score[1] != 0)
        {
            finalScore = score[1];
        }
    }
}