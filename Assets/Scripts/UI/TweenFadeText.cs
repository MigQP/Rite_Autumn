using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenFadeText : MonoBehaviour
{
    /*MENUS ALPHA AND ACTIVATOR TWEENING MANAGER
      There are three function depending of where the player is gonna start its session
      CloseAndRepeat: From GAMEOVER to another game session
      CloseAndStart: From GAMEOVER to TitleScreen
      EnterGame: From TitleScreen to first game session
    
      Also there is the function CloseMenu for CreditsMenu*/

    public CanvasGroup menu;
    public GameObject theAnt;
    public GameObject timeSlider;
    public GameObject creditsMenu;
    public GameObject titleMenu;

    private void OnEnable()
    {
        menu.alpha = 1;
    }

    public void CloseMenu ()
    {
        menu.LeanAlpha(0, 1f).setOnComplete(OnComplete);

    }

    void OnComplete()
    {
        creditsMenu.SetActive(false);
        titleMenu.SetActive(true);
    }

    public void EnterGame ()
    {
        menu.LeanAlpha(0, .5f).setOnComplete(TurnOffAndEnter);
    }

    void TurnOffAndEnter ()
    {
        gameObject.SetActive(false);

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }

        TimerManager.isGameOver = false;
    }

    public void CloseTitle ()
    {
        menu.LeanAlpha(0, 1f).setOnComplete(TurnOffTitle);
    }


    void TurnOffTitle ()
    {
        gameObject.SetActive(false);

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }

        creditsMenu.SetActive(true);

        creditsMenu.GetComponent<CanvasGroup>().LeanAlpha(1, .5f);
    }

    public void CloseAndRestart ()
    {
        menu.LeanAlpha(0, .5f).setOnComplete(CreateAntTitle);
    }


    // Creation of Game Character when Starting from scratch
    void CreateAntTitle ()
    {
      
        gameObject.SetActive(false);

        GameObject ant = Instantiate(theAnt);
        ant.GetComponent<TitleMenu>().showTitle = true;
    }

    public void CloseAndRepeat ()
    {
        menu.LeanAlpha(0, .5f).setOnComplete(CreateAnt);
    }


    // Creation of Game Character when Restarting
    void CreateAnt()
    {

        gameObject.SetActive(false);

        GameObject ant = Instantiate(theAnt);
        ant.GetComponent<TitleMenu>().showTitle = false;
        timeSlider.SetActive(true);
    }


}
