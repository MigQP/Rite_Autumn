using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBrain : MonoBehaviour
{
    /*MOVEMENT SYSTEM OF GAME CHARACTER*/

    // THIS SCRIPT GOES ON BODY BONE

    public bool canMove;

    public Transform rayPoint;
    public float groundCheckDistance;
    public LayerMask groundLayer;
    public float yOffest;
    public Transform[] legTargets;
    public float speed;
    public float currspeed;
    public float offsetTimer;
    bool decrease;
    [Range(0f, 0.5f)]
    public float breatheHeight;
    public float breatheSpeed;
    public LegMover[] legs;

    public Transform mainTransform;

    float screenHalfWidthInWorldUnits;

    public AudioSource steps;

    // Start is called before the first frame update
    void Start()
    {
        
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize  + 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        WalkAudio();
        CalculateGround();
        Idle();

        if (!canMove)
            return;

        currspeed = speed * Input.GetAxis("Horizontal");

        Debug.Log(currspeed);
        
        transform.position = new Vector3(transform.position.x + currspeed * Time.deltaTime, transform.position.y, transform.position.z);
        
        Vector3 charecterScale = transform.localScale;

        // Sprite Flipping
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 13.74f);


        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 13.74f);
    
        }


        // Moving game character from extreme to extreme of screen 
        if (transform.position.x < -screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits -1, transform.position.y);
        }

        if (transform.position.x > screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }

    }

    public void CalculateGround()
    {
        float offset = 0;
        offset = yOffest+ offsetTimer;
        if (currspeed == 0)
        {
            offset = yOffest + offsetTimer;
        }
        else
        {
            //  offset = yOffest;
        }

        RaycastHit2D hit = Physics2D.Raycast(rayPoint.position, Vector3.down, groundCheckDistance, groundLayer);
        if (hit.collider != null)
        {
            Vector3 point = Vector3.zero;
            for (int i = 0; i < legTargets.Length; i++)
            {
                point += legTargets[i].position; // gets all the legtargets positions
            }
            point.y = point.y / legTargets.Length;
            point.y += offset;

            transform.position = new Vector3(transform.position.x, point.y, transform.position.z);

        }


    }


    // MOVEMENT OF INDIVIDUAL IK TARGET HANDLES IN RESTING BASED ON VARIABLES

    public void Idle()
    {
        if (offsetTimer < breatheHeight && decrease == false)
        {
            offsetTimer += Time.deltaTime * (breatheSpeed * 0.1f);
        }


        else if (offsetTimer > breatheHeight)
        {
            decrease = true;
        }

        if (offsetTimer > -breatheHeight && decrease == true)
        {
            offsetTimer -= Time.deltaTime * (breatheSpeed * 0.1f);
        }
        else if (offsetTimer < -breatheHeight && decrease == true)
        {

            decrease = false;
        }
    }

    void WalkAudio ()
    {
        
        if (currspeed != 0)
        {   if (!steps.isPlaying)
            {
                steps.pitch = Random.Range(1.8f, 1.9f);
                steps.Play();
            }

        }

        else
        {
            steps.Stop();
        }
        
    }


}