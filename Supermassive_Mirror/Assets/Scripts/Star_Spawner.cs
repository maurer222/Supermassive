using Mirror;
using UnityEngine;

public class Star_Spawner : NetworkBehaviour
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
        if (isServer)
        {
            GameObject gObj = Instantiate(starPrefab, new Vector3(Random.Range(-spawnRange, spawnRange),
                                                          Random.Range(-spawnRange, spawnRange), 0f),
                                                          Quaternion.identity) as GameObject;
            gObj.transform.parent = gameObject.transform;
            NetworkServer.Spawn(gObj.gameObject);
        }
    }
}
