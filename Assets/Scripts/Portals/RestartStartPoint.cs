using UnityEngine;

public class RestartStartPoint : MonoBehaviour
{
   [SerializeField] private Transform startPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.transform.position = startPoint.position;
        }
    }
}