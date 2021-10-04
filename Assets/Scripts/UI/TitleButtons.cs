using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleButtons : MonoBehaviour
{
    /*TITLE SCENE: TEXT OBJECT MANAGER*/

    public GameObject[] buttons;

    public GameObject highScore;
    private void OnEnable()
    {
        StartCoroutine(OnButtons());
        StartCoroutine(OnHighScore());
    }


    IEnumerator OnButtons()
    {
        yield return new WaitForSeconds(.6f);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(true);
        }
    }

    IEnumerator OnHighScore ()
    {
        yield return new WaitForSeconds(1.2f);

        highScore.SetActive(true);
    }
}
