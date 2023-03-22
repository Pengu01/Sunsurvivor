using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class falling : MonoBehaviour
{
    float rotation;
    public GameObject explosion;
    public GameObject text;
    public Canvas canvas;
    private void Update()
    {
    rotation += Time.deltaTime*20;
    transform.eulerAngles = Vector3.forward * rotation;
    }
    private void Awake()
    {
        GameObject tempObject = GameObject.Find("Canvas");
        if (tempObject != null)
        {
            canvas = tempObject.GetComponent<Canvas>();
        }
        GameObject texts = Instantiate(text,new Vector3(transform.position.x,64,transform.position.z),Quaternion.identity);
        texts.transform.SetParent(canvas.transform);
        texts.transform.localScale = new Vector3(0.1f, 0.1f, 1);
        texts.transform.position = new Vector2(transform.position.x, 0.8f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Instantiate(explosion, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
        if (collision.tag == "bullet")
        {
            Destroy(collision.gameObject);
        }
    }
}
