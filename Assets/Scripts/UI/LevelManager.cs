using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    private int levelUnlock;
    public Button[] buttonsLevel; 
    void Start()
    {
        int saveLevel = GlobalControl.Instance.GetLastSavedScene();
        PlayerPrefs.SetInt("Levels", saveLevel);
        levelUnlock = PlayerPrefs.GetInt("Levels");
        print("Start LevelManager");
        print(levelUnlock);
        
        for (int i=0; i<buttonsLevel.Length; i++)
        {
            buttonsLevel[i].interactable = false;
        }
        for(int i=0; i<levelUnlock; i++)
        {
            buttonsLevel[i].interactable = true;
        }
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
        GlobalControl.Instance.ResetData();//скидання даних
        Time.timeScale = 1;
    }
}
