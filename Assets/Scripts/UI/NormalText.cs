using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalText : MonoBehaviour
{
    /*RESTART TEXT COLOR */

    public Color normalColor;
    private Text optionText;

    private void Awake()
    {
        optionText = GetComponent<Text>();
    }

    void OnDisable()
    {
        optionText.color = normalColor;
    }


}
