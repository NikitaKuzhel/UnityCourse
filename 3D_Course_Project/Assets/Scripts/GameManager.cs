using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _blueTeamWon;
    [SerializeField] GameObject _redTeamWon;
    [SerializeField] private float _delayTime = 2f;

    public void BlueTeamWon()
    {
        BlueTeamScore.scoreValue = 0;
        RedTeamScore.scoreValue = 0;
        _blueTeamWon.SetActive(true);

        StartCoroutine(EndGame());
    }

    public void RedTeamWon()
    {
        BlueTeamScore.scoreValue = 0;
        RedTeamScore.scoreValue = 0;
        _redTeamWon.SetActive(true);

        StartCoroutine(EndGame());
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(_delayTime);
        SceneManager.LoadScene("MainMenu");
    }
}
