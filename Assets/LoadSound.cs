using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSound : MonoBehaviour
{
    [SerializeField] private Button soundButton;
    [SerializeField] private Button musicButton;


    private void Start()
    {
        Load();
    }
    private void OnEnable()
    {
        Load();
    }

    private void Load()
    {

        SoundManager soundManager = FindObjectOfType<SoundManager>(); // Tìm SoundManager mới

        if (soundManager == null)
        {
            Debug.LogError("❌ Không tìm thấy SoundManager!");
            return;
        }

        if (soundButton != null)
        {
            soundButton.onClick.RemoveAllListeners();
            soundButton.onClick.AddListener(Sound);
            Debug.Log("✅ SoundButton đã cập nhật!");
        }

        if (musicButton != null)
        {
            musicButton.onClick.RemoveAllListeners();
            musicButton.onClick.AddListener(Music);
            Debug.Log("✅ MusicButton đã cập nhật!");
        }
    }
    private void Music()
    {
        SoundManager.instance.SetMusicVolume();
    }
    private void Sound()
    {
        SoundManager.instance.SetSoundVolume();
    }
}
