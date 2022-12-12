using UnityEngine;

public class Bonus: MonoBehaviour
{
    public GameObject cube;
    public GameObject objectBonus;

    private void OnCollisionEnter2D(Collision2D collision)
    {        
        if (collision.gameObject.tag == "Player")
        {
            NewObject();
            
        Destroy(gameObject);
        }
    }

    void NewObject()
    {
        
            GameObject newobjectBonus = Instantiate(objectBonus);
            newobjectBonus.transform.position = new Vector3(cube.transform.position.x, cube.transform.position.y + 2.0f, 0);
        

    }

}

