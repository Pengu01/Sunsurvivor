using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class enemyspawn : MonoBehaviour
{
    public GameObject enemy;
    public float enemyspawner;
    float enemyspawntimer;
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
            float randomfloat = UnityEngine.Random.Range(-659, 632);
            Instantiate(enemy, new Vector2(transform.position.x, randomfloat /1000),Quaternion.identity);
            enemyspawntimer = enemyspawner;
        }
    }
}
