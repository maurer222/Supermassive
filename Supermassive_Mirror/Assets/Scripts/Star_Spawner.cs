using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star_Spawner : MonoBehaviour
{
    public int starCount;
    public GameObject starPrefab;
    public float spawnRange;

    void Start()
    {
        for (int i = 0; i < starCount; i++)
        {
            SpawnStar();
        }
    }

    public void SpawnStar()
    {
        GameObject gObj = Instantiate(starPrefab, new Vector3(Random.Range(-spawnRange, spawnRange),
                                                      Random.Range(-spawnRange, spawnRange), 0f),
                                                      Quaternion.identity) as GameObject;
        gObj.transform.parent = gameObject.transform;
        gObj.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }
}
