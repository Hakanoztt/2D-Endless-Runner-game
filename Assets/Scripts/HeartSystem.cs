using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    public GameObject[] hearts;
    public Player player;

    public int health;
    public int maxHealth;
    void Start()
    {
        Time.timeScale = 1;
        health = 3;

        for (int i = 0; i < maxHealth; i++)
        {
            hearts[i].SetActive(true);
        }
    }
    private void Update()
    {
     
    }
    public void IncreaseHealth()
    {
        health--;

        for (int i = 0; i < maxHealth; i++)
        {
            hearts[i].SetActive(false);
        }
        for (int i = 0; i < health; i++)
        {
            hearts[i].SetActive(true);
        }
    }

}
