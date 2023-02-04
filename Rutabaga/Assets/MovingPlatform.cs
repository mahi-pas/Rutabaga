using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public bool verticleMovement = false;
    public bool startingForward = true;
    public float backDistance = 0.5f;
    public float forwardDistance = 0.5f;
    public float playformSpeed = 0.01f;

    private bool goingForward = false;
    private Vector2 startingPosition;

    void Start()
    {
        goingForward = startingForward;
        startingPosition = transform.position;
    }

    void Update()
    {
        Debug.Log(startingPosition.x + forwardDistance);
            if (verticleMovement)
            {
                if (goingForward)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y + playformSpeed * Time.deltaTime);
                }
                else
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y - playformSpeed * Time.deltaTime);
                }
                if (transform.position.y >= startingPosition.y + forwardDistance)
                {
                    goingForward = false;
                }
                else if (transform.position.y <= startingPosition.y - backDistance)
                {
                    goingForward = true;
                }
            }
            else
            {
                if (goingForward)
                {
                    transform.position = new Vector2(transform.position.x + playformSpeed * Time.deltaTime, transform.position.y);
                }
                else
                {
                    transform.position = new Vector2(transform.position.x - playformSpeed * Time.deltaTime, transform.position.y);
                }
                if (transform.position.x >= startingPosition.x + forwardDistance)
                {
                    goingForward = false;
                }
                else if (transform.position.x <= startingPosition.x - backDistance)
                {
                    goingForward = true;
                }
            }
        }
}

