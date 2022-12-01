using UnityEngine;
using TMPro;


public class GlobalControl: MonoBehaviour
{
    public int coins=0;
    public int life=5;
    public int diamond=0;
    public int silver=0;
    public int heart=5;
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
        coins = 0;
        life = 5;
        diamond = 0;
        silver = 0;
        heart = 5;
        
    }

}


//pub  lic void SavePlayer()
//GlobalControl.Instantiate.coins = coins;
//...
//void Start(0
//coins = GlobalControl.Instantiate.coins;
//...

