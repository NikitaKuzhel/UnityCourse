using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject completeLevelUI;

    private bool gameHasEnded = false;

    public void CompleteLevel()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME WON!");
            completeLevelUI.SetActive(true);
        }
    }

    public void GameOver()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Restart();
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene("Level_01");
    }
}
