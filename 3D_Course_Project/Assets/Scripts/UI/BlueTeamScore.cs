using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueTeamScore : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private GameManager _gameManager;
    public static int scoreValue = 0;

    void Start()
    {

    }

    void Update()
    {
        _scoreText.text = scoreValue.ToString();

        if (BlueTeamScore.scoreValue == 1)
        {
            _gameManager.BlueTeamWon();
            Debug.Log("Blue Team Won");
        }
    }
}
