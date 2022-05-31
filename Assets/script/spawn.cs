using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;
    float RandX1;
    float RandX2;
    Vector2 whereToSpawn1;
    Vector2 whereToSpawn2;
    public float spawnRate = 2;
    float nextSpawn = 0.0f;

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            RandX1 = Random.Range(8.27f, -8.13f);
            RandX2 = Random.Range(8.27f, -8.13f);
            whereToSpawn1 = new Vector2(RandX1, 6.21f);
            whereToSpawn2 = new Vector2(RandX2, 6.21f);
            Instantiate(obj1, whereToSpawn1, Quaternion.identity);
            Instantiate(obj2, whereToSpawn2, Quaternion.identity);
        }
    }
}
