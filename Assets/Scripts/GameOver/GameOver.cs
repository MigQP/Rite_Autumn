using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    /*ACTIVATION OF GAME OVER SCREEN WHEN WIND FORCE HAS MADE THE AND GO TO TRIGGER*/


    public GameObject gameOverText;
    private GameObject theAnt;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            theAnt = GameObject.FindGameObjectWithTag("Player").transform.parent.gameObject;
            StartCoroutine(ShowGameOver());
        }
    }

    IEnumerator ShowGameOver()
    {
        yield return new WaitForSeconds(.6f);
        gameOverText.SetActive(true);
        Destroy(theAnt);
    }
}
