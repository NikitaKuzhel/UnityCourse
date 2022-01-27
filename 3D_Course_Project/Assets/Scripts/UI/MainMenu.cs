using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] _character;
    [SerializeField] private int _selectedCharacter = 0;

    public void PlayGame()
    {
        BlueTeamScore.scoreValue = 0;
        RedTeamScore.scoreValue = 0;
        SceneManager.LoadScene("MainScene");
    }

    public void NextCharacter()
    {
        _character[_selectedCharacter].SetActive(false);
        _selectedCharacter = (_selectedCharacter + 1) % _character.Length;
        _character[_selectedCharacter].SetActive(true);
    }

    public void PreviousCharacter()
    {
        _character[_selectedCharacter].SetActive(false);
        _selectedCharacter--;
        if (_selectedCharacter < 0)
        {
            _selectedCharacter += _character.Length;
        }
        _character[_selectedCharacter].SetActive(true);
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
