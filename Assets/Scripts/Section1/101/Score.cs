using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Score : MonoBehaviour
{
    int[] clickCount = new int[7];
    int[] score = new int[2];
    int expectedNumber = -1;
    public ResultDisplay displayScript;

    public bool canClick=true;

    public int finalScore {get; private set;}=-1;

    void Start()
    {
        score[0] = 100;
        expectedNumber = 0;
    }
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

                    // ★修正ポイント2：当たったものに「ChangeImage」が付いているかチェック！
                    if (targetCard != null)
                    {
                        targetCard.ImageChange(targetCard.mySpriteIndex);
                        if(expectedNumber != targetCard.mySpriteIndex)
                        {
                            score[0] = 90;
                        }
                        
                        clickCount[targetCard.mySpriteIndex] += 1;
                        if (clickCount[targetCard.mySpriteIndex] >= 2)
                        {
                            score[1] = 80;
                        }
                        if(targetCard.mySpriteIndex == 4)
                        {
                            FinalScore();
                            displayScript.DisplayCanvas(finalScore);
                            canClick = false; // ここでクリックを止めるのも大正解です！
                        }
                        expectedNumber += 1;
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
        SaveManager.SaveScore(finalScore,0);
    }
}