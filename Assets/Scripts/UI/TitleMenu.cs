using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMenu : MonoBehaviour
{
    /*ACCESS OF TITLE MENU VIA RESTART OPTION WHEN GAME OVER*/


    public GameObject titleScreen;

    public bool showTitle;

    // Start is called before the first frame update

 
    void Start()
    {
        titleScreen = FindObjectOfType<LevelManager>().titleScreen;
    }



    public void ShowTitle()
    {
        //check if the player comes from another session
        if (!showTitle)
            return;
        titleScreen.SetActive(true);
    }
}
