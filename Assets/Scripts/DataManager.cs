using UnityEngine;
using System.Collections.Generic;
using System.IO; // ファイルの読み書きに必須！

// ① JSONに変換するための「データの箱（設計図）」
[System.Serializable]
public class SaveData
{
    public  string[,] saveScore=new string [2,2]{{"-1","-1"},{"ellor","ellor"}} ; // 初期値は -1 にしておきます
}

// ② どこからでも呼び出せる便利クラス（staticクラス）
public static class SaveManager
{
    // セーブファイルの保存先（スマホやPCでも安全な保存場所を自動設定してくれます）
    public static string filePath = Application.persistentDataPath + "/savedata.json";

    // ＝＝＝ セーブする処理 ＝＝＝
    public static void SaveScore(string scoreToSave,int row,int column)
    {
        SaveData data = new SaveData();
        data.saveScore[row,column] = scoreToSave;

        // 箱をJSON文字に変換して、ファイルに書き込む
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, json);

        Debug.Log("セーブ完了！保存先: " + filePath);
    }

    // ＝＝＝ ロードする処理 ＝＝＝
    public static SaveData GetAllSaveData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            // JSONからSaveDataクラスの形に復元して返す
            return JsonUtility.FromJson<SaveData>(json);
        }

        // セーブファイルが無い場合は、初期値（全部-1）の入った新しい箱を返す
        return new SaveData(); 
    }
}