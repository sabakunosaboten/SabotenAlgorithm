using UnityEngine;
using System.Collections.Generic;
using System.IO; // ファイルの読み書きに必須！

// ① JSONに変換するための「データの箱（設計図）」
[System.Serializable]
public class SaveData
{
    public  int[] finalScore={-1,-1} ; // 初期値は -1 にしておきます
}

// ② どこからでも呼び出せる便利クラス（staticクラス）
public static class SaveManager
{
    // セーブファイルの保存先（スマホやPCでも安全な保存場所を自動設定してくれます）
    public static string filePath = Application.persistentDataPath + "/savedata.json";

    // ＝＝＝ セーブする処理 ＝＝＝
    public static void SaveScore(int scoreToSave,int stageNumber)
    {
        SaveData data = new SaveData();
        data.finalScore[stageNumber] = scoreToSave;

        // 箱をJSON文字に変換して、ファイルに書き込む
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, json);

        Debug.Log("セーブ完了！保存先: " + filePath);
    }

    // ＝＝＝ ロードする処理 ＝＝＝
    public static int LoadScore(int stageNumber)
    {
        // もしセーブファイルが存在したら
        if (File.Exists(filePath))
        {
            // JSON文字を読み込んで、箱に戻す
            string json = File.ReadAllText(filePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            
            Debug.Log("ロード成功！スコア: " + data.finalScore);
            return data.finalScore[stageNumber];
        }

        // ファイルがまだ無い（初回プレイ）場合は -1 を返す
        Debug.Log("セーブデータがありません。初回プレイです。");
        return -1; 
    }
}