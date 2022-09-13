using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D.IK;


public class Timer : MonoBehaviour
{
    /* OVERALL TIMER FOR THE GAME */

    public float score;

    [Header("Time")]
    public Slider timeSlider;
    public float gameTime;
    public bool stopTimer;

    [Header("Difficulty")]
    public float difficulty;
    int difMultiplier;

    [Header("Ant Body")]

    public LegMover[] legs;
    public BoxCollider2D antBody;
    public Rigidbody2D ant;
    public IKManager2D legsManager;
    public SpiderBrain antBrain;


    [Header("Wind")]

    public GameObject theWind;

    [Header("Game Over")]

    public GameObject gameOverTrigger;
    public Text gameOverText;

  
    // Start is called before the first frame update
    void Start()
    {

        TimerManager.gameTiming = gameTime;
        stopTimer = false;
        timeSlider.maxValue = TimerManager.gameTiming;
        timeSlider.value = TimerManager.gameTiming;
        
    }

    // Update is called once per frame
    void Update()
    {
        //float time = TimerManager.gameTiming - Time.time * difficulty;
        float time = TimerManager.gameTiming -= Time.deltaTime * difficulty;


        if (!TimerManager.isGameOver)
        {
            score += Time.deltaTime;
        }
     

        if (time <= 0)
        {
            stopTimer = true;
            TimerManager.isGameOver = true;
            KillAnt();

            //Setting and Rounding High Score Value

            int myScore = (int)score;
            //gameOverText.text = "You Survived for: " + "\n" + Mathf.Round(score).ToString() + " seconds";
            if (myScore > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", myScore);
            }
            gameOverText.text = "You Survived for: " + "\n" + myScore.ToString() + " seconds";
        }

        if (!stopTimer)
        {
           
            timeSlider.value = time;
        }
    }


    // Unlock Ants Physics Components and Turn Off IK Components for GAME OVER
    public void KillAnt()
    {
        for (int i = 0; i < legs.Length; i++)
        {
            legs[i].enabled = false;
        }

        legsManager.enabled = false;
        antBrain.enabled = false;

        antBody.isTrigger = false;
        ant.bodyType = RigidbodyType2D.Dynamic;

        gameOverTrigger.SetActive(true);

        StartCoroutine(StartWind());
 
    }


    // Wind Force
    IEnumerator StartWind()
    {
        yield return new WaitForSeconds(.6f);

        theWind.SetActive(true);
        gameObject.SetActive(false);
    }


    // Restart Timer
    private void OnDisable()
    {
        TimerManager.gameTiming = gameTime;
        stopTimer = false;
        timeSlider.maxValue = TimerManager.gameTiming;
        timeSlider.value = TimerManager.gameTiming;
      
    }


    // Restart Score
    private void OnEnable()
    {
        score = 0;
        antBrain = FindObjectOfType<SpiderBrain>();
        legsManager = antBrain.GetComponent<IKManager2D>();
        ant = antBrain.gameObject.GetComponent<Rigidbody2D>();
        antBody = antBrain.gameObject.GetComponent<BoxCollider2D>();
        legs = antBrain.gameObject.GetComponentsInChildren<LegMover>();


    }



}
