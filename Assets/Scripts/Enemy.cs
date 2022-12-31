using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }


}
