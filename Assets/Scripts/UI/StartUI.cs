using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{

    public void StartGame()
    {
        print("StartGame");
        SceneManager.LoadScene(1);      
    }    
    public void ExitGame()
    {
        Application.Quit();
    }
}
