using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float timer;
    Text text;
    int seconds;
    GameObject highscore;
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
        highscore = GameObject.Find("Score");
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > 1.0f)
        {
            timer -= 1.0f;
            seconds++;
            string score = (Convert.ToInt32(highscore.GetComponent<Text>().text) + 5).ToString();
            highscore.GetComponent<Text>().text = score;
            if (seconds < 10)
            {
                text.text = "0" + seconds.ToString();
            }
            else text.text = seconds.ToString();
        }
    }
}
