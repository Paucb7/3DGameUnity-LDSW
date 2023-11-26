using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public BallController ball;

    private float offset;


    void Start()
    {
        offset = transform.position.y - ball.transform.position.y;
    }


    void Update()
    {
        Vector3 actualPos = transform.position;
        actualPos.y = ball.transform.position.y + offset;
        transform.position = actualPos;

    }
}
