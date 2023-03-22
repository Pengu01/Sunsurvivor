using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flash : MonoBehaviour
{
    float timer;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.2f) Destroy(gameObject);
    }
}
