using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{

    public void NewGame()
    {
        print("StartGame");
        int loadScene = GlobalControl.Instance.GetLastSavedScene();
        SceneManager.LoadScene(loadScene);      
    }    
    public void ExitGame()
    {
        Application.Quit();
    }
    /*public void NewGame()
   {
       print("NewGame");
       SceneManager.LoadScene(1);
       Time.timeScale = 1;
       GlobalControl.Instance.ResetData();
       //SingletoneHero._singletoneHero.GetComponent<Hero>().NewStartParametr();
   }*/
    public void Restart()
    {
        print("Restart");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void Continue()
    {
        print("Restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void Scene1()
    {
        SceneManager.LoadScene(1);
        GlobalControl.Instance.ResetData();
        Time.timeScale = 1;
    }
    public void Scene2()
    {
        SceneManager.LoadScene(2);
        GlobalControl.Instance.ResetData();
        Time.timeScale = 1;
    }
    public void Scene3()
    {
        SceneManager.LoadScene(3);
        GlobalControl.Instance.ResetData();
        Time.timeScale = 1;
    }
    public void Scene4()
    {
        SceneManager.LoadScene(4);
        GlobalControl.Instance.ResetData();
        Time.timeScale = 1;
    }
    public void Scene5()
    {
        SceneManager.LoadScene(5);
        GlobalControl.Instance.ResetData();
        Time.timeScale = 1;
    }
    public void Menu()
    {
        SceneManager.LoadScene(1);
        //GlobalControl.Instance.ResetData();
        //Time.timeScale = 1;
    }
}
