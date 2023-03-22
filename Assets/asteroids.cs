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
    string warning = "DANGER! ASTEROIDS!";
    public float repeattimer;
    Text text;
    int count = 0;
    public bool asteroidss = false;
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
        if(eventtimer < 0)
        {
            lights.GetComponent<Light2D>().intensity = 0.5f;
            if (UnityEngine.Random.Range(0, 8) == 1 && !asteroidss)
            {
                repeattimer = 1.0f;
                asteroidss = true;
            }
            eventtimer = eventrepeat;
            if (UnityEngine.Random.Range(0, 8) == 1 && !asteroidss)
            {
                eventtimer = UnityEngine.Random.Range(10, 20);
                lights.GetComponent<Light2D>().intensity = 0.1f;
            }
            eventtimer = eventrepeat;
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
    }
}
