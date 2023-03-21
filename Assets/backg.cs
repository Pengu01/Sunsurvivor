using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backg : MonoBehaviour
{
    public float spacing;
    void Update()
    {
        spacing -= (0.1f * Time.deltaTime);
        transform.position = new Vector2(spacing, transform.position.y);
        if (spacing < -2.72f) spacing += 5.44f;
    }
}
