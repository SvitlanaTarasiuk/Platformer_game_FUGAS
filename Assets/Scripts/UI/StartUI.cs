using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    [SerializeField] private Button buttonContinue; 
    
   public void NewGame()
    {     
        print("StartGame");
        SceneManager.LoadScene(1);
        GlobalControl.Instance.ResetData();
        Time.timeScale = 1;
    }
    public void Continue()
    {
        print("Continue");
        int lifeHero = PlayerPrefs.GetInt("Life");                                  //GlobalControl.Instance.life;
        int lastScene = GlobalControl.Instance.GetLastSavedScene();

        if (lifeHero > 0)
        {
            buttonContinue.interactable = true;
            SceneManager.LoadScene(lastScene);
            Time.timeScale = 1;
        }
        else
        {
            buttonContinue.interactable = false;
        }
    }
 
    public void ExitGame()
    {
        Application.Quit();
    }
  
    //public void Scene1()
    //{
    //    SceneManager.LoadScene(1);
    //    GlobalControl.Instance.ResetData();
    //    Time.timeScale = 1;
    //}
    //public void Scene2()
    //{
    //    SceneManager.LoadScene(2);
    //    GlobalControl.Instance.ResetData();
    //    Time.timeScale = 1;
    //}
    //public void Scene3()
    //{
    //    SceneManager.LoadScene(3);
    //    GlobalControl.Instance.ResetData();
    //    Time.timeScale = 1;
    //}
    //public void Scene4()
    //{
    //    SceneManager.LoadScene(4);
    //    GlobalControl.Instance.ResetData();
    //    Time.timeScale = 1;
    //}
    //public void Scene5()
    //{
    //    SceneManager.LoadScene(5);
    //    GlobalControl.Instance.ResetData();
    //    Time.timeScale = 1;
    //}
    public void Menu()
    {
        SceneManager.LoadScene(7);
    }
    public void Settings()
    {
        SceneManager.LoadScene(8);
    }
    public void Levels()
    {
        SceneManager.LoadScene(9);
    }
    public void Rekords()
    {
        SceneManager.LoadScene(10);
    }
}
