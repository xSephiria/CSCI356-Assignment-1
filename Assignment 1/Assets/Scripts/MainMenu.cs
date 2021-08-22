using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Hellmade.Sound;

public class MainMenu : MonoBehaviour
{
    public Canvas MainMenuCanvas;
    public Canvas SettingsCanvas;
    public Image fadingEff;
    public Slider BGM_Slider;
    public Slider SFX_Slider;
    public AudioClip BGM;
    public AudioClip SFX;

    
    // Start is called before the first frame update
    void Start()
    {
        // Main menu canvas check
        if (MainMenuCanvas != null)
        {
            MainMenuCanvas.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("Main Menu Canvas is not assigned!");
        }

        // settings canvas check
        if (SettingsCanvas != null)
        {
            SettingsCanvas.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Settings Canvas is not assigned!");
        }

        // BGM defaults
        if (BGM_Slider != null)
        {
            BGM_Slider.value = EazySoundManager.GlobalMusicVolume;
        }
        else
        {
            Debug.LogError("BGM Slider is not assigned!");
        }
        if (BGM != null)
        {
            EazySoundManager.PlayMusic(BGM, EazySoundManager.GlobalSoundsVolume, true, false);
        }

        // SFX defaults
        if (SFX_Slider != null)
        {
            SFX_Slider.value = EazySoundManager.GlobalSoundsVolume;
        }
        else
        {
            Debug.LogError("SFX Slider is not assigned!");
        }
    }

    public void PlaySFX()
    {
        if (SFX != null)
        {
            EazySoundManager.PlaySound(SFX);
        }
    }

    public void changeBGMVolume(float vol)
    {
        EazySoundManager.GlobalMusicVolume = vol;
    }

    public void changeSFXVolume(float vol)
    {
        EazySoundManager.GlobalSoundsVolume = vol;
    }

    public void GoToGame(string sceneName)
    {
        StartCoroutine(fadingEff.GetComponent<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, sceneName));
    }

    public void FadingEffect()
    {
        StartCoroutine(fadingEff.GetComponent<SceneFader>().FadeEffect());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
