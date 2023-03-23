using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgrade : MonoBehaviour
{
    void Update()
    {
       transform.position = new Vector2(-1.0f * Time.deltaTime + transform.position.x, transform.position.y);
       if (transform.position.x < -3) Destroy(gameObject);
    }
}
