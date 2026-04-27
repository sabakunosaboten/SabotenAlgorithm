using UnityEngine;
using UnityEngine.SceneManagement;
public class StageSelectToGame : MonoBehaviour
{
    public void StageSelectToGame_Button()
    {
        SceneManager.LoadScene("101");
    }
}
