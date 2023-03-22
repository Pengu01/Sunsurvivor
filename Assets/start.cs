using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour
{
    public GameObject[] texts;
    void Start()
    {
        Time.timeScale = 0.0f;
    }
    private void OnMouseDown()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
        for(int i = 0; i < texts.Length; i++)
        {
            texts[i].SetActive(true);
        }
    }
}
