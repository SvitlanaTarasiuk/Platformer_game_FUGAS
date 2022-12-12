using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.SearchService;

public class LevelManager : MonoBehaviour
{
    private int levelUnlock;
    public Button[] buttonsLevel; 
    void Start()
    {
        levelUnlock = PlayerPrefs.GetInt("Levels",1);
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
        GlobalControl.Instance.ResetData();
        Time.timeScale = 1;
    }
}
