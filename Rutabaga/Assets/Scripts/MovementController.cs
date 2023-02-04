using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float MovePower;
    public float HookRetractSpeed;
    public float HookRange;

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
        if(hookEnforcer.distance > 1)
            hookEnforcer.distance -= HookRetractSpeed * Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            //Find the hook point
            Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePoint.z = 0;
            Vector3 castDirection = Vector3.Normalize(mousePoint - transform.position);
            RaycastHit2D rayHit = Physics2D.Raycast(transform.position + castDirection * 0.5f, castDirection, HookRange);
            if (rayHit.collider != null)
            {
                //Attach the hook
                hookPoint = Instantiate(hookPointPrefab);
                hookPoint.transform.position = rayHit.point;
                hookEnforcer.enabled = true;
                hookEnforcer.distance = Vector3.Distance(transform.position, hookPoint.transform.position);
                hookEnforcer.connectedBody = hookPoint.GetComponent<Rigidbody2D>();
            }
        }
        if (Input.GetMouseButtonUp(0))
        { //Remove the hook
            hookEnforcer.enabled = false;
            Destroy(hookPoint);
        }
    }
}
