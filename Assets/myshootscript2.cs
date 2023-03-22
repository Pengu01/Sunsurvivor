using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myshootscript2 : MonoBehaviour

{
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.3)
        {
            timer = 0;
            shoot();
        }

    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }


}




