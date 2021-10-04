using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerAdd : MonoBehaviour
{
    /* ---DEPRECATED--- 
      SYSTEM TO ADD TIME WHEN BITS OF LEAVES ARE GRABBED*/

    public float timeToAdd;

    private void OnDestroy()
    {
        //TimerManager.gameTiming += timeToAdd;
    }
}
