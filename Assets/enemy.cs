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
    private AudioSource audioSource;
    public GameObject highscore;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            audioSource.PlayOneShot(hit);
            string score = (Convert.ToInt32(highscore.GetComponent<Text>().text) + 10).ToString();
            highscore.GetComponent<Text>().text = score;
        }
        if (collision.tag == "Player")
        {
            Instantiate(explosion, collision.transform.position, Quaternion.identity);
            collision.gameObject.SetActive(false);
            audioSource.PlayOneShot(explosionSound);
            GameObject timer = GameObject.Find("Timer");
            timer.GetComponent<Timer>().alive = false;
        }
        if(collision.tag == "asteroid")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    private void Update()
    {
        transform.position = new Vector2(-speed*Time.deltaTime+transform.position.x, transform.position.y);
        if (transform.position.x < -3) Destroy(gameObject);
    }
}
