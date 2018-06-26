using UnityEngine.SceneManagement;
using UnityEngine;
//using UnityEditor;

public class GameStart : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Rachel Story");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    
    public void openPersonalGithub()
    {
        Application.OpenURL("https://github.com/Sindiewen");
    }
    
    public void openPersonalWebsite()
    {
        Application.OpenURL("http://sindiewen.tech/");
    }

    public void exitGame()
    {
//#if UNITY_EDITOR
//        EditorApplication.isPlaying = false;
//#else
        Application.Quit();
//#endif
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.X))
        {
            exitGame();
        }
    }
}
