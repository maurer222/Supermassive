using Mirror;
using UnityEngine;

public class Star_Spawner : NetworkBehaviour
{
    [SerializeField] int starCount;
    [SerializeField] GameObject starPrefab;
    [SerializeField] float spawnRange;

    void Start()
    {
        if (!isServer) return;

        for (int i = 0; i < starCount; i++)
        {
            SpawnStar();
        }
    }

    public void SpawnStar()
    {
        GameObject gObj = (GameObject)Instantiate(starPrefab, new Vector3(Random.Range(-spawnRange, spawnRange),
                              Random.Range(-spawnRange, spawnRange), 0f),
                              Quaternion.identity);
        gObj.transform.parent = gameObject.transform;
        NetworkServer.Spawn(gObj);
    }
}