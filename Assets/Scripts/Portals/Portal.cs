using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private int idNextLevel;
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UnlockLevel();
            SceneManager.LoadScene(idNextLevel);

        }
    }  
    public void UnlockLevel()
    {
        int currentLevel = GlobalControl.Instance.GetLastSavedScene();//SceneManager.GetActiveScene().buildIndex;
        print($"Portal,UnlockLevel{currentLevel}");
        
        if (currentLevel>=PlayerPrefs.GetInt("Levels"))
        {
            PlayerPrefs.SetInt("Levels", currentLevel + 1);
        }
    }
}
