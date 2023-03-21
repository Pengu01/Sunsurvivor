using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed;
    public GameObject explosion;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "bullet")
        {
            Destroy(collision.gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (collision.tag == "Player")
        {
            Instantiate(explosion, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }
    private void Update()
    {
        transform.position = new Vector2(-speed*Time.deltaTime+transform.position.x, transform.position.y);
        if (transform.position.x < -3) Destroy(gameObject);
    }
}
