using UnityEngine;

public class TheEnd : MonoBehaviour
{
    [SerializeField] private GameUI gameUI;
    //private int keyForTheEnd=1;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            Time.timeScale = 0;
            gameUI.TheEnd();

            /*Hero heroPlayer = collision.GetComponent<Hero>();
            if (heroPlayer.Key == keyForTheEnd)
            {
                Time.timeScale = 0;
                gameUI.TheEnd();
                
            }*/
        }
    }

}

