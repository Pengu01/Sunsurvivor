using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bosshealth : MonoBehaviour
{
    public float damageamount = 1;
    public float maxhealthfase1 = 25;
    public float currenthealth;
    public GameObject weapon;
    public GameObject weapon2;
    public GameObject fase1;


    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxhealthfase1; 
    }

    // Update is called once per frame
    void Update()
    {
        if (currenthealth <= 0)
        {
            Destroy(gameObject);
        }

        if (currenthealth < 15)
        {
            //enter stage 2
            weapon.GetComponent<enemyshoot>().enabled = false;
            weapon2.GetComponent<myshootscript2>().enabled = false;
            fase1.GetComponent<bosschange>().enabled = true;
        }
    }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //currenthealth = maxhealthfase1;

        if (collision.tag == "bullet")

        {
           
            
                
                currenthealth -= damageamount;
                Debug.Log("health is " + currenthealth);
            
           
            
        }
    }


}
