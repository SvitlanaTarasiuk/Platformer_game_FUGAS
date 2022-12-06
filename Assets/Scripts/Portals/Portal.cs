using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private int idNextLevel;
    //private int keyForNextLevel = 1;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {     
            SceneManager.LoadScene(idNextLevel);
            //Hero heroPlayer = collision.GetComponent<Hero>();
            /*if (heroPlayer.Key == keyForNextLevel)
            {
                print("Portal");
                heroPlayer.Key -= 1;
                SceneManager.LoadScene(idNextLevel);
            }*/
        }
    }  
}
