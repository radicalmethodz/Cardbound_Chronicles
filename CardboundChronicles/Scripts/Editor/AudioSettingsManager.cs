using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace CardboundChronicles

public class AudioSettingsManager : MonoBehaviour
{
    public GameObject musicSlider;
    public GameObject mobileSFXtext;
    public GameObject mobileMusictext;
    public AudioSource musicSource;
    public AudioSource sfxSource;

    public void Start()
    {
        // Load audio settings from PlayerPrefs
        musicSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MusicVolume");
        musicSource.volume = PlayerPrefs.GetFloat("MusicVolume");
        sfxSource.volume = PlayerPrefs.GetFloat("SFXVolume");
    }

    public void MusicSlider()
    {
        float volume = musicSlider.GetComponent<Slider>().value;
        PlayerPrefs.SetFloat("MusicVolume", volume);
        musicSource.volume = volume;
    }

    public void UpdateSFXVolume()
    {
        sfxSource.volume = PlayerPrefs.GetFloat("SFXVolume");
    }

    public void MobileSFXMute()
    {
        if (PlayerPrefs.GetInt("Mobile_MuteSfx") == 0)
        {
            PlayerPrefs.SetInt("Mobile_MuteSfx", 1);
            mobileSFXtext.GetComponent<TMP_Text>().text = "on";
        }
        else if (PlayerPrefs.GetInt("Mobile_MuteSfx") == 1)
        {
            PlayerPrefs.SetInt("Mobile_MuteSfx", 0);
            mobileSFXtext.GetComponent<TMP_Text>().text = "off";
        }
    }

    public void MobileMusicMute()
    {
        if (PlayerPrefs.GetInt("Mobile_MuteMusic") == 0)
        {
            PlayerPrefs.SetInt("Mobile_MuteMusic", 1);
            mobileMusictext.GetComponent<TMP_Text>().text = "on";
        }
        else if (PlayerPrefs.GetInt("Mobile_MuteMusic") == 1)
        {
            PlayerPrefs.SetInt("Mobile_MuteMusic", 0);
            mobileMusictext.GetComponent<TMP_Text>().text = "off";
        }
    }
}