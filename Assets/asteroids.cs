using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

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
            if (UnityEngine.Random.Range(0, 4) == 1 && !asteroidss)
            {
                repeattimer = 1.0f;
                asteroidss = true;
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
