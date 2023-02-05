using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insect : MonoBehaviour
{
    public float travelDistance;
    public float insectSpeed;

    private Vector3 startingPosition;
    private bool travelRight = true;
    private bool inHive = false;
    private float hiveTimer = 0;
    private SpriteRenderer sp;
    // Start is called before the first frame update
    void Start()
    {
        sp = this.GetComponent<SpriteRenderer>();
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.position.x);
        Debug.Log(startingPosition.x + travelDistance);
        if (!inHive && travelRight && transform.position.x < startingPosition.x + travelDistance)
        {
            transform.position = new Vector3(transform.position.x + insectSpeed * Time.deltaTime, startingPosition.y, 0);
        }
        else if (!inHive && !travelRight && transform.position.x > startingPosition.x - travelDistance)
        {
            transform.position = new Vector3(transform.position.x - insectSpeed * Time.deltaTime, startingPosition.y, 0);
        }
        else if (!inHive)
        {
            sp.enabled = false;
            inHive = true;
        }
        else if (inHive)
        {
            if (hiveTimer >= 5.0f)
            {
                sp.flipX = !sp.flipX;
                travelRight = !travelRight;
                sp.enabled = true;
                inHive = false;
                hiveTimer = 0;
            }
            hiveTimer = hiveTimer + 5f * Time.deltaTime;
        }

    }
}
