using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 1.0f;
    public Sprite[] sprites;
    public GameObject bullet;
    public float reload = 0.5f;
    public AudioClip shoot;
    float reloadtimer;
    public AudioSource[] audioSources;   
    public Slider music;
    public Slider sfx;
    float musictimer;

    private void Start()
    {
        reloadtimer = reload;
    }
    void Update()
    {
        musictimer -= Time.unscaledDeltaTime;
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
            audioSources[1].PlayOneShot(shoot);
        }
    }
    public void sfxcontrol(System.Single vol)
    {
        audioSources[1].volume = vol * 0.3f;
        if(musictimer < 0.0f)
        {
            musictimer = 1.0f;
            audioSources[1].PlayOneShot(shoot);
        }
    }
    public void musiccontrol(System.Single vol)
    {
        audioSources[0].volume = vol;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "speed")
        {
            speed = speed + 0.05f;
            Destroy(collision.gameObject);
        }
        if (collision.tag == "reload")
        {
            reloadtimer = reloadtimer * 0.95f;
            Destroy(collision.gameObject);
        }
    }
}
