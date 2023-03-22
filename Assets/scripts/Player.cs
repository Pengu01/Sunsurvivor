using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Sprite[] sprites;
    public GameObject bullet;
    public float reload;
    public AudioClip shoot;
    float reloadtimer;
    private AudioSource audioSource;
    
    private void Start()
    {
        reloadtimer = reload;
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if (v == 1) gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
        else if (v == -1) gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
        else gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
        transform.position = new Vector2(transform.position.x + (h * speed * Time.deltaTime), transform.position.y + (v * speed * Time.deltaTime));
        if (transform.position.x > 0.8577839f) transform.position = new Vector2(0.8577839f, transform.position.y);
        if (transform.position.x < -0.9312745f) transform.position = new Vector2(-0.9312745f, transform.position.y);
        if (transform.position.y > 0.6320776f) transform.position = new Vector2(transform.position.x, 0.6320776f);
        if (transform.position.y < -0.6581162f) transform.position = new Vector2(transform.position.x, -0.6581162f);
        reload -= Time.deltaTime;
        if (Input.GetButton("Jump") && reload < 0f)
        {
            Instantiate(bullet, new Vector2 (transform.position.x+0.2f, transform.position.y), Quaternion.identity);
            reload = reloadtimer;
            audioSource.PlayOneShot(shoot);
        }
    }
}
