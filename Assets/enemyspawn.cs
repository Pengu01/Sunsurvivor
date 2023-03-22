using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;

public class enemyspawn : MonoBehaviour
{
    public GameObject enemy;
    public float enemyspawner;
    float enemyspawntimer;
    int count;
    private void Start()
    {
        enemyspawntimer = enemyspawner;
    }

    // Update is called once per frame
    void Update()
    {
        enemyspawntimer -= Time.deltaTime;
        if(enemyspawntimer < 0)
        {
            if(UnityEngine.Random.Range(0, 4) == 2 && count == 0)
            {
                count = UnityEngine.Random.Range(1, 5);
            }
            float randomfloat = UnityEngine.Random.Range(-659, 632);
            Instantiate(enemy, new Vector2(transform.position.x, randomfloat /1000),Quaternion.identity);
            float randomfloat2 = UnityEngine.Random.Range(89, 110);
            if(count == 0)
            {
                enemyspawntimer = enemyspawner * randomfloat2 / 100;
            }
            else
            {
                enemyspawntimer = enemyspawner * randomfloat2 / 270;
                count--;
            }
        }
    }
}
