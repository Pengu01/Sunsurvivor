using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;

public class asteroids : MonoBehaviour
{
    public float eventrepeat;
    public float eventtimer;
    float starttimer = 10.0f;
    public GameObject asteroid;
    string warning = "ASTEROIDS INBOUND";
    string warning2 = "DAMAGED RADAR";
    public float repeattimer;
    Text text;
    int count = 0;
    public bool asteroidss = false;
    public bool darkness = false;
    public GameObject lights;
    SerializedProperty intense;
    private void Start()
    {
        eventtimer = eventrepeat;
        text = gameObject.GetComponent<Text>();
    }
    void Update()
    {
        starttimer -= Time.deltaTime;
        repeattimer -= Time.deltaTime;
        if (starttimer < 0)
        {
            eventtimer -= Time.deltaTime;
        }
        if(eventtimer < 0 && lights.GetComponent<Light2D>().intensity == 0.5f)//if you get an error on Light2D and .Universal its a bug and it works fine
        {
            if (UnityEngine.Random.Range(0, 6) == 1 && !asteroidss && !darkness)
            {
                repeattimer = 1.0f;
                asteroidss = true;
            }
            if (UnityEngine.Random.Range(0, 6) == 1 && !asteroidss && !darkness)
            {
                repeattimer = 1.0f;
                darkness = true;
            }
            else eventtimer = eventrepeat;
        }
        if(repeattimer < 0 && asteroidss)
        {
            if (text.text == warning) text.text = "";
            else text.text = warning;
            float randomfloat = UnityEngine.Random.Range(-930, 850);
            Instantiate(asteroid, new Vector2(randomfloat / 1000, 1.5f), Quaternion.identity);
            if (count <= 2)
            {
                repeattimer = 1.0f;
                count++;
            }
            else
            {
                count = 0;
                asteroidss = false;
                eventtimer = eventrepeat;
            }
        }
        if(repeattimer < 0 && darkness)
        {
            if (text.text == warning2) text.text = "";
            else text.text = warning2;
            lights.GetComponent<Light2D>().intensity = lights.GetComponent<Light2D>().intensity - 0.1f;
            if(count <= 4)
            {
                repeattimer = 0.5f;
                count++;
            }
            else
            {
                count = 0;
                darkness = false;
                eventtimer = eventrepeat;
                repeattimer = UnityEngine.Random.Range(10, 20);
            }
        }
        if(!darkness && lights.GetComponent<Light2D>().intensity != 0.5f && repeattimer < 0)
        {
            lights.GetComponent<Light2D>().intensity = lights.GetComponent<Light2D>().intensity + 0.1f;
            repeattimer = 0.5f;
            eventtimer = eventrepeat;
        }
    }
}
