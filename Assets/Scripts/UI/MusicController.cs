using UnityEngine;
using UnityEngine.Audio; 

public class MusicController : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void Sound()
    {
        AudioListener.pause=!AudioListener.pause;
    }
}
