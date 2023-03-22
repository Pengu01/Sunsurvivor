using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyshoot : MonoBehaviour
{
    /*
    [SerializeField]
    private Transform weapon1;

    [SerializeField]
    private Rigidbody2D bullet
        ;

    private float bulletspeed;

    private float randomDirectionModifier, randomSpeed;
    
    public void shootweapon1()
    {
        for (int i = 0; i < 9; i++)
        {
            var newbullet = Instantiate(bullet, weapon1.position, weapon1.rotation);
            randomDirectionModifier = Random.Range(-0.5f, 0.5f);
            randomSpeed = Random.Range(100f, 500f);
            newbullet.AddRelativeForce(new Vector2(0f + randomDirectionModifier, 1f) * randomSpeed);
        }
    }

    */

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
