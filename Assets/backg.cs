using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backg : MonoBehaviour
{
    float spacing;
    void Update()
    {
        spacing -= (0.1f * Time.deltaTime);
        transform.position = new Vector2(spacing, transform.position.y);
        if (spacing < -4.08f) spacing += 4.08f;
    }
}
