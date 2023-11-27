using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text currentScoreText;
    public Text bestScoreText;



    void Update()
    {
        
        currentScoreText.text = "Score: " + GameManager.singleton.currentScore;

        bestScoreText.text = "Best: " + GameManager.singleton.bestScore;

    }
}
