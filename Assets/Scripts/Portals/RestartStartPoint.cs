using UnityEngine;

public class RestartStartPoint : MonoBehaviour
{
   [SerializeField] private Transform startPoint;
   [SerializeField] private Transform checkPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.transform.position.x < checkPoint.position.x)
            {
                collision.transform.position = startPoint.position;
            }

            else if (collision.transform.position.x > checkPoint.position.x)
            {
                collision.transform.position = checkPoint.position;
            }
        }
    }
}