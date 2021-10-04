using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitLeaf : MonoBehaviour
{
    /*This script is in charge of fading out the leafs once they hit the ground and have not been grabbed */


    public float timeToAdd;

    public float bitTime;
    private float currentTime;
    bool grounded;

    private SpriteRenderer bitRend;
    bool hasFaded;

    private void Awake()
    {
        hasFaded = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        timeToAdd = transform.lossyScale.x - Random.Range(-.2f, .2f) / 2;
        bitRend = GetComponent<SpriteRenderer>();
        // Fading time based on leafs scale
        bitTime = transform.localScale.x * 2;
        currentTime = bitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (grounded)
        {
            // Countdown to start fade
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                if (!hasFaded)
                    StartCoroutine(FadeTo(0, transform.localScale.x));

            }
        }

        else
        {
            currentTime = bitTime;
        }

    }


    // Fade In/Out and Destroy GameObject
    IEnumerator FadeTo(float aValue, float aTime)
    {
        hasFaded = true;
        float alpha = bitRend.color.a;

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            bitRend.color = newColor;

            if (bitRend.color.a <= 0.05f)
            {
                Destroy(gameObject);
            }
            yield return null;
        }

    }


  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = false;
    }
}
