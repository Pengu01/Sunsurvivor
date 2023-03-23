using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restart : MonoBehaviour
{
    public GameObject[] texts;
    public GameObject player;
    private void OnMouseDown()
    {
        texts[0].GetComponent<Timer>().alive = true;
        Time.timeScale = 0.0f;
        gameObject.SetActive(false);
        for (int i = 0; i < texts.Length-1; i++)
        {
            texts[i].SetActive(false);
        }
        texts[texts.Length-1].SetActive(true);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach(GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("asteroid");
        foreach (GameObject asteroid in asteroids)
        {
            Destroy(asteroid);
        }
        player.transform.position = Vector3.zero;
        player.SetActive(true);
        player.GetComponent<Player>().speed = 1.0f;
        player.GetComponent<Player>().reload = 0.5f;
    }
}
