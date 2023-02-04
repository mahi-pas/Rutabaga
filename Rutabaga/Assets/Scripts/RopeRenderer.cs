using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    public float StraighteningTime;
    public float TravelTime;

    LineRenderer rope;
    Vector3 grabPoint;
    bool grappling = false;
    float grabbedTime;
    
    void Start()
    {
        rope = GetComponent<LineRenderer>();
        rope.enabled = false;
    }

    void Update()
    {
        if (grappling)
        {
            if(!rope.enabled)
                rope.enabled = true;
            Vector3 displacement = grabPoint - transform.position;
            if (grabbedTime < TravelTime)
                displacement *= grabbedTime / TravelTime;
            Vector3 normal = new Vector3(-Vector3.Normalize(displacement).y, Vector3.Normalize(displacement).x, 0);
            for(int i=0; i<rope.positionCount; i++)
            {
                float distanceAlong = (float)i / (rope.positionCount - 1);
                Vector3 nextPoint = transform.position + (distanceAlong * displacement);
                if (grabbedTime < StraighteningTime)
                    nextPoint += normal * (StraighteningTime - grabbedTime) / StraighteningTime * 0.5f //Fade away
                        * Mathf.Sin(distanceAlong * 4 * Mathf.PI * (1 + (StraighteningTime - grabbedTime) / StraighteningTime)) //Wavy rope
                        * Mathf.Sin(distanceAlong * Mathf.PI); // Converge on edges
                rope.SetPosition(i, nextPoint);
            }
            grabbedTime += Time.deltaTime;
        }
    }

    public void Grapple(Vector3 point)
    {
        grabPoint = point;
        grappling = true;
        grabbedTime = 0;
    }

    public void Unhook()
    {
        grappling = false;
        rope.enabled = false;
    }
}
