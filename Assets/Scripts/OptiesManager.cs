using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptiesManager : MonoBehaviour
{
    private Toggle fullscreenToggle;

    private void Awake()
    {
        fullscreenToggle = FindObjectOfType<Toggle>().GetComponent<Toggle>();

        VerkrijgSettings();
    }
    public void SlaSettingsOp()
    {
        if(fullscreenToggle.isOn == true)
        {
            PlayerPrefs.SetInt("fullscreenOn", 1);
        }
        else
        {
            PlayerPrefs.SetInt("fullscreenOn", 0);
        }
        
    }
    public void VerkrijgSettings()
    {
        int fullscreenInt = PlayerPrefs.GetInt("fullscreenOn");

        if(fullscreenInt == 0)
        {
            fullscreenToggle.isOn = false;
        }
        else
        {
            fullscreenToggle.isOn = true;
        }
    }

    public void VeranderFullscreenModus()
    {
        if (!fullscreenToggle.isOn)
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
            Debug.Log("Windowed");
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
            Debug.Log("Fullscreen");
        }
    }
}
