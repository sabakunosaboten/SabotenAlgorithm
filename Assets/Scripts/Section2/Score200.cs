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
    bool BSrefuse = false;
    bool SSfinish = false;
    bool SSrefuse = false;
    bool ISfinish = false;
    bool CSfinifh = false;
    
    bool HSfinish = false;
    bool HSrefuse = false;
    int BSIndex = 0;
    int HSIndex = 6;
    List<int> examineListIS;
    [SerializeField] List<int> cardlist;
    List<int> examineListSS;
    List<int> examineListBS;
    List<int> examineListCS;
    List<int> examineListHS;
    List<int> heapList;
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
        examineListCS = new List<int>(cardlist);
        examineListHS = new List<int>(cardlist);
        heapList = new List<int>(cardlist);
        int i=0;
        while (true)
        {
            yield return new WaitUntil(() => ClickJudgeScript.cardIndex != -1);
            int fIndex = ClickJudgeScript.cardIndex;
            ClickJudgeScript.IndexReset();
            yield return new WaitUntil(() => ClickJudgeScript.cardIndex != -1);
            if (ClickJudgeScript.reset == true)
            {
                fIndex = ClickJudgeScript.cardIndex;
                ClickJudgeScript.IndexReset();
                ClickJudgeScript.reset = false;
                yield return new WaitUntil(() => ClickJudgeScript.cardIndex != -1);
            }
            int sIndex = ClickJudgeScript.cardIndex;
            ClickJudgeScript.IndexReset();
            firstIndex = Math.Min(fIndex,sIndex);
            secondIndex = Math.Max(fIndex,sIndex);

            if (BSfinish == false && BSrefuse == false )
            {
                BubbleSort();
            }
            if(SSfinish == false && SSrefuse == false)
            {
                SelectionSort(i);
            }
            if(HSfinish == false && HSrefuse == false)
            {
                HeapSort();
            }
            if(BSfinish == false && SSfinish == false && HSfinish == false && CSfinifh == false)
            {
                Debug.Log(i);
                Bogosort();
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
                BSrefuse = true;
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
            SSrefuse = true;
        }
        bool isClear = ClearCheck(examineListSS);
        if (isClear)
        {
            SSfinish = true;
            clearSortName = "せんたくソート";
            RDcs.DisplayCanvas(clearSortName);
            SaveManager.SaveScore(clearSortName,1,1);
            Debug.Log("SelectionSort");
        }
    }
    void HeapSort()
    {
        if (HeapCheck(heapList) == true)
        {
            for(int i=0;i<heapList.Count;i++)
            {
                //Debug.Log(heapList[i]);
            }
            if(firstIndex != 0 && secondIndex != HSIndex)
            {
                HSrefuse = true;
            }
            else
            {
                (examineListHS[0],examineListHS[HSIndex]) = (examineListHS[HSIndex],examineListHS[0]);
                (heapList[0],heapList[HSIndex]) = (heapList[HSIndex],heapList[0]);
                heapList.RemoveAt(HSIndex);
                HSIndex--;
            }
        }
        else
        {
            if (examineListHS[firstIndex] > examineListHS[secondIndex])
            {
                HSrefuse = true;
            }
            else
            {
                (examineListHS[firstIndex],examineListHS[secondIndex]) = (examineListHS[secondIndex],examineListHS[firstIndex]);
                (heapList[firstIndex],heapList[secondIndex]) = (heapList[secondIndex],heapList[firstIndex]);
            }
        }
        bool isClear = ClearCheck(examineListHS);
        if(isClear)
        {
            HSfinish = true;
            clearSortName = "ヒープソート";
            RDcs.DisplayCanvas(clearSortName);
            SaveManager.SaveScore(clearSortName,1,2);
            Debug.Log("HeapSort");
        }
         
    }
    
    bool HeapCheck(List<int> list)
    {
        for(int i = 0; i < list.Count/2 ; i++)
        {
            int max = -1;
            if(list.Count%2 != 0)
            {
                max = Math.Max(list[i], Math.Max(list[2*i + 1], list[2*i + 2]));  
            }
            else
            {
                if(i == list.Count/2 - 1 && list.Count%2 == 0)
                {
                    max = Math.Max(list[i], list[2*i + 1]);
                }
                else
                {
                    max = Math.Max(list[i], Math.Max(list[2*i + 1], list[2*i + 2]));
                }
            }

            if (max != list[i])
            {
                return false;
            }
        }
        return true;
    }

    void Bogosort()
    {
        (examineListCS[firstIndex],examineListCS[secondIndex]) = (examineListCS[secondIndex],examineListCS[firstIndex]);
        bool isClear = ClearCheck(examineListCS);
        if (isClear)
        {
            CSfinifh = true;
            clearSortName = "ボゴソート";
            RDcs.DisplayCanvas(clearSortName);
            SaveManager.SaveScore(clearSortName,1,3);
            Debug.Log("BogoSort");
        }
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
