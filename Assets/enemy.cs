using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    public float speed;
    public GameObject explosion;
    public AudioClip hit;
    public AudioClip explosionSound;
    public AudioSource[] audioSources;
    public GameObject highscore;
    private void Start()
    {
        highscore = GameObject.Find("Score");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "bullet")
        {
            Destroy(collision.gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            audioSources[0].PlayOneShot(hit);
            string score = (Convert.ToInt32(highscore.GetComponent<Text>().text) + 10).ToString();
            highscore.GetComponent<Text>().text = score;
        }
        if (collision.tag == "Player")
        {
            Instantiate(explosion, collision.transform.position, Quaternion.identity);
            collision.gameObject.SetActive(false);
            audioSources[1].PlayOneShot(explosionSound);
            GameObject timer = GameObject.Find("Timer");
            timer.GetComponent<Timer>().alive = false;
        }
        if(collision.tag == "asteroid")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            audioSources[0].PlayOneShot(hit);
        }
    }
    private void Update()
    {
        transform.position = new Vector2(-speed*Time.deltaTime+transform.position.x, transform.position.y);
        if (transform.position.x < -3) Destroy(gameObject);
    }
    public void sfxcontrol(System.Single vol)
    {
        audioSources[0].volume = vol;
        audioSources[1].volume = vol;
    }
}
