using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafSplit : MonoBehaviour
{


    public bool canSplit;
    public bool isGrabbable;

    public int timesGrabbed;

    public float leafTime;
    public float currentTime;

    bool grounded;

    [SerializeField]
    Object destructableLeaf;

    private SpriteRenderer leafRend;
    bool hasFaded;

    void Awake()
    {
        hasFaded = false;    
    }
    void Start()
    {
        leafRend = GetComponent<SpriteRenderer>();
        leafTime = transform.localScale.x * 2;
        currentTime = leafTime;
        isGrabbable = true;
    }

    void Update()
    {

        if (grounded)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                //Destroy(this.gameObject);
                if (!hasFaded)
                    // skipping grabbing a leaf while fading
                    isGrabbable = false;
                    StartCoroutine(FadeTo(0, transform.localScale.x));
                
            }
        }

        else
        {
            currentTime = leafTime; 
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
      

        if (canSplit)
        {
            ExplodeThisGameObject();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = false;
    }

    /* Substitution of Original Prefab for one that is the same object broken into pieces */
    void ExplodeThisGameObject()
    {
        
        GameObject destructable = (GameObject)Instantiate(destructableLeaf);
        destructable.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        // destruible en posicion de objeto original
        destructable.transform.position = transform.position;
        destructable.transform.rotation = transform.rotation;
        foreach (Transform child in destructable.transform)
        {
            child.parent = null;

        }
        Destroy(gameObject);
    }


    // Fade of Main Leaf
    IEnumerator FadeTo(float aValue, float aTime)
    {
        hasFaded = true;
        float alpha = leafRend.color.a;

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            leafRend.color = newColor;

            if (leafRend.color.a <= 0.05f)
            {
                Destroy(gameObject);
            }
            yield return null;
        }


    }
    

}
