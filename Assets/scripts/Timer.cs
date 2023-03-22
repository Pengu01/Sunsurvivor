using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float timer;
    Text text;
    int seconds;
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > 1.0f)
        {
            timer -= 1.0f;
            seconds++;
            if(seconds < 10)
            {
                text.text = "0" + seconds.ToString();
            }
            else text.text = seconds.ToString();
        }
    }
}
