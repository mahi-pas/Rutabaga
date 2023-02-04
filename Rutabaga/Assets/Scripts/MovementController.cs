using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Rigidbody2D pBody;
    Transform hookPoint;
    DistanceJoint2D hookEnforcer;
    // Start is called before the first frame update
    void Start()
    {
        pBody = GetComponent<Rigidbody2D>();
        hookPoint = GameObject.Find("HookPoint").transform;
        hookEnforcer = GetComponent<DistanceJoint2D>();
        hookEnforcer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float joystick = Input.GetAxis("Horizontal");
        pBody.AddTorque(-joystick * Time.deltaTime * 5, ForceMode2D.Impulse);
        if (Input.GetMouseButtonDown(0))
        {
            hookPoint.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hookEnforcer.enabled = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            hookEnforcer.enabled = false;
        }
    }
}
