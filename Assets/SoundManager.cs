using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip clickClip;

    private void Awake()
    {
        if( instance != null)
        {
            if(SceneManager.GetActiveScene().buildIndex == 0)
            {
                Destroy(instance.gameObject);
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(instance. gameObject );
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
            instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void PlaySound(AudioClip clip)
    {
        musicSource.PlayOneShot(clip);
    }
    public void PlayMusic(AudioClip clip)
    {
        soundSource.Play();
    }
    public void SetSoundVolume()
    {
        float volumebase = PlayerPrefs.GetFloat("SoundVolume", 0);
        volumebase += 0.2f;
        if(volumebase > 1) {
            volumebase = 0;
        }
        PlayerPrefs.SetFloat("SoundVolume", volumebase);
        PlayerPrefs.Save();
        soundSource.volume = volumebase;
    }
    public void SetMusicVolume()
    {
        float volumebase = PlayerPrefs.GetFloat("MusicVolume", 0);
        volumebase += 0.2f;
        if (volumebase > 1)
        {
            volumebase = 0;
        }
        PlayerPrefs.SetFloat("MusicVolume", volumebase);
        PlayerPrefs.Save();
        musicSource.volume = volumebase;
    }
    public void ClickButton()
    {
        soundSource.PlayOneShot(clickClip);
    }
}
