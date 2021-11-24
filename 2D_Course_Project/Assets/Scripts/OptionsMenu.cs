using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public void SetMasterVolume (float volume)
    {
        Debug.Log($"Master volume level is {volume}");
    }

    public void SetMusicVolume (float volume)
    {
        Debug.Log($"Music volume level is {volume}");
    }

    public void OpenCredits ()
    {
        Debug.Log("Credits button was presed");
    }

    public void SetQualityLevel(int qualityIndex)
    {
        Debug.Log($"Quality level index is: {qualityIndex}");
    }

    public void SetScreenResolution(int resolutionIndex)
    {
        Debug.Log($"Resolution index is: {resolutionIndex}");
    }

    public void FullsreenMode(bool isActive)
    {
        Debug.Log(isActive);
    }
}
