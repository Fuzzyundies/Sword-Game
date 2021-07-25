using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Dropdown resolutionDropdown;

    private Resolution[] availableResolutions;



    // Start is called before the first frame update
    void Start()
    {
        availableResolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> resolutions = new List<string>();

        int currentResolutionIndex = 0;

        foreach(Resolution resolution in availableResolutions)
        {
            resolutions.Add(resolution.width + " x " + resolution.height);

            if (resolution.width == Screen.currentResolution.width && resolution.height == Screen.currentResolution.height)
            {
                //currentResolutionIndex = availableResolutions.GetValue()
            }
        }

        resolutionDropdown.AddOptions(resolutions);
    }

   public void SetVolume(float volume)
    {
        mixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
