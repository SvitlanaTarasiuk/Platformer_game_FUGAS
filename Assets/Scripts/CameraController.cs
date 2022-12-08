using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float sensetyCam = 5f;      //швидкість переміщення
    [SerializeField] private Transform player;          //об'єкт-ціль
    [SerializeField] private float pointX1 = 60f;
    [SerializeField] private float pointY = -4f;
    Transform cameraTransform;                          //камера
    Vector3 deltaPosCam;                                //зміщення
    Vector3 target;                             //ціль
    //public Vector2 offset = new Vector2(2f,1f);


    void Start()
    {
        //offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        player.position = GameObject.Find("StartPoint").transform.position;
        cameraTransform = transform;
        deltaPosCam = cameraTransform.position - player.position;
        deltaPosCam.z = -10;
        print("Start_Camera");
    }
    void FixedUpdate()
    {

        if (player.position.x < pointX1)
        {
            target = player.transform.position + deltaPosCam;
            target.y = pointY;
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, target, Time.deltaTime * sensetyCam);
        }
    }
}
