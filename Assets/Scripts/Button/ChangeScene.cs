using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    string[] sceneName = {"101","102"};
    public void StageSelectToGame_Button(int index)
    {
        SceneManager.LoadScene(sceneName[index]);
    }
    public void ToStage_Button()
    {
        SceneManager.LoadScene("StageSlectScene");
    }

    public void Retry_Button()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
