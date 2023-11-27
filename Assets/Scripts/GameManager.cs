using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int bestScore;
    public int currentScore;

    public int currentLevel = 0;

    public static GameManager singleton;



    void Awake()
    {
        if (singleton==null)
        {
            singleton = this;
        }

        else if (singleton!=this)
        {
            Destroy(gameObject);
        }

        bestScore = PlayerPrefs.GetInt("HighScore");
    }

    public void NextLevel()
    {
        currentLevel++;
        FindAnyObjectByType<BallController>().ResetBall();
        FindAnyObjectByType<HelixController>().LoadStage(currentLevel);

        Debug.Log("Pasamos de Nivel");
    }

    public void Restartlevel()
    {
        Debug.Log("Restart");
        singleton.currentScore = 0;
        FindObjectOfType<BallController>().ResetBall();
        FindAnyObjectByType<HelixController>().LoadStage(currentLevel);
    }

    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;

        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("HighScore", currentScore);
        }
    }



}
