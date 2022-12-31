using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnPoint : MonoBehaviour
{
    public GameObject coin;
    void Start()
    {
        var _instantiatedObj = Instantiate(coin, transform.position, transform.rotation);


    }

    // Update is called once per frame
    void Update()
    {
    }
}
