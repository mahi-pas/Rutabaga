using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawnPos;
    public float spawnTime = 2f;
    public GameObject spawnPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn",spawnTime);
    }

    void Spawn(){
        GameObject pf = Instantiate(spawnPrefab);
        if(spawnPos!= null) pf.transform.position = spawnPos.transform.position;
        Invoke("Spawn",spawnTime);
    }

}
