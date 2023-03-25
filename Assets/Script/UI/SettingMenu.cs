using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
   
    [SerializeField] GameObject Main;
    [SerializeField] GameObject settingmenu;

    public AudioMixer audioMixer;
    public TMPro.TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;
    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        
        List<string> options = new List<string>();
        for(int i = 0; i < resolutions.Length; i++)
        {
           string option =resolutions[i].width + " X " + resolutions[i].height;
            options.Add(option);

        }
        resolutionDropdown.AddOptions(options);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetVolume(float value)
    {
        audioMixer.SetFloat("Volume",value);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width,resolution.height,Screen.fullScreen);
    }
    public void CloseMenu()
    {
        Time.timeScale = 1.0f;
        settingmenu.SetActive(false);
        Main.SetActive(true);
    }
    
}
