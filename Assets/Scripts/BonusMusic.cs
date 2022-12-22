using UnityEngine;

public class BonusMusic : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip audioClip;
   // public bool isPlaying = false;
    //public bool isPaused = false;
    //private List<string> musicList = new List<string>();
    //private float musicVolume;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //audioClip = GetComponent<AudioClip>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            audioSource.PlayOneShot(audioClip); 
            //MusicActive();
            Destroy(gameObject);
        }
    }
    public void MusicActive()
    {
        //isPlaying = true;
        audioSource.PlayOneShot(audioClip);
    }
}
