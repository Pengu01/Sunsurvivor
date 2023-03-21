using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "bullet")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }
    private void Update()
    {
        transform.position = new Vector2(-speed*Time.deltaTime+transform.position.x, transform.position.y);
    }
}
