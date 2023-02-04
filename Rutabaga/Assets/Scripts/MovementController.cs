using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float MovePower;
    public float HookRetractSpeed;

    Rigidbody2D pBody;
    DistanceJoint2D hookEnforcer;
    GameObject hookPoint;
    public GameObject hookPointPrefab;
    // Start is called before the first frame update
    void Start()
    {
        pBody = GetComponent<Rigidbody2D>();
        hookEnforcer = GetComponent<DistanceJoint2D>();
        hookEnforcer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float joystick = Input.GetAxis("Horizontal");
        pBody.AddTorque(-joystick * Time.deltaTime * MovePower, ForceMode2D.Impulse);
        hookEnforcer.distance -= HookRetractSpeed * Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 newHookPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newHookPoint.z = 0;
            hookPoint = Instantiate(hookPointPrefab);
            hookPoint.transform.position = newHookPoint;
            hookEnforcer.enabled = true;
            hookEnforcer.distance = Vector3.Distance(transform.position, hookPoint.transform.position);
            hookEnforcer.connectedBody = hookPoint.GetComponent<Rigidbody2D>();
        }
        if (Input.GetMouseButtonUp(0))
        {
            hookEnforcer.enabled = false;
            Destroy(hookPoint);
        }
    }
}
