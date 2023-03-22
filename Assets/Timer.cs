using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float timer;
    Text text;
    int seconds;
    public bool alive = true;
    bool reset = false;
    GameObject highscore;
    public GameObject restart;
    void Start()
    {
        text = gameObject.GetComponent<Text>();
        highscore = GameObject.Find("Score");
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (alive)
        {
            if(reset)
            {
                highscore.GetComponent<Text>().text = "0";
                seconds = 0;
                reset = false;
                timer = 0.0f;
                text.text = "0" + seconds.ToString();
            }
            if (timer > 1.0f)
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
        else
        {
            reset = true;
            restart.SetActive(true);
        }
    }
}
