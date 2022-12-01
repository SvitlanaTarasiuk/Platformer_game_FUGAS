using UnityEngine;

public class CameraController : MonoBehaviour
{          
    [SerializeField] private float sensetyCam = 5;      //швидкість переміщення
    [SerializeField] private Transform player;          //об'єкт-ціль
    //Transform player;
    Transform cameraTransform;                          //камера
    Vector3 deltaPosCam;                                //зміщення
    Vector3 target;                             //ціль
    //private float pointX2 = -4f;
    [SerializeField] private float pointX1 = 18f;
    [SerializeField] private float pointY = -0.6f;

    //void Start()
    //public void InitCam(Transform playerTransform)
         void Start()
    {     
        //Transform  playerTransform = SingletoneHero._singletoneHero.transform;
       // player = playerTransform;
        player.position = GameObject.Find("StartPoint").transform.position;
        cameraTransform = transform;
        deltaPosCam = cameraTransform.position - player.position;
        deltaPosCam.z = -10;
        print("Start_Camera");
    }
    void FixedUpdate()
    {
         
        //if (player.position.x > pointX2 && transform.position.x < pointX1)
        if (player.position.x < pointX1)
        {
            target = player.transform.position + deltaPosCam;
            target.y = pointY;
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, target, Time.deltaTime * sensetyCam);
        }
    }
}
