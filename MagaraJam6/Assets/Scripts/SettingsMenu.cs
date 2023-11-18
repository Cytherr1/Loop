using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] AudioMixer amix;
    [SerializeField] Slider MusicSlider;
    [SerializeField] Slider MasterSlider;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("MusicVOlume") && !PlayerPrefs.HasKey("MasterVolume"))
        {
            PlayerPrefs.SetFloat("MasterVolume", 1);
            PlayerPrefs.SetFloat("MusicVolume", 0.5f);
            Load();
        }
        else
        {
            Load();
        }
        
    }

    public void SetMasterVolume(float volume)
    {
        PlayerPrefs.SetFloat("MasterVolume", volume);
        amix.SetFloat("MasterVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("MusicVolume", volume);
        amix.SetFloat("MusicVolume", volume);
    }

    public void Load()
    {
        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        MasterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
    }
}
