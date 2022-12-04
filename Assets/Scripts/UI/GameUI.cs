using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject[] objHearts;
    [SerializeField] private GameObject panelGameOver;
    [SerializeField] private GameObject panelTheEnd;
    [SerializeField] private GameObject panelSetting;

    [SerializeField] private TextMeshProUGUI textGold;
    [SerializeField] private TextMeshProUGUI textFood;
    [SerializeField] private TextMeshProUGUI textWeapon;
    [SerializeField] private int idLevel;
    private int heart = 3;

   void Start()
    {
        print("StartUI");
        heart = GlobalControl.Instantiate.heart;
   
    }
    public void SaveUI()
    {
        GlobalControl.Instantiate.heart = heart;

    }
    public void AddHeart()
    {

        heart++;
        SaveUI();
        UpdateHeart();
    }
    public void RemuveHeart()
    {   
        heart--;
       print($"{heart}-heart");
        SaveUI();
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
    public void SetCountWeaponUI(int countWeapon)
    {
        textWeapon.text = countWeapon.ToString();
    }
    public void PauseOn()
    {
        Time.timeScale = 0.00001f;
        panelSetting.SetActive(true);
    }
    public void PauseOff()
    {
        Time.timeScale = 1;
        panelSetting.SetActive(false);
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
        print("NewGame");

        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        GlobalControl.Instantiate.ResetData();
        //SingletoneHero._singletoneHero.GetComponent<Hero>().NewStartParametr();

    }
    /*public void Restart()
    {
        print("Restart");
        SceneManager.LoadScene(idLevel);
        Time.timeScale = 1;      
    }*/

}
