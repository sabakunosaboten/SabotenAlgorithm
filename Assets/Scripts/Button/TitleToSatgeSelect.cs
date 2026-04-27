using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleToStageSlect : MonoBehaviour
{
    public void TitleToStage_Button()
    {
        SceneManager.LoadScene("StageSlectScene");
    }
}
