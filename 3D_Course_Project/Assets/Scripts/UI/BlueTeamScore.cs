using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueTeamScore : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    public static int scoreValue = 0;

    void Start()
    {

    }

    void Update()
    {
        _scoreText.text = scoreValue.ToString();
    }
}
