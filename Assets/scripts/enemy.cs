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
    }
    private void Awake()
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
            audioSource.PlayOneShot(hit);
            highscore.GetComponent<Text>().text = (Convert.ToInt32(highscore.GetComponent<Text>().text) + 10).ToString();
        }
        if (collision.tag == "Player")
        {
            Instantiate(explosion, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(explosionSound);
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
