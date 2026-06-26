using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Score200 : MonoBehaviour
{
    [SerializeField] CardClickJudge ClickJudgeScript;
    int firstIndex = -1;
    int secondIndex = -1;

    bool a;
    [SerializeField] int[] cardlist;
    [SerializeField] int[] rightlist;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(BubbleSort());
    }
    IEnumerator BubbleSort()
    {
        int[] examineList = cardlist;
        for(int i = 0; i < examineList.Length-1; i++)
        {
            for(int j = 0; j < examineList.Length - 1; j++)
            {
                
                if (examineList[j] > examineList[j + 1])
                {
                    yield return StartCoroutine(WaitCardClick());
                    firstIndex = ClickJudgeScript.cardIndex;
                    ClickJudgeScript.IndexReset();
                    yield return StartCoroutine(WaitCardClick());
                    secondIndex = ClickJudgeScript.cardIndex;
                    ClickJudgeScript.IndexReset();
                    if((firstIndex == j||firstIndex == j+1)&&(secondIndex == j||secondIndex == j+1))
                    {
                        (examineList[j],examineList[j+1]) = (examineList[j+1],examineList[j]);
                    }
                }
                else
                {
                    continue;
                }
            }   
        }
        bool isClear = ClearCheck(examineList);
        if (isClear)
        {
            Debug.Log("Clear");
        }
    }

    bool ClearCheck(int[] list)
    {
        for(int i = 0; i < rightlist.Length; i++)
        {
            if (rightlist[i] != list[i])
            {
                return false;
            }
        }
        return true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitCardClick()
    {
        yield return new WaitUntil(() => ClickJudgeScript.cardIndex != -1);
    }
}
