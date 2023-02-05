using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public GameObject[] checkpoints;
    public float range;

    void Update()
    {
        for (int i = 0; i < checkpoints.Length; i++)
        {
            if (range > Vector2.Distance(checkpoints[i].transform.position, transform.position))
            {

            }
        }
    }
}
