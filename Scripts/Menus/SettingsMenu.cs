using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;

    Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height; //Find the width and height of our available resolutions
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) //Correct resolution of our PC
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex]; //Resolution we want to select
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen); //Show the selected resolution
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", Mathf.Log10 (volume) * 20); //Adjust the volume of the game and make it smooth while adjusting to make it louder or not
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex); //Adjust the graphics of the game
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen; //Put fullscreen or not
    }
}
