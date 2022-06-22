using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeMenu : MonoBehaviour
{
    [SerializeField] AudioMixer musicMixer;
    [SerializeField] AudioMixer sfxMixer;

    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    private void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("Volume", 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("SfxVolume", 1f);
    }

    public void SetVolume(float volume)
    {
        musicMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20); //to change smoothly
        PlayerPrefs.SetFloat("Volume", volume);
    }
    public void SetSFXVolume(float volume)
    {
        sfxMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SfxVolume", volume);
    }
}
