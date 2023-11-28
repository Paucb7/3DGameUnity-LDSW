using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class BallController : MonoBehaviour
{

    public Rigidbody rb;
    public float impulseForce = 3f;

    private bool ignoreNextcollision;

    private Vector3 startPosition;


    [HideInInspector]
    public int perfectPass;

    public float superSpeed = 9;

    private bool isSuperSpeedActive;

    public int perfectPassCount = 4;

    public GameObject splash;

    public AudioSource colissionAudio;

    private void Start()
    {
        startPosition = transform.position;
    }



    private void OnCollisionEnter(Collision collision)
    {

        colissionAudio.Play();

        AddSplash(collision);


        if (ignoreNextcollision)
        {
            return;
        }


        if(isSuperSpeedActive && !collision.transform.GetComponent<GoalController>())
        {
            Destroy(collision.transform.parent.gameObject, 0.2f);
        }
        else {

            DeathPart deathPart = collision.transform.GetComponent<DeathPart>();
            if (deathPart) 
            {
                GameManager.singleton.Restartlevel();
            }

        }


        
        

        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up*impulseForce, ForceMode.Impulse);

        ignoreNextcollision = true;
        Invoke("AllowNextCollision", 0.2f);

        perfectPass = 0;
        isSuperSpeedActive = false;
        

    }

    private void Update()
    {
        if (perfectPass >= perfectPassCount && !isSuperSpeedActive)
        {
            isSuperSpeedActive = true;

            rb.AddForce(Vector3.down * superSpeed, ForceMode.Impulse);
        }
    }


    private void AllowNextCollision()
    {
        ignoreNextcollision = false;
    }

    public void ResetBall()
    {
        transform.position = startPosition;
    }

    public void AddSplash(Collision collision)
    {
        GameObject newSplash;

        newSplash = Instantiate(splash);

        newSplash.transform.SetParent(collision.transform);

        newSplash.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.11f, this.transform.position.z);

        Destroy(newSplash, 3);


    }


}
