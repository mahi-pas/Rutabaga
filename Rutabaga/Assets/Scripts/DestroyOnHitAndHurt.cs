using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnHitAndHurt : HurtPlayer
{
    
    public override void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            PlayerHealth ph = other.gameObject.GetComponent<PlayerHealth>();
            Damage(ph);
        }
        DestroySelf();
    }

    public override void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            PlayerHealth ph = other.gameObject.GetComponent<PlayerHealth>();
            Damage(ph);
        }
        DestroySelf();
    }



}
