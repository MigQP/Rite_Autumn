using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreText : MonoBehaviour
{
    /*WRITING OF HIGH SCORE*/

    public Text highScoreText;
    // Start is called before the first frame update
    void OnEnable()
    {
        if(PlayerPrefs.GetInt("HighScore") <= 0)
        {
            highScoreText.text = "High Score:    ";
        }

        if (PlayerPrefs.GetInt("HighScore") > 0)
        {
            highScoreText.text = "High Score:    " + PlayerPrefs.GetInt("HighScore").ToString();
        }
        
    }

}
