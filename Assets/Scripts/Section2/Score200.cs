using System;
using System.Linq;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using NUnit.Framework.Constraints;
using UnityEngine.Rendering;

public class Score200 : MonoBehaviour
{
    [SerializeField] CardClickJudge ClickJudgeScript;
    int firstIndex = -1;
    int secondIndex = -1;

    bool BSfinish = false;
    bool SSfinish = false;
    bool ISfinish = false;
    int BSIndex = 0;
    List<int> examineListIS;
    [SerializeField] List<int> cardlist;
    List<int> examineListSS;
    List<int> examineListBS;
    [SerializeField] int[] rightlist;
    
    string clearSortName;
    [SerializeField]ResultDisplay RDcs;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ClickGetIndex());
    }

    IEnumerator ClickGetIndex()
    {
        examineListBS = new List<int>(cardlist);
        examineListSS = new List<int>(cardlist);
        int i=0;
        while (true)
        {
            yield return new WaitUntil(() => ClickJudgeScript.cardIndex != -1);
            int fIndex = ClickJudgeScript.cardIndex;
            ClickJudgeScript.IndexReset();
            yield return new WaitUntil(() => ClickJudgeScript.cardIndex != -1);
            int sIndex = ClickJudgeScript.cardIndex;
            ClickJudgeScript.IndexReset();
            firstIndex = Math.Min(fIndex,sIndex);
            secondIndex = Math.Max(fIndex,sIndex);

            if (BSfinish == false)
            {
                BubbleSort();
            }
            if(SSfinish == false)
            {
                SelectionSort(i);
            }

            i++;
            if (i == 7)
            {
                i=0;
            }
        }
    }

    void BubbleSort()
    {
        for(int i=BSIndex;i<firstIndex; i++)
        {
            if (examineListBS[i] > examineListBS[i + 1])
            {
                BSfinish = true;
            }
        }
        if (examineListBS[firstIndex] > examineListBS[secondIndex])
        {
            if (firstIndex == secondIndex - 1)
            {
                (examineListBS[firstIndex],examineListBS[secondIndex]) = (examineListBS[secondIndex],examineListBS[firstIndex]);
                BSIndex = firstIndex;
            }
        }
        

        bool isClear = ClearCheck(examineListBS);
        if (isClear)
        {
            BSfinish = true;
            clearSortName = "バブルソート";
            RDcs.DisplayCanvas(clearSortName);
            SaveManager.SaveScore(clearSortName,1,0);
            Debug.Log("BubleSort");
        }
    }
    void SelectionSort(int i)
    {
        int minIndex = examineListSS.Skip(i).Select((v, idx) => new { v, Index = idx + i }).OrderBy(x => x.v).First().Index;
        if(firstIndex == i && secondIndex == minIndex)
        {
            (examineListSS[i],examineListSS[minIndex]) = (examineListSS[minIndex],examineListSS[i]);
        }
        else
        {
            SSfinish = true;
        }
        bool isClear = ClearCheck(examineListSS);
        if (isClear)
        {
            SSfinish = true;
            clearSortName = "選択ソート";
            RDcs.DisplayCanvas(clearSortName);
            SaveManager.SaveScore(clearSortName,1,1);
            Debug.Log("SelectionSort");
        }
    }
    void InsertSelection(int i)
    {
        
    }
    bool ClearCheck(List<int> list)
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
}
