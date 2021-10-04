using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class ToPlay : MonoBehaviour
{
    public Text menuText;
    public Color selectColor;
    public Color normalColor;

    public GameObject theAnt;
    

    /*DEPRECATED */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        menuText.color = selectColor;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        menuText.color = normalColor;
    }
    /*DEPRECATED */


    // Text Object Color Change (Normal and PointerEnter)
    public void SetTextColorNew (Text optionText)
    {
        optionText.color = selectColor;
    }

    public void SetTextColorNormal (Text optionText)
    {
        optionText.color = normalColor;
    }

}
