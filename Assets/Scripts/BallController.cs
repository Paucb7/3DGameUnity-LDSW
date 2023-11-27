using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public Rigidbody rb;
    public float impulseForce = 3f;

    private bool ignoreNextcollision;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }



    private void OnCollisionEnter(Collision collision)
    {




        if (ignoreNextcollision)
        {
            return;
        }

        DeathPart deathPart = collision.transform.GetComponent<DeathPart>();
        if (deathPart) 
        {
            GameManager.singleton.Restartlevel();
        }
        

        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up*impulseForce, ForceMode.Impulse);

        ignoreNextcollision = true;
        Invoke("AllowNextCollision", 0.2f);
        

    }

    private void AllowNextCollision()
    {
        ignoreNextcollision = false;
    }

    public void ResetBall()
    {
        transform.position = startPosition;
    }


}
