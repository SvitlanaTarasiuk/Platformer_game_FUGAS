using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class GlobalControl : MonoBehaviour
{
    public int gold = 0;
    public int life = 3;
    public int food = 0;
    public int blusterCount = 0;
    public int heart = 3;
    public int currentSceneIndex;

    public static GlobalControl Instance;


    void Awake()
    {
        print("AwakeGlobalControl");
        if (Instance == null)
        {
            print("DontDestroy");
            DontDestroyOnLoad(gameObject);
            Instance = this;
            LoadAllData();
        }
        else if (Instance != this)
        {
            print("Destroy");
            Destroy(gameObject);
        }
    }
    private void LoadAllData()
    { 
        gold = PlayerPrefs.GetInt("Gold",0);
        life = PlayerPrefs.GetInt("Life", 3);
        food = PlayerPrefs.GetInt("Food", 0);
        blusterCount = PlayerPrefs.GetInt("BlusterCount", 0);
        heart = PlayerPrefs.GetInt("Heart", 3);
    }
    public void ResetData()
    {
        print("ResetData");
        gold = 0;
        life = 3;
        food = 0;
        blusterCount = 0;
        heart = 3;
        PlayerPrefs.SetInt("Gold", gold);
        PlayerPrefs.SetInt("Life", life);
        PlayerPrefs.SetInt("Food", food);
        PlayerPrefs.SetInt("BlusterCount", blusterCount);
        PlayerPrefs.SetInt("Heart", heart);   
    }
    public void SaveScene()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SceneIndex", currentSceneIndex);
    }
    public int GetLastSavedScene()
    {
        currentSceneIndex = PlayerPrefs.GetInt("SceneIndex");
        return currentSceneIndex;
    }
}


//pub  lic void SavePlayer()
//GlobalControl.Instantiate.coins = coins;
//...
//void Start(0
//coins = GlobalControl.Instantiate.coins;
//...
//PlayerPrefs.SetInt("Gold", gold);
//PlayerPrefs.GetInt("Gold",0);
