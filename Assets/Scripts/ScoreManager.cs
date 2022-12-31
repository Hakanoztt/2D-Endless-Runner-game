using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public GameObject enemyEffect;
    public GameObject coinEffect;
    public TextMeshProUGUI scoreText;
    public int score;

    void Start()
    {
        
    }


    void Update()
    {
        scoreText.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            score++;
            Destroy(collision.gameObject);
            var _enemyEffect = Instantiate(enemyEffect, collision.transform.position, collision.transform.rotation);
            Destroy(_enemyEffect, 3f);
          
        }

        if (collision.CompareTag("Coin"))
        {
            Instantiate(coinEffect, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);
        }
    }
}
