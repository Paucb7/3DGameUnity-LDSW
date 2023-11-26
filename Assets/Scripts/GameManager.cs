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
    }

    public void NextLevel()
    {

    }

    public void Restartlevel()
    {

    }

    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;

        if (currentScore > bestScore)
        {
            bestScore = currentScore;
        }
    }



}
