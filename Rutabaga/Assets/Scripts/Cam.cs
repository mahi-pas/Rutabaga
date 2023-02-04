using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour 
{ //feature point: camera movement
    public Transform follow;
    public float speed = 5f;
    private Camera cam;

    public Transform firstFollow;
    public float timeToShow = 4f;

    // Start is called before the first frame update
    void Awake()
    {
        cam = GetComponent<Camera>();
        
    }

    void FixedUpdate(){
        transform.position = Vector3.Lerp(transform.position,new Vector3(follow.position.x,transform.position.y,transform.position.z),speed*Time.fixedDeltaTime);
    }

    public void ShowObject(Transform obj){
        follow = obj;
        Invoke("ReturnToFirstObject",timeToShow);
    }

    public void ReturnToFirstObject(){
        follow = firstFollow;
    }

    public bool isReturned(){
        return (transform.position == follow.position);
    }


}
