using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStart : MonoBehaviour
{
    /*MOVEMENT OF ANT CHARACTER IN TITLE SCREEN*/


    [SerializeField] Transform goToPos;

    private float speed = 7;

    private SpiderBrain theAnt;


    public Animator antenaAnim;

    // Start is called before the first frame update
    void Start()
    {
        theAnt = FindObjectOfType<SpiderBrain>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveGameObject();
        
    }


    // Move Ant to certain point once there call the introduction animation
    void MoveGameObject ()
    {
        if (transform.position.x >= -6.55f)
        {
            theAnt.canMove = true;
            //antenaAnim.SetTrigger("Present");
            StartCoroutine(SetMenu());
            this.enabled = false;
        }

        else
        {
            transform.position = Vector3.MoveTowards(transform.position, goToPos.position, speed * Time.deltaTime);
        }
    }


    
    IEnumerator SetMenu ()
    {
        yield return new WaitForSeconds(.25f);
      
        antenaAnim.SetTrigger("Present");
    }
}
