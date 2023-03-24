using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class boss : MonoBehaviour
{
    public Timer Timer;
    public bool alive;
    int hp = 30;
    public GameObject explosion;
    float attacktimer = 10f;
    public float reachy = 0;
    public GameObject highscore;
    public AudioClip explosionaid;
    public AudioSource audios;

    // Update is called once per frame
    void Update()
    {
        if(Timer.seconds > 29)
        {
            alive = true;
        }
        else
        {
            alive = false;
            if (transform.position.x < 2.71f)
            {
                transform.position = new Vector2(transform.position.x + Time.unscaledDeltaTime, transform.position.y);
                hp = 30;
                attacktimer = 10f;
            }
        }
        if (hp < 1)
        {
            for(int i = 0; i < 15; i++)
            {
                float x = UnityEngine.Random.Range(-400, 400);
                float y = UnityEngine.Random.Range(-200, 200);
                Instantiate(explosion, new Vector2(transform.position.x+(x/1000)-0.4f, transform.position.y + (y / 1000)), Quaternion.identity);
            }
            string score = (Convert.ToInt32(highscore.GetComponent<Text>().text) + 1000).ToString();
            highscore.GetComponent<Text>().text = score;
            audios.PlayOneShot(explosionaid);
            gameObject.SetActive(false);
        }
        if (alive)
        {
            if(hp < 1) alive = false;
            if(transform.position.x > 1.69f)
            {
                transform.position = new Vector2(transform.position.x - Time.deltaTime, transform.position.y);
            }
            attacktimer -= Time.deltaTime;
            if(attacktimer < 0)
            {
                int attack = UnityEngine.Random.Range(1, 4);
                transform.position = new Vector2(2.7f, 0.0f);
                attacktimer = 10.0f;
                switch(attack)
                {
                    case 1:
                        reachy = 0.5f;
                        break;
                    case 2:
                        reachy = 0.0f;
                        break;
                    case 3:
                        reachy = -0.5f;
                        break;
                }
            }
        }
        if (reachy > transform.position.y + 0.05f)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + Time.deltaTime);
        }
        else if (reachy < transform.position.y - 0.05f)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - Time.deltaTime);
        }
        else if(attacktimer < 4.0f)
        {   
            transform.position = new Vector2(transform.position.x - Time.deltaTime * 2, transform.position.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bullet" && alive)
        {
            Destroy(collision.gameObject);
            hp--;
        }
        if(collision.tag == "Player")
        {
            Instantiate(explosion, collision.transform.position, Quaternion.identity);
            collision.gameObject.SetActive(false);
            audios.PlayOneShot(explosionaid);
            GameObject timer = GameObject.Find("Timer");
            timer.GetComponent<Timer>().alive = false;
        }
    }
}
