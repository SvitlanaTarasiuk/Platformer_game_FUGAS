using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    [SerializeField] private Button buttonContinue;
    [SerializeField] private GameObject panelSettingsMusic;
    [SerializeField] private GameObject panelMenu;
    [SerializeField] private GameObject panelLevels;

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
  
    public void Menu()
    {
        panelMenu.SetActive(true);
        //SceneManager.LoadScene(7);
    }
    public void Settings()
    {
        panelSettingsMusic.SetActive(true);
        //SceneManager.LoadScene(8);
    }
    public void Levels()
    {
        panelLevels.SetActive(true);
        //SceneManager.LoadScene(9);

    }
    //public void Rekords()
    //{
    //    SceneManager.LoadScene(10);
    //}
}
