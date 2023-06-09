using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class bullet : MonoBehaviour
{
    
    public Sprite sprite;
    public float speed;
    public GameObject hit;
    float timer;
    void Update()
    {
        transform.position = new Vector2(transform.position.x + Time.deltaTime * speed, transform.position.y);
        timer += Time.deltaTime;
        if (timer > 0.25f) gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        if (timer > 5.0f) Destroy(gameObject);
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("hit");
            Destroy(gameObject);
        }
    }
}
