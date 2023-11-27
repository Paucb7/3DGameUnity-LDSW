using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassScorePoint : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        GameManager.singleton.AddScore(1);
        FindObjectOfType<BallController>().perfectPass++;
    }

}
