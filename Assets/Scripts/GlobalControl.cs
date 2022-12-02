using UnityEngine;
using TMPro;


public class GlobalControl: MonoBehaviour
{
    public int gold =0;
    public int life =5;
    public int food =0;
    public int weapon =0;
    public int heart =5;
    //public TextMeshProUGUI textCoint;
    //public TextMeshProUGUI textDiamond;
    //public TextMeshProUGUI textSilver;
    //public GameObject[] objHearts;
    //public GameUI gameUI;

    public static new GlobalControl Instantiate;

    void Awake()
    {
        print("AwakeGlobalControl");
       if (Instantiate==null)
        {
            print("DontDestroy");
            DontDestroyOnLoad(gameObject);
            Instantiate = this;
        }
       else if(Instantiate !=this)
        {
            print("Destroy");
            Destroy(gameObject);
        }
    }
    public void ResetData()
    {
        print("ResetData");
        gold = 0;
        life = 5;
        food = 0;
        weapon = 0;
        heart = 5;
        
    }

}


//pub  lic void SavePlayer()
//GlobalControl.Instantiate.coins = coins;
//...
//void Start(0
//coins = GlobalControl.Instantiate.coins;
//...

