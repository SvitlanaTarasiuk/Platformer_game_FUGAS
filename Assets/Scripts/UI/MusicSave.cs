//using UnityEngine;
//using UnityEngine.Audio;
//using UnityEngine.UI;


//public class MusicSave : MonoBehaviour
//{
//    public AudioSource audioSrc;
//    //public bool isOn;
//    public float musicVolume=1;

//    void Start()
//    {
//        musicVolume = PlayerPrefs.GetFloat("music");
//    }
//}


//    void Update()
//    {
//        if (PlayerPrefs.GetFloat("music") > 0)
//        {
//            isOn = true;
//            PlayerPrefs.SetFloat("music", 1);
//        }
//        else
//        {
//            isOn = false;
//            PlayerPrefs.SetFloat("music", 0);
//        }
//    }

//}


//public AudioMixer audioMixer;
//public AudioSource audioSrc;
//public bool isOn = true;
//public float musicVolume = 1;
//void Start()
//{
//    isOn = true;
//    musicVolume = PlayerPrefs.GetFloat("music", 1f);
//}
//public void SetVolume(float volume)
//{
//    audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
//    musicVolume = volume;
//    PlayerPrefs.SetFloat("music", musicVolume);
//    audioSrc.volume = musicVolume;
//}
//void Update()
//{
//    if (PlayerPrefs.GetFloat("music") > 0)
//    {
//        isOn = true;
//        PlayerPrefs.SetFloat("music", 1);
//    }
//    else
//    {
//        isOn = false;
//        PlayerPrefs.SetFloat("music", 0);
//    }
//}

//public void SetQuality(int qualityIndex)
//{
//    QualitySettings.SetQualityLevel(qualityIndex);
//}
//public void Sound()
//{
//    if (!isOn)
//    {
//        PlayerPrefs.SetFloat("music", 1);
//        audioSrc.enabled = true;
//    }
//    else if (isOn)
//    {
//        PlayerPrefs.SetFloat("music", 0);
//        audioSrc.enabled = false;
//    }
//    isOn = !isOn;
//    AudioListener.pause = !AudioListener.pause;

//}

//}

