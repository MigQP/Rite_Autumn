using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Split : MonoBehaviour
{
    /*DEPRECATED*/

    /*SPLITTING SYSTEM FOR LEAVES*/


    public bool canSplit;

    public float leafTime;
    private float currentTime;

    bool grounded;

    void Start()
    {
        leafTime = transform.localScale.x * 4;
        currentTime = leafTime;
    }

    void Update()
    {

        if (grounded)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        else
        {
            currentTime = leafTime; 
        }


        //Debug.Log(currentTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;

        if (canSplit)
        {
            foreach (Transform child in transform)
            {

                child.gameObject.SetActive(true);
                child.parent = null;
                
            }

            if (transform.childCount <= 0)
            {
                StartCoroutine(slr());
            }
            //gameObject.SetActive(false);
        }
    }

    IEnumerator slr()
    {
        yield return new WaitForSeconds(.05f);
        gameObject.SetActive(false);
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }
}
