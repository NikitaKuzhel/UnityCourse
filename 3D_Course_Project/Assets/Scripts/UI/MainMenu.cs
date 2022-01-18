using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void SetVolume(bool volume)
    {
        if (volume)
        {
            AudioListener.volume = 1;
            Debug.Log(volume);
        }
        else
        {
            AudioListener.volume = 0;
            Debug.Log(volume);
        }
    }
}
