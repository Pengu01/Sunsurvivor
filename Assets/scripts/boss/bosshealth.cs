using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bosshealth : MonoBehaviour
{
    public int damageamount = 1;
    public int maxhealthfase1 = 25;
    public int currenthealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int amount)
    {
        
        currenthealth -= amount;
        
        if(currenthealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        while (collision.tag == "bullet")
        {


            if (collision.tag == "bullet")

            {
                currenthealth = maxhealthfase1;
                currenthealth -= damageamount;
                Debug.Log("health is " + currenthealth);

            }
        }
    }


}
