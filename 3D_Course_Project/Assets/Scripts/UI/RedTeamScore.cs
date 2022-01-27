using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedTeamScore : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private int _scoreToWin;
    public static int scoreValue = 0;

    void Start()
    {
        
    }

    void Update()
    {
        _scoreText.text = scoreValue.ToString();

        if (RedTeamScore.scoreValue == _scoreToWin)
        {
            _gameManager.RedTeamWon();
            Debug.Log("Red Team Won");
        }
    }
}
