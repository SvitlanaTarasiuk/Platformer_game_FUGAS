using UnityEngine;

public class Silver : MonoBehaviour
{
  
    private void OnBecameInvisible()
    {
        Destroy(gameObject);  
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);    
    }
}
