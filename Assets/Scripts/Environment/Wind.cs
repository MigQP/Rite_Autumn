using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    /*WIND FORCE WHEN GAME OVER*/

    public float windSpeed;
    public GameObject theAnt;

    private void OnEnable()
    {
        theAnt = GameObject.FindGameObjectWithTag("Player");
    }
    void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log("Object is in trigger");


        if (other.gameObject.tag == "grabbable")
        {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * windSpeed  * Time.deltaTime);
        }

        if (other.gameObject.tag == "eatable")
        {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * windSpeed * Time.deltaTime);
        }

        if (theAnt != null)
            theAnt.GetComponent<Rigidbody2D>().AddForce(Vector2.right * windSpeed * Time.deltaTime);
 
        
    }
}
