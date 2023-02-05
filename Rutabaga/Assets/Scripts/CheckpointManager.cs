using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckpointManager : MonoBehaviour
{
    public GameObject[] checkpoints;
    public float range;
    public int currentCheckpoint = 1;
    public Animator checkpointAnim;

    void Update()
    {
        for (int i = 0; i < checkpoints.Length; i++)
        {
            if (currentCheckpoint < i && range > Vector2.Distance(checkpoints[i].transform.position, transform.position))
            {
                checkpointAnim.SetTrigger("Pop");
                currentCheckpoint = i;
            }
        }
    }
}
