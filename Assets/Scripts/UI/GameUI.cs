using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject[] objHearts;
    [SerializeField] private GameObject panelGameOver;
    [SerializeField] private GameObject panelTheEnd;
    [SerializeField] private GameObject panelPause;
    [SerializeField] private GameObject panelSettingMusic;


    [SerializeField] private TextMeshProUGUI textGold;
    [SerializeField] private TextMeshProUGUI textFood;
    [SerializeField] private TextMeshProUGUI textBluster;
    [SerializeField] private int idLevel;
    private int heart = 3;

    void Start()
    {
        print("StartUI");
        heart = GlobalControl.Instance.heart;
    }

    public void SaveUI()
    {
        GlobalControl.Instance.heart = heart;
    }

    public void AddHeart()
    {

        heart++;
        SaveUI();
        PlayerPrefs.SetInt("Heart", heart);
        UpdateHeart();
    }

    public void RemuveHeart()
    {
        heart--;
        SaveUI();
        PlayerPrefs.SetInt("Heart", heart);
        UpdateHeart();
    }

    void UpdateHeart()
    {
        for (int i = 0; i < 3; i++)
        {
            if (heart > i)
            {

                objHearts[i].SetActive(true);
            }
            else
            {

                objHearts[i].SetActive(false);
            }
        }
    }

    public void SetCountLifeUI(int life)
    {
        heart = life;
        UpdateHeart();
    }

    public void SetCountGoldUI(int countGold)
    {
        textGold.text = countGold.ToString();

    }

    public void SetCountFoodUI(int countFood)
    {
        textFood.text = countFood.ToString();

    }

    public void SetCountBlusterUI(int countBluster)
    {
        textBluster.text = countBluster.ToString();
    }

    public void PauseOn()
    {
        Time.timeScale = 0.00001f;
        panelPause.SetActive(true);
    }

    public void PauseOff()
    {
        Time.timeScale = 1;
        panelPause.SetActive(false);
    }

    public void GameOver()
    {
        print("GameOverDestroy");
        panelGameOver.SetActive(true);
    }

    public void TheEnd()
    {
        print("TheEnd");
        panelTheEnd.SetActive(true);
    }
    public void NewGame()
    {
        print("StartGame");
        SceneManager.LoadScene(1);
        GlobalControl.Instance.ResetData();
        Time.timeScale = 1;
    }
    public void Restart()
    {
        print("Restart");
        int sceneIndex = GlobalControl.Instance.GetLastSavedScene();     //SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
        GlobalControl.Instance.ResetData();
        Time.timeScale = 1;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Menu()
    {

        SceneManager.LoadScene(0);

    }
    public void Settings()
    {
        panelSettingMusic.SetActive(true);
    }
}
