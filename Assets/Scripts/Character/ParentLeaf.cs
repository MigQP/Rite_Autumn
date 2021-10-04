using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentLeaf : MonoBehaviour
{
    /*ADDING OF TIME TO SLIDER WHEN BIT OF LEAVES HAS BEEN ENTERED IN*/


    public ParticleSystem eatParticle;

    public GameObject leaf;
    

    public Timer slider;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!TimerManager.isGameOver)

            if (collision.tag == "eatable") 
            {
                    leaf = collision.gameObject;
                    TimerManager.gameTiming += leaf.GetComponent<BitLeaf>().timeToAdd;
                    Destroy(leaf);
                    eatParticle.Play();

            }
    }




}
