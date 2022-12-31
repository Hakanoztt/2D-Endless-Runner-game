using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject enemy;
    void Start()
    {
       var _instantiatedObj= Instantiate(enemy, transform.position, transform.rotation);
       
    }


    void Update()
    {

    }
}
