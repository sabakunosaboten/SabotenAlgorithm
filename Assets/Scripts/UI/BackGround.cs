using UnityEngine;
using UnityEngine.SceneManagement;

public class BackGround : MonoBehaviour
{
    static BackGround instance; // 自分を保存しておく静かな変数
    [SerializeField] Canvas myCanvas;

    void Awake()
    {
        // もしすでに古い自分がシーンに残っているなら
        if (instance != null)
        {
            Destroy(myCanvas); // 新しく生まれた方を即座に消去して終了
            return;
        }

        // 初めて生まれた自分なら、生き残る権利を与える
        instance = this;
        DontDestroyOnLoad(myCanvas);

        myCanvas = GetComponent<Canvas>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (myCanvas != null)
        {
            // 新しいシーンのメインカメラを探して割り当て直す
            myCanvas.worldCamera = Camera.main;
        }
    }

    void OnDestroy()
    {
        // 自分自身が破棄されるときだけイベントを解除する
        if (instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}