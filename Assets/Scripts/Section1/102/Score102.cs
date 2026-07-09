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
    string scoreText;

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
                    int cardIndex = hit.collider.GetComponent<ObjectInformation>().GetIndex();

                    // ★修正ポイント2：当たったものに「ChangeImage」が付いているかチェック！
                    if (targetCard != null)
                    {
                        targetCard.ImageChange(cardIndex);
                        if ((clickedCount==1||clickedCount==2||clickedCount==3)&&cardIndex == correctOrder[currentStep])
                        {
                            currentStep +=1;
                            if (currentStep >= correctOrder.Length)
                            {
                                score[1]=100;
                                FinalScore();
                                displayScript.DisplayCanvas(scoreText);
                                canClick = false;
                            }
                        }

                        if (lastClickedIndex==-1&&cardIndex<2)
                        {
                            lastClickedIndex = cardIndex;
                            expectBiggerNext = true;

                        }
                        else if (lastClickedIndex == -1 && cardIndex > 2)
                        {
                            lastClickedIndex = cardIndex;
                            expectBiggerNext = false;
                        }
                        else if(lastClickedIndex == -1 && cardIndex == 2)
                        {
                            score[0]=95;
                            displayScript.DisplayCanvas(score[0].ToString());
                            canClick = false;
                        }
                        else
                        {
                            if(expectBiggerNext == true && cardIndex > lastClickedIndex)
                            {
                                lastClickedIndex = cardIndex;
                                if (cardIndex < 2)
                                {
                                    expectBiggerNext = true;
                                }
                                else if (cardIndex == 2)
                                {
                                    score[0]=90;
                                    displayScript.DisplayCanvas(score[0].ToString());
                                    canClick = false;
                                }
                                else
                                {
                                    expectBiggerNext = false;
                                }
                            }
                            else if(expectBiggerNext == false && cardIndex < lastClickedIndex)
                            {
                                lastClickedIndex = cardIndex;
                                if (cardIndex < 2)
                                {
                                    expectBiggerNext = true;
                                }
                                else if (cardIndex == 2)
                                {
                                    score[0]=90;
                                    displayScript.DisplayCanvas(score[0].ToString());
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
                            if (cardIndex == 2)
                            {
                                FinalScore();
                                displayScript.DisplayCanvas(scoreText);
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
        scoreText = finalScore.ToString();
        if (score[1] != 0)
        {
            finalScore = score[1];
        }
        SaveManager.SaveScore(scoreText,0,1);
    }
}