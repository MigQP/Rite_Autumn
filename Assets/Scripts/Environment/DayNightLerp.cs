using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightLerp : MonoBehaviour
{
    /*DAY NIGHT CYCLE OF BACKGROUND*/

    private Image fondoRenderer;

    public ParticleSystem rainParticles;

    [Range(0, 1)] public float rainTime;

    public int[] timeRain;
    int rainIndex = 0;

    [Range(0, 1)] public float lerpTime;

    public Color[] timeColor;

    int colorIndex = 0;

    float time;


    void Awake()
    {
        fondoRenderer = GetComponent<Image>();
    }

    void Update()
    {
        rainParticles.emissionRate = Mathf.Lerp(rainParticles.emissionRate, timeRain[rainIndex], rainTime * Time.deltaTime);

        fondoRenderer.color = Color.Lerp(fondoRenderer.color, timeColor[colorIndex], lerpTime * Time.deltaTime);

        time = Mathf.Lerp(time, 1f, lerpTime * Time.deltaTime);
        
        if (time > .9f)
        {
            time = 0;
            /* Rain Particle SYTEM */
            rainIndex++;
            rainIndex = (rainIndex >= timeRain.Length) ? 0 : rainIndex;

            /* Background */
            colorIndex++;
            colorIndex = (colorIndex >=  timeColor.Length) ? 0 : colorIndex;  
        }


    }

}
