
using UnityEngine;
using UnityEngine.SceneManagement;  // 引用 場景管理氣 API

public class Bigin : MonoBehaviour
{
    /// <summary>
    /// 重新遊戲
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene("3D場景");
    }

    /// <summary>
    /// 離開遊戲
    /// </summary>
    public void QuitGame()
    {
        // 應用程式.離開遊戲()
        Application.Quit();
    }
}
